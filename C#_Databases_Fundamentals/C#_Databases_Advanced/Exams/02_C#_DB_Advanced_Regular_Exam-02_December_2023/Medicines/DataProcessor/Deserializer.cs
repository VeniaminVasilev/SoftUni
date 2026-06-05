namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ImportDtos;
    using Medicines.Utilities;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();
            ICollection<Patient> patientsToImport = new List<Patient>();

            // nullable
            IEnumerable<ImportPatientDto>? patientDtos = JsonConvert.DeserializeObject<ImportPatientDto[]>(jsonString);

            if (patientDtos != null)
            {
                foreach (ImportPatientDto patientDto in patientDtos)
                {
                    if (!IsValid(patientDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isAgeGroupValid = Enum.TryParse<AgeGroup>(patientDto.AgeGroup, out AgeGroup ageGroupValue)
                        && Enum.IsDefined(typeof(AgeGroup), ageGroupValue);

                    bool isGenderValid = Enum.TryParse<Gender>(patientDto.Gender, out Gender genderValue)
                        && Enum.IsDefined(typeof(Gender), genderValue);

                    if ((!isAgeGroupValid) || (!isGenderValid))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    ICollection<PatientMedicine> patientMedicinesToImport = new List<PatientMedicine>();

                    foreach (int id in patientDto.Medicines)
                    {
                        if (patientMedicinesToImport.Any(pm => pm.MedicineId == id))
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        patientMedicinesToImport.Add(new PatientMedicine
                        {
                            MedicineId = id,
                            Medicine = context
                                .Medicines
                                .First(m => m.Id == id)
                        });
                    }

                    Patient newPatient = new Patient
                    {
                        FullName = patientDto.FullName,
                        AgeGroup = ageGroupValue,
                        Gender = genderValue,
                        PatientsMedicines = patientMedicinesToImport
                    };

                    patientsToImport.Add(newPatient);
                    output.AppendLine(string.Format(SuccessfullyImportedPatient, newPatient.FullName, patientMedicinesToImport.Count));
                }

                context.Patients.AddRange(patientsToImport);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            const string xmlRootName = "Pharmacies";

            StringBuilder output = new StringBuilder();
            ICollection<Pharmacy> pharmaciesToImport = new List<Pharmacy>();

            // the following may be nullable
            IEnumerable<ImportPharmacyDto>? pharmacyDtos =
                XmlSerializerWrapper.Deserialize<ImportPharmacyDto[]>(xmlString, xmlRootName);

            if (pharmacyDtos != null)
            {
                foreach (ImportPharmacyDto pharmacyDto in pharmacyDtos)
                {
                    bool isIsNonStopBoolValid = bool.TryParse(pharmacyDto.IsNonStop, out bool isNonStopValue);

                    if (!isIsNonStopBoolValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!IsValid(pharmacyDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    ICollection<Medicine> medicinesToImport = new List<Medicine>();

                    foreach (ImportPharmacyMedicineDto pharmacyMedicineDto in pharmacyDto.Medicines)
                    {
                        if (!IsValid(pharmacyMedicineDto))
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        bool isCategoryValid = Enum.TryParse<Category>(pharmacyMedicineDto.Category, out Category categoryValue)
                            && Enum.IsDefined(typeof(Category), categoryValue);

                        bool isProductionDateValid = DateTime.TryParseExact(pharmacyMedicineDto.ProductionDate,
                            "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime productionDateValue);
                        bool isExpiryDateValid = DateTime.TryParseExact(pharmacyMedicineDto.ExpiryDate,
                            "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expiryDateValue);

                        bool isPriceValid = pharmacyMedicineDto.Price >= 0.01m
                            && pharmacyMedicineDto.Price <= 1000.00m;

                        if (!isCategoryValid || !isProductionDateValid || !isExpiryDateValid || !isPriceValid)
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        if (productionDateValue >= expiryDateValue)
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        bool medicineAlreadyImportedInCurrentPharmacy = medicinesToImport
                            .Any(m => m.Name == pharmacyMedicineDto.Name && m.Producer == pharmacyMedicineDto.Producer);

                        if (medicineAlreadyImportedInCurrentPharmacy)
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        Medicine medicine = new Medicine()
                        {
                            Category = categoryValue,
                            Name = pharmacyMedicineDto.Name,
                            Price = pharmacyMedicineDto.Price,
                            ProductionDate = productionDateValue,
                            ExpiryDate = expiryDateValue,
                            Producer = pharmacyMedicineDto.Producer
                        };
                        medicinesToImport.Add(medicine);
                    }

                    Pharmacy newPharmacy = new Pharmacy()
                    {
                        IsNonStop = isNonStopValue,
                        Name = pharmacyDto.Name,
                        PhoneNumber = pharmacyDto.PhoneNumber,
                        Medicines = medicinesToImport
                    };
                    pharmaciesToImport.Add(newPharmacy);

                    output.AppendLine(string.Format(SuccessfullyImportedPharmacy, newPharmacy.Name, newPharmacy.Medicines.Count));
                }

                context.Pharmacies.AddRange(pharmaciesToImport);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
