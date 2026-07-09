namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Artillery.Utilities;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            const string xmlRootName = "Countries";

            StringBuilder output = new StringBuilder();
            ICollection<Country> countriesToImport = new List<Country>();

            // the following may be nullable
            IEnumerable<ImportCountryDto>? countryDtos =
                XmlSerializerWrapper.Deserialize<ImportCountryDto[]>(xmlString, xmlRootName);

            if (countryDtos != null)
            {
                foreach (ImportCountryDto countryDto in countryDtos)
                {
                    if (!IsValid(countryDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Country newCountry = new Country()
                    {
                        CountryName = countryDto.CountryName,
                        ArmySize = countryDto.ArmySize
                    };
                    countriesToImport.Add(newCountry);

                    output.AppendLine(string.Format(SuccessfulImportCountry, newCountry.CountryName, newCountry.ArmySize));
                }

                context.Countries.AddRange(countriesToImport);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            const string xmlRootName = "Manufacturers";

            StringBuilder output = new StringBuilder();
            ICollection<Manufacturer> manufacturersToImport = new List<Manufacturer>();

            // the following may be nullable
            IEnumerable<ImportManufacturerDto>? manufacturerDtos =
                XmlSerializerWrapper.Deserialize<ImportManufacturerDto[]>(xmlString, xmlRootName);

            if (manufacturerDtos != null)
            {
                foreach (ImportManufacturerDto manufacturerDto in manufacturerDtos)
                {
                    if (!IsValid(manufacturerDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool manufacturerExists = context
                        .Manufacturers
                        .Any(m => m.ManufacturerName == manufacturerDto.ManufacturerName);

                    bool manufacturerAlreadyImported = manufacturersToImport
                        .Any(m => m.ManufacturerName == manufacturerDto.ManufacturerName);

                    if (manufacturerAlreadyImported || manufacturerExists)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Manufacturer newManufacturer = new Manufacturer()
                    {
                        ManufacturerName = manufacturerDto.ManufacturerName,
                        Founded = manufacturerDto.Founded
                    };
                    manufacturersToImport.Add(newManufacturer);

                    string[] locationParts = newManufacturer.Founded.Split(',');
                    string locationAndCountry = string.Join(", ",
                        locationParts[^2].Trim(),
                        locationParts[^1].Trim());
                    
                    output.AppendLine(string.Format(SuccessfulImportManufacturer, newManufacturer.ManufacturerName, locationAndCountry));
                }

                context.Manufacturers.AddRange(manufacturersToImport);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            const string xmlRootName = "Shells";

            StringBuilder output = new StringBuilder();
            ICollection<Shell> shellsToImport = new List<Shell>();

            // the following may be nullable
            IEnumerable<ImportShellDto>? shellDtos =
                XmlSerializerWrapper.Deserialize<ImportShellDto[]>(xmlString, xmlRootName);

            if (shellDtos != null)
            {
                foreach (ImportShellDto shellDto in shellDtos)
                {
                    if (!IsValid(shellDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Shell newShell = new Shell()
                    {
                        ShellWeight = shellDto.ShellWeight,
                        Caliber = shellDto.Caliber
                    };
                    shellsToImport.Add(newShell);

                    output.AppendLine(string.Format(SuccessfulImportShell, newShell.Caliber, newShell.ShellWeight));
                }

                context.Shells.AddRange(shellsToImport);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();
            ICollection<Gun> gunsToImport = new List<Gun>();

            // nullable
            IEnumerable<ImportGunDto>? gunDtos = JsonConvert.DeserializeObject<ImportGunDto[]>(jsonString);

            if (gunDtos != null)
            {
                foreach(ImportGunDto gunDto in gunDtos)
                {
                    if (!IsValid(gunDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isGunTypeValid = Enum
                        .TryParse<GunType>(gunDto.GunType, out GunType gunType);

                    bool manufacturerExists = context
                        .Manufacturers
                        .Any(m => m.Id == gunDto.ManufacturerId);

                    bool shellExists = context
                        .Shells
                        .Any(s => s.Id == gunDto.ShellId);

                    if ((!isGunTypeValid) || (!manufacturerExists) || (!shellExists))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Gun newGun = new Gun()
                    {
                        ManufacturerId = gunDto.ManufacturerId,
                        GunWeight = gunDto.GunWeight,
                        BarrelLength = gunDto.BarrelLength,
                        NumberBuild = gunDto.NumberBuild,
                        Range = gunDto.Range,
                        GunType = gunType,
                        ShellId = gunDto.ShellId,
                        CountriesGuns = new HashSet<CountryGun>()
                    };

                    foreach (var countryDto in gunDto.Countries)
                    {
                        newGun.CountriesGuns.Add(new CountryGun
                        {
                            CountryId = countryDto.Id
                        });
                    }

                    gunsToImport.Add(newGun);

                    output.AppendLine(String.Format(SuccessfulImportGun, newGun.GunType, newGun.GunWeight, newGun.BarrelLength));
                }

                context.Guns.AddRange(gunsToImport);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}