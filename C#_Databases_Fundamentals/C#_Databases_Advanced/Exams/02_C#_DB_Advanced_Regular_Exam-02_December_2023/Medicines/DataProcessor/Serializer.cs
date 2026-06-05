namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.DataProcessor.ExportDtos;
    using Medicines.Utilities;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            const string xmlRootName = "Patients";
            DateTime dateTime = DateTime.Parse(date);

            ExportPatientDto[] patientsWithTheirMedicines = context
                .Patients
                .AsNoTracking()
                .Include(p => p.PatientsMedicines)
                .ThenInclude(pm => pm.Medicine)
                .Where(p => p.PatientsMedicines.Any(pm => pm.Medicine.ProductionDate > dateTime))
                .OrderByDescending(p => p.PatientsMedicines.Count(pm => pm.Medicine.ProductionDate > dateTime))
                .ThenBy(p => p.FullName)
                .ToArray()
                .Select(p => new ExportPatientDto()
                {
                    Gender = p.Gender.ToString().ToLower(),
                    Name = p.FullName,
                    AgeGroup = p.AgeGroup.ToString(),
                    Medicines = p.PatientsMedicines
                        .Where(pm => pm.Medicine.ProductionDate > dateTime)
                        .OrderByDescending(pm => pm.Medicine.ExpiryDate)
                        .ThenBy(pm => pm.Medicine.Price)
                        .Select(pm => new ExportPatientMedicineDto()
                        {
                            Category = pm.Medicine.Category.ToString().ToLower(),
                            Name = pm.Medicine.Name,
                            Price = pm.Medicine.Price.ToString("F2", CultureInfo.InvariantCulture),
                            Producer = pm.Medicine.Producer,
                            BestBefore = pm.Medicine.ExpiryDate.ToString("yyyy-MM-dd")
                        })
                        .ToArray()
                })
                .ToArray();

            string xmlResult = XmlSerializerWrapper
                .Serialize(patientsWithTheirMedicines, xmlRootName);

            return xmlResult;
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            var medicinesWithPharmacies = context
                .Medicines
                .Where(m => m.Pharmacy.IsNonStop == true && (int)m.Category == medicineCategory)
                .AsNoTracking()
                .OrderBy(m => m.Price)
                .ThenBy(m => m.Name)
                .Select(m => new
                {
                    Name = m.Name,
                    Price = m.Price.ToString("F2"),
                    Pharmacy = new
                    {
                        Name = m.Pharmacy.Name,
                        PhoneNumber = m.Pharmacy.PhoneNumber
                    }
                })
                .ToArray();

            string jsonResult = JsonConvert
                .SerializeObject(medicinesWithPharmacies, Formatting.Indented);
            return jsonResult;
        }
    }
}
