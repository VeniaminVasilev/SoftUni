using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;
using TravelAgency.Utilities;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            const string xmlRootName = "Customers";

            StringBuilder output = new StringBuilder();
            ICollection<Customer> customersToImport = new List<Customer>();

            // the following may be nullable
            IEnumerable<ImportCustomerDto>? customerDtos = XmlSerializerWrapper.Deserialize<ImportCustomerDto[]>(xmlString, xmlRootName);

            if (customerDtos != null)
            {
                foreach (ImportCustomerDto customerDto in customerDtos)
                {
                    if (!IsValid(customerDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool customerExists = context
                        .Customers
                        .Any(c => c.FullName == customerDto.FullName ||
                        c.Email == customerDto.Email ||
                        c.PhoneNumber == customerDto.PhoneNumber);

                    bool customerAlreadyImported = customersToImport
                        .Any(c => c.FullName == customerDto.FullName ||
                        c.Email == customerDto.Email ||
                        c.PhoneNumber == customerDto.PhoneNumber);

                    if (customerExists || customerAlreadyImported)
                    {
                        output.AppendLine(DuplicationDataMessage);
                        continue;
                    }

                    Customer newCustomer = new Customer()
                    {
                        FullName = customerDto.FullName,
                        Email = customerDto.Email,
                        PhoneNumber = customerDto.PhoneNumber
                    };

                    customersToImport.Add(newCustomer);
                    output.AppendLine(string.Format(SuccessfullyImportedCustomer, newCustomer.FullName));
                }

                context.Customers.AddRange(customersToImport);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();
            ICollection<Booking> bookingsToImport = new List<Booking>();

            // nullable
            IEnumerable<ImportBookingDto>? bookingDtos = JsonConvert.DeserializeObject<ImportBookingDto[]>(jsonString);

            if (bookingDtos != null)
            {
                foreach (ImportBookingDto bookingDto in bookingDtos)
                {
                    if (!IsValid(bookingDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool customerExists = context
                        .Customers
                        .Any(c => c.FullName == bookingDto.CustomerName);

                    bool tourPackageExists = context
                        .TourPackages
                        .Any(tp => tp.PackageName == bookingDto.TourPackageName);

                    if ((!customerExists) || (!tourPackageExists))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isDueDateValid = DateTime
                        .TryParseExact(bookingDto.BookingDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, 
                        DateTimeStyles.None, out DateTime bookingDateValue);

                    if (!isDueDateValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Booking newBooking = new Booking()
                    {
                        BookingDate = bookingDateValue,
                        CustomerId = context
                            .Customers
                            .FirstOrDefault(c => c.FullName == bookingDto.CustomerName)!.Id,
                        TourPackageId = context
                            .TourPackages
                            .FirstOrDefault(tp => tp.PackageName == bookingDto.TourPackageName)!.Id
                    };
                    bookingsToImport.Add(newBooking);
                    output.AppendLine(string.Format(SuccessfullyImportedBooking, bookingDto.TourPackageName, newBooking.BookingDate.ToString("yyyy-MM-dd")));
                }

                context.Bookings.AddRange(bookingsToImport);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
