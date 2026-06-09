namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.Data.Models.Enums;
    using Invoices.DataProcessor.ImportDto;
    using Invoices.Utilities;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            const string xmlRootName = "Clients";

            StringBuilder output = new StringBuilder();
            ICollection<Client> clientsToImport = new List<Client>();

            // the following may be nullable
            IEnumerable<ImportClientDto>? clientDtos =
                XmlSerializerWrapper.Deserialize<ImportClientDto[]>(xmlString, xmlRootName);

            if (clientDtos != null)
            {
                foreach (ImportClientDto clientdto in clientDtos)
                {
                    if (!IsValid(clientdto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    List<ImportClientAddressDto> addressesToImport = new List<ImportClientAddressDto>();

                    foreach (ImportClientAddressDto addressDto in clientdto.Addresses)
                    {
                        if (!IsValid(addressDto))
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }
                        addressesToImport.Add(addressDto);
                    }

                    Client newClient = new Client()
                    {
                        Name = clientdto.Name,
                        NumberVat = clientdto.NumberVat,
                        Addresses = addressesToImport.Select(a => new Address()
                        {
                            StreetName = a.StreetName,
                            StreetNumber = a.StreetNumber,
                            PostCode = a.PostCode,
                            City = a.City,
                            Country = a.Country
                        }).ToList()
                    };
                    clientsToImport.Add(newClient);

                    output.AppendLine(string.Format(SuccessfullyImportedClients, newClient.Name));
                }

                context.Clients.AddRange(clientsToImport);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();
            ICollection<Invoice> invoicesToImport = new List<Invoice>();

            // nullable
            IEnumerable<ImportInvoiceDto>? invoiceDtos =
                JsonConvert.DeserializeObject<ImportInvoiceDto[]>(jsonString);

            if (invoiceDtos != null)
            {
                foreach (ImportInvoiceDto invoiceDto in invoiceDtos)
                {
                    if (!IsValid(invoiceDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isIssueDateValid = DateTime.TryParse(
                        invoiceDto.IssueDate,
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime issueDate);

                    bool isDueDateValid = DateTime.TryParse(
                        invoiceDto.DueDate,
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime dueDate);

                    bool isDueDateBeforeIssueDate = isIssueDateValid && isDueDateValid && dueDate < issueDate;

                    bool isCurrencyTypeValid = Enum.IsDefined(typeof(CurrencyType), invoiceDto.CurrencyType);

                    if ((!isIssueDateValid) || (!isDueDateValid) || isDueDateBeforeIssueDate || (!isCurrencyTypeValid))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Invoice newInvoice = new Invoice()
                    {
                        Number = invoiceDto.Number,
                        IssueDate = issueDate,
                        DueDate = dueDate,
                        Amount = invoiceDto.Amount,
                        CurrencyType = (CurrencyType)invoiceDto.CurrencyType,
                        ClientId = invoiceDto.ClientId
                    };
                    invoicesToImport.Add(newInvoice);

                    output.AppendLine(String.Format(SuccessfullyImportedInvoices, newInvoice.Number));
                }

                context.Invoices.AddRange(invoicesToImport);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();
            ICollection<Product> productsToImport = new List<Product>();

            // nullable
            IEnumerable<ImportProductDto>? productDtos =
                JsonConvert.DeserializeObject<ImportProductDto[]>(jsonString);

            if (productDtos != null)
            {
                foreach (ImportProductDto productDto in productDtos)
                {
                    if (!IsValid(productDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isCategoryTypeValid = Enum.IsDefined(typeof(CategoryType), productDto.CategoryType);

                    if (!isCategoryTypeValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    List<int> clientsToTake = new List<int>();

                    foreach (int clientId in productDto.Clients.Distinct())
                    {
                        if (clientsToTake.Contains(clientId))
                        {
                            continue;
                        }

                        if (!context.Clients.Any(c => c.Id == clientId))
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        clientsToTake.Add(clientId);
                    }

                    Product newProduct = new Product()
                    {
                        Name = productDto.Name,
                        Price = productDto.Price,
                        CategoryType = (CategoryType)productDto.CategoryType,
                        ProductsClients = clientsToTake.Select(c => new ProductClient()
                        {
                            ClientId = c
                        }).ToList()
                    };
                    productsToImport.Add(newProduct);

                    output.AppendLine(String.Format(SuccessfullyImportedProducts, newProduct.Name, newProduct.ProductsClients.Count));
                }

                context.Products.AddRange(productsToImport);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    } 
}
