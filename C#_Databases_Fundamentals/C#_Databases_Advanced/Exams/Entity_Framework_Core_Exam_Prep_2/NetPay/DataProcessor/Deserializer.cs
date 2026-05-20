using NetPay.Data;
using NetPay.Data.Models;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ImportDtos;
using NetPay.Utilities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace NetPay.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedHousehold = "Successfully imported household. Contact person: {0}";
        private const string SuccessfullyImportedExpense = "Successfully imported expense. {0}, Amount: {1}";

        public static string ImportHouseholds(NetPayContext context, string xmlString)
        {
            const string xmlRootName = "Households";

            StringBuilder output = new StringBuilder();
            ICollection<Household> householdsToImport = new List<Household>();

            // the following may be nullable
            IEnumerable<ImportHouseholdDto>? householdDtos =
                XmlSerializerWrapper.Deserialize<ImportHouseholdDto[]>(xmlString, xmlRootName);
            if (householdDtos != null)
            {
                foreach (ImportHouseholdDto householdDto in householdDtos)
                {
                    if (!IsValid(householdDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool householdExists = context
                        .Households
                        .Any(h => h.ContactPerson == householdDto.ContactPerson ||
                            h.PhoneNumber == householdDto.PhoneNumber ||
                            (h.Email != null && h.Email == householdDto.Email));

                    bool householdAlreadyImported = householdsToImport
                        .Any(h => h.ContactPerson == householdDto.ContactPerson ||
                            h.PhoneNumber == householdDto.PhoneNumber ||
                            (h.Email != null && h.Email == householdDto.Email));

                    if (householdExists || householdAlreadyImported)
                    {
                        output.AppendLine(DuplicationDataMessage);
                        continue;
                    }

                    Household newHousehold = new Household()
                    {
                        ContactPerson = householdDto.ContactPerson,
                        PhoneNumber = householdDto.PhoneNumber,
                        Email = householdDto.Email
                    };
                    householdsToImport.Add(newHousehold);

                    output.AppendLine(string.Format(SuccessfullyImportedHousehold, householdDto.ContactPerson));
                }

                context.Households.AddRange(householdsToImport);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportExpenses(NetPayContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();
            ICollection<Expense> expensesToImport = new List<Expense>();

            // nullable
            IEnumerable<ImportExpenseDto>? expenseDtos = JsonConvert.DeserializeObject<ImportExpenseDto[]>(jsonString);

            if (expenseDtos != null)
            {
                foreach (ImportExpenseDto expenseDto in expenseDtos)
                {
                    if (!IsValid(expenseDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool householdExists = context
                        .Households
                        .Any(h => h.Id == expenseDto.HouseholdId!.Value);
                    bool serviceExists = context
                        .Services
                        .Any(s => s.Id == expenseDto.ServiceId!.Value);

                    if ((!householdExists) || (!serviceExists))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isDueDateValid = DateTime
                        .TryParseExact(expenseDto.DueDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, 
                        DateTimeStyles.None, out DateTime dueDateValue);

                    bool isPaymentStatusValid = Enum
                        .TryParse<PaymentStatus>(expenseDto.PaymentStatus, out PaymentStatus paymentStatusValue);

                    if ((!isDueDateValid) || (!isPaymentStatusValid))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Expense newExpense = new Expense()
                    {
                        ExpenseName = expenseDto.ExpenseName,
                        Amount = expenseDto.Amount!.Value,
                        DueDate = dueDateValue,
                        PaymentStatus = paymentStatusValue,
                        HouseholdId = expenseDto.HouseholdId!.Value,
                        ServiceId = expenseDto.ServiceId!.Value
                    };
                    expensesToImport.Add(newExpense);

                    output.AppendLine(String.Format(SuccessfullyImportedExpense,
                        expenseDto.ExpenseName, expenseDto.Amount.Value.ToString("F2")));
                }

                context.Expenses.AddRange(expensesToImport);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach(var result in validationResults)
            {
                string currvValidationMessage = result.ErrorMessage;
            }

            return isValid;
        }
    }
}
