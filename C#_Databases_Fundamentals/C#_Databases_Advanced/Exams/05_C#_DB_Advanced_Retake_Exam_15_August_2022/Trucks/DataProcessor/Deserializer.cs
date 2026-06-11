namespace Trucks.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;
    using Trucks.Utilities;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            const string xmlRootName = "Despatchers";

            StringBuilder output = new StringBuilder();
            ICollection<Despatcher> despatchersToImport = new List<Despatcher>();

            // the following may be nullable
            IEnumerable<ImportDespatcherDto>? despatcherDtos =
                XmlSerializerWrapper.Deserialize<ImportDespatcherDto[]>(xmlString, xmlRootName);

            if (despatcherDtos != null)
            {
                foreach (ImportDespatcherDto despatcherDto in despatcherDtos) 
                {
                    if (!IsValid(despatcherDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Despatcher despatcher = new Despatcher()
                    {
                        Name = despatcherDto.Name,
                        Position = despatcherDto.Position
                    };

                    ICollection<Truck> trucksToImport = new List<Truck>();

                    foreach (ImportDespatcherTruckDto truckDto in despatcherDto.Trucks)
                    {
                        if (!IsValid(truckDto))
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        bool isCategoryTypeValid = Enum.IsDefined(typeof(CategoryType), truckDto.CategoryType);
                        bool isMakeTypeValid = Enum.IsDefined(typeof(MakeType), truckDto.MakeType);

                        if (!isCategoryTypeValid || !isMakeTypeValid)
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        Truck truck = new Truck()
                        {
                            RegistrationNumber = truckDto.RegistrationNumber,
                            VinNumber = truckDto.VinNumber,
                            TankCapacity = truckDto.TankCapacity,
                            CargoCapacity = truckDto.CargoCapacity,
                            CategoryType = (CategoryType)truckDto.CategoryType,
                            MakeType = (MakeType)truckDto.MakeType
                        };

                        trucksToImport.Add(truck);
                    }

                    despatcher.Trucks = trucksToImport;
                    despatchersToImport.Add(despatcher);
                    output.AppendLine(string.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
                }

                context.Despatchers.AddRange(despatchersToImport);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportClient(TrucksContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();
            ICollection<Client> clientsToImport = new List<Client>();

            // nullable
            IEnumerable<ImportClientDto>? clientDtos =
                JsonConvert.DeserializeObject<ImportClientDto[]>(jsonString);

            if (clientDtos != null)
            {
                foreach (ImportClientDto clientDto in clientDtos)
                {
                    if (!IsValid(clientDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (clientDto.Type == "usual")
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    List<int> trucksIds = new List<int>();

                    foreach (int truckId in clientDto.Trucks.Distinct())
                    {
                        if (!context.Trucks.Any(t => t.Id == truckId))
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        trucksIds.Add(truckId);
                    }

                    Client newClient = new Client()
                    {
                        Name = clientDto.Name,
                        Nationality = clientDto.Nationality,
                        Type = clientDto.Type,
                        ClientsTrucks = trucksIds.Select(t => new ClientTruck()
                        {
                            TruckId = t
                        }).ToList()
                    };

                    clientsToImport.Add(newClient);
                    output.AppendLine(string.Format(SuccessfullyImportedClient, newClient.Name, newClient.ClientsTrucks.Count));
                }

                context.Clients.AddRange(clientsToImport);
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