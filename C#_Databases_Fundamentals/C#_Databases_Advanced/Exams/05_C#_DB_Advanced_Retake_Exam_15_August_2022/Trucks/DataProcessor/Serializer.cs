namespace Trucks.DataProcessor
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Trucks.DataProcessor.ExportDto;
    using Trucks.Utilities;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            const string xmlRootName = "Despatchers";

            ExportDespatcherDto[] despatchersWithTrucks = context
                .Despatchers
                .AsNoTracking()
                .Include(d => d.Trucks)
                .Where(d => d.Trucks.Any())
                .Select(d => new ExportDespatcherDto()
                {
                    DespatcherName = d.Name,
                    TrucksCount = d.Trucks.Count,
                    Trucks = d.Trucks
                        .OrderBy(t => t.RegistrationNumber)
                        .Select(t => new ExportDespatcherTruckDto()
                        {
                            RegistrationNumber = t.RegistrationNumber,
                            Make = t.MakeType.ToString(),
                        })
                        .ToArray()
                })
                .OrderByDescending(d => d.TrucksCount)
                .ThenBy(d => d.DespatcherName)
                .ToArray();

            string xmlResult = XmlSerializerWrapper.Serialize(despatchersWithTrucks, xmlRootName);
            return xmlResult;
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clientsWithMostTrucks = context
                .Clients
                .Include(c => c.ClientsTrucks)
                .ThenInclude(ct => ct.Truck)
                .ToArray()
                .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
                .Select(c => new
                {
                    Name = c.Name,
                    Trucks = c.ClientsTrucks
                        .Select(ct => ct.Truck)
                        .Where(t => t.TankCapacity >= capacity)
                        .OrderBy(t => t.MakeType)
                        .ThenByDescending(t => t.CargoCapacity)
                        .Select(t => new
                        {
                            TruckRegistrationNumber = t.RegistrationNumber,
                            VinNumber = t.VinNumber,
                            TankCapacity = t.TankCapacity,
                            CargoCapacity = t.CargoCapacity,
                            CategoryType = t.CategoryType.ToString(),
                            MakeType = t.MakeType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(c => c.Trucks.Count())
                .ThenBy(c => c.Name)
                .Take(10)
                .ToArray();

            string jsonResult = JsonConvert
                .SerializeObject(clientsWithMostTrucks, Formatting.Indented);

            return jsonResult;
        }
    }
}
