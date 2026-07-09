
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using Artillery.Utilities;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shellsWithGuns = context
                .Shells
                .Where(s => s.ShellWeight > shellWeight)
                .Include(s => s.Guns)
                .AsNoTracking()
                .Select(s => new
                {
                    s.ShellWeight,
                    s.Caliber,
                    Guns = s.Guns
                        .Where(g => g.GunType == Data.Models.Enums.GunType.AntiAircraftGun)
                        .Select(g => new
                        {
                            GunType = g.GunType.ToString(),
                            g.GunWeight,
                            g.BarrelLength,
                            Range = g.Range > 3000 ? "Long-range" : "Regular range"
                        })
                        .OrderByDescending(g => g.GunWeight)
                        .ToArray()
                })
                .OrderBy(s => s.ShellWeight)
                .ToArray();

            string jsonResult = JsonConvert.SerializeObject(shellsWithGuns, Formatting.Indented);
            return jsonResult;
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            const string xmlRootName = "Guns";
            ExportGunDto[] gunsWithCountries = context
                .Guns
                .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
                .AsNoTracking()
                .Include(g => g.Manufacturer)
                .Include(g => g.CountriesGuns)
                    .ThenInclude(cg => cg.Country)
                .Select(g => new ExportGunDto()
                {
                    Manufacturer = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    GunWeight = g.GunWeight,
                    BarrelLength = g.BarrelLength,
                    Range = g.Range,
                    Countries = g.CountriesGuns
                        .Where(cg => cg.Country.ArmySize > 4500000)
                        .Select(cg => new ExportGunCountryDto()
                        {
                            Country = cg.Country.CountryName,
                            ArmySize = cg.Country.ArmySize
                        })
                        .OrderBy(c => c.ArmySize)
                        .ToArray()
                })
                .OrderBy(g => g.BarrelLength)
                .ToArray();

            string xmlResult = XmlSerializerWrapper.Serialize(gunsWithCountries, xmlRootName);

            return xmlResult;
        }
    }
}
