namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using Invoices.DataProcessor.ExportDto;
    using Invoices.Utilities;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            const string xmlRootName = "Clients";

            ExportClientDto[] clientsWithInvoices = context
                .Clients
                .AsNoTracking()
                .Include(c => c.Invoices)
                .Where(c => c.Invoices.Any(i => i.IssueDate > date))
                .ToArray()
                .Select(c => new ExportClientDto
                {
                    ClientName = c.Name,
                    VatNumber = c.NumberVat,
                    InvoicesCount = c.Invoices.Count(),
                    Invoices = c.Invoices
                        .OrderBy(i => i.IssueDate)
                        .ThenByDescending(i => i.DueDate)
                        .Select(i => new ExportClientInvoiceDto
                        {
                            InvoiceNumber = i.Number,
                            InvoiceAmount = decimal.Parse(i.Amount.ToString("G29")),
                            DueDate = i.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            Currency = i.CurrencyType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(c => c.InvoicesCount)
                .ThenBy(c => c.ClientName)
                .ToArray();

            string xmlResult = XmlSerializerWrapper
                .Serialize(clientsWithInvoices, xmlRootName);

            return xmlResult;
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {

            var productsWithMostClients = context
                .Products
                .Include(p => p.ProductsClients)
                .ThenInclude(pc => pc.Client)
                .AsNoTracking()
                .Where(p => p.ProductsClients
                    .Any(pc => pc.Client.Name.Length >= nameLength))
                .Select(p => new
                {
                    p.Name,
                    Price = decimal.Parse(p.Price.ToString("G29")),
                    Category = p.CategoryType.ToString(),
                    Clients = p.ProductsClients
                        .Where(pc => pc.Client.Name.Length >= nameLength)
                        .Select(pc => new
                        {
                            Name = pc.Client.Name,
                            NumberVat = pc.Client.NumberVat
                        })
                })
                .ToArray()
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    p.Category,
                    Clients = p.Clients
                        .OrderBy(c => c.Name)
                        .ToArray(),
                    ClientsCount = p.Clients.Count()
                })
                .OrderByDescending(p => p.ClientsCount)
                .ThenBy(p => p.Name)
                .Take(5)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    p.Category,
                    Clients = p.Clients
                })
                .ToArray();

            string jsonResult = JsonConvert
                .SerializeObject(productsWithMostClients, Formatting.Indented);
            return jsonResult;
        }
    }
}