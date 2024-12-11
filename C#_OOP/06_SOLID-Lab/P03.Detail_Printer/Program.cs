using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class Program
    {
        public static void Main()
        {
            List<Employee> employees = new List<Employee>();
            Employee employee = new Employee("John");
            employees.Add(employee);

            List<string> documents = new List<string>() { "Document1", "Document2", "Document3" };
            Manager manager = new Manager("George", documents);
            employees.Add(manager);

            DetailsPrinter detailsPrinter = new DetailsPrinter(employees);
            detailsPrinter.PrintDetails();
        }
    }
}