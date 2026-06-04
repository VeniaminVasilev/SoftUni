namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using Cadastre.Data.Enumerations;
    using Cadastre.Data.Models;
    using Cadastre.DataProcessor.ImportDtos;
    using Cadastre.Utilities;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Data.SqlTypes;
    using System.Globalization;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            const string xmlRootName = "Districts";

            StringBuilder output = new StringBuilder();
            ICollection<District> districtsToImport = new List<District>();

            // the following may be nullable
            IEnumerable<ImportDistrictDto>? districtDtos =
                XmlSerializerWrapper.Deserialize<ImportDistrictDto[]>(xmlDocument, xmlRootName);

            if (districtDtos != null)
            {
                foreach (ImportDistrictDto districtDto in districtDtos)
                {
                    ICollection<ImportDistrictPropertyDto> propertiesToImport = new List<ImportDistrictPropertyDto>();

                    if (!IsValid(districtDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool districtExists = dbContext
                        .Districts
                        .Any(d => d.Name == districtDto.Name);

                    bool districtAlreadyImported = districtsToImport
                        .Any(d => d.Name == districtDto.Name);

                    if (districtExists || districtAlreadyImported)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    foreach (ImportDistrictPropertyDto propertyDto in districtDto.Properties)
                    {
                        if (!IsValid(propertyDto))
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        bool isDueDateValid = DateTime
                        .TryParseExact(propertyDto.DateOfAcquisition, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime dueDateValue);

                        if (!isDueDateValid)
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        bool propertyExists = dbContext
                            .Districts
                            .Any(d => d.Properties.Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier));

                        bool propertyAlreadyImported = districtsToImport
                            .Any(d => d.Properties.Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier));
                        
                        bool propertyExistsInCurrentDistrict = propertiesToImport
                            .Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier);

                        if (propertyExists || propertyAlreadyImported || propertyExistsInCurrentDistrict)
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        bool propertyAddressExists = dbContext
                            .Districts
                            .Any(d => d.Properties.Any(p => p.Address == propertyDto.Address));

                        bool propertyAddressAlreadyImported = districtsToImport
                            .Any(d => d.Properties.Any(p => p.Address == propertyDto.Address));

                        bool propertyAddressExistsInCurrentDistrict = propertiesToImport
                            .Any(p => p.Address == propertyDto.Address);

                        if (propertyAddressExists || propertyAddressAlreadyImported || propertyAddressExistsInCurrentDistrict)
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        Property newProperty = new Property
                        {
                            PropertyIdentifier = propertyDto.PropertyIdentifier,
                            Details = propertyDto.Details,
                            Address = propertyDto.Address,
                            Area = propertyDto.Area,
                            DateOfAcquisition = dueDateValue
                        };

                        propertiesToImport.Add(propertyDto);
                    }

                    bool isRegionValid = Enum.TryParse<Region>(districtDto.Region, out Region regionValue);

                    if (!isRegionValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    District newDistrict = new District()
                    {
                        Name = districtDto.Name,
                        PostalCode = districtDto.PostalCode,
                        Region = regionValue,
                        Properties = propertiesToImport.Select(p => new Property
                        {
                            PropertyIdentifier = p.PropertyIdentifier,
                            Details = p.Details,
                            Address = p.Address,
                            Area = p.Area,
                            DateOfAcquisition = DateTime.ParseExact(p.DateOfAcquisition, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        }).ToList()
                    };

                    districtsToImport.Add(newDistrict);

                    output.AppendLine(string.Format(SuccessfullyImportedDistrict, newDistrict.Name, newDistrict.Properties.Count));
                }

                dbContext.Districts.AddRange(districtsToImport);
                dbContext.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            StringBuilder output = new StringBuilder();
            ICollection<Citizen> citizensToImport = new List<Citizen>();

            // nullable
            IEnumerable<ImportCitizenDto>? citizenDtos =
                JsonConvert.DeserializeObject<ImportCitizenDto[]>(jsonDocument);

            if (citizenDtos != null)
            {
                foreach (ImportCitizenDto citizenDto in citizenDtos)
                {
                    if (!IsValid(citizenDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isBirthDateValid = DateTime
                        .TryParseExact(citizenDto.BirthDate, "dd-MM-yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime birthDateValue);

                    bool isMaritalStatusValid = Enum.TryParse<MaritalStatus>
                        (citizenDto.MaritalStatus, out MaritalStatus maritalStatusValue);

                    if ((!isBirthDateValid) || (!isMaritalStatusValid))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Citizen newCitizen = new Citizen()
                    {
                        FirstName = citizenDto.FirstName,
                        LastName = citizenDto.LastName,
                        BirthDate = birthDateValue,
                        MaritalStatus = maritalStatusValue,
                        PropertiesCitizens = dbContext
                            .Districts
                            .SelectMany(d => d.Properties)
                            .Where(p => citizenDto.Properties.Contains(p.Id))
                            .Select(p => new PropertyCitizen
                            {
                                Property = p
                            })
                            .ToList()
                    };

                    citizensToImport.Add(newCitizen);
                    output.AppendLine(string.Format(SuccessfullyImportedCitizen, newCitizen.FirstName, 
                        newCitizen.LastName, newCitizen.PropertiesCitizens.Count));
                }

                dbContext.Citizens.AddRange(citizensToImport);
                dbContext.SaveChanges();
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
