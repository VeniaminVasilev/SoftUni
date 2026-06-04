using Cadastre.Data;
using Cadastre.DataProcessor.ExportDtos;
using Cadastre.Utilities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
            var propertiesWithOwners = dbContext
                 .Properties
                 .Include(p => p.PropertiesCitizens)
                 .ThenInclude(pc => pc.Citizen)
                 .AsNoTracking()
                 .Where(p => p.DateOfAcquisition >= new DateTime(2000, 1, 1))
                 .OrderByDescending(p => p.DateOfAcquisition)
                 .ThenBy(p => p.PropertyIdentifier)
                 .ToArray()
                 .Select(p => new
                 {
                     p.PropertyIdentifier,
                     p.Area,
                     p.Address,
                     DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy"),
                     Owners = p.PropertiesCitizens
                         .Select(pc => pc.Citizen)
                         .OrderBy(c => c.LastName)
                         .Select(c => new
                         {
                             c.LastName,
                             MaritalStatus = c.MaritalStatus.ToString()
                         })
                         .ToArray()
                 })
                 .ToArray();

            string jsonResult = JsonConvert
                .SerializeObject(propertiesWithOwners, Formatting.Indented);
            return jsonResult;
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {
            const string xmlRootName = "Properties";
            ExportPropertyDto[] propertiesWithDistrict = dbContext
                .Properties
                .AsNoTracking()
                .Include(p => p.District)
                .Where(p => p.Area >= 100)
                .OrderByDescending(p => p.Area)
                .ThenBy(p => p.DateOfAcquisition)
                .ToArray()
                .Select(p => new ExportPropertyDto()
                {
                    PostalCode = p.District.PostalCode,
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy")
                })
                .ToArray();

            string xmlResult = XmlSerializerWrapper
                .Serialize(propertiesWithDistrict, xmlRootName);

            return xmlResult;
        }
    }
}
