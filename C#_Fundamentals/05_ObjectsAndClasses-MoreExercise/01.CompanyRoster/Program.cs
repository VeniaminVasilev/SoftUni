namespace _01.CompanyRoster
{
    class Employee
    { 
        public string EmployeeName { get; set; }
        public decimal Salary { get; set; }

        public Employee(string name, decimal salary)
        {
            this.EmployeeName = name;
            this.Salary = salary;
        }
    }

    class Department
    {
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public decimal TotalSalaries { get; set; }

        public Department(string departmentName)
        {
            this.DepartmentName = departmentName;
        }

        public void AddNewEmployee(string employeeName, decimal employeeSalary)
        {
            this.TotalSalaries += employeeSalary;

            this.Employees.Add(new Employee(employeeName, employeeSalary));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>();

            int numberOfEmployees = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEmployees; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ");
                string employeeName = tokens[0];
                decimal employeeSalary = decimal.Parse(tokens[1]);
                string departmentName = tokens[2];

                bool departmentExists = false;
                bool employeeExists = false;

                for (int j = 0; j < departments.Count; j++)
                {
                    if (departments[j].DepartmentName == departmentName)
                    {
                        departmentExists = true;
                    }

                    for (int k = 0; k < departments[j].Employees.Count; k++)
                    {
                        if (departments[j].Employees[k].EmployeeName == employeeName)
                        {
                            employeeExists = true;
                        }
                    }
                }

                if (departmentExists == false && employeeExists == false)
                {
                    departments.Add(new Department(departmentName));
                    departments.Find(d => d.DepartmentName == departmentName).AddNewEmployee(employeeName, employeeSalary);
                }
                else if (departmentExists == true && employeeExists == false)
                {
                    departments.Find(d => d.DepartmentName == departmentName).AddNewEmployee(employeeName, employeeSalary);
                }
            }

            Department bestDepartment = departments.OrderByDescending(d => d.TotalSalaries / d.Employees.Count()).First();

            Console.WriteLine($"Highest Average Salary: {bestDepartment.DepartmentName}");

            foreach (var employee in bestDepartment.Employees.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{employee.EmployeeName} {employee.Salary:F2}");
            }
        }
    }
}