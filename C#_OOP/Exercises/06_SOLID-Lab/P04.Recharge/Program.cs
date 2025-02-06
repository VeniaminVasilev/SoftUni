using System;

namespace P04.Recharge
{
    public class Program
    {
        public static void Main()
        {
            RechargeableStation rechargeableStation = new RechargeableStation(10);
            Console.WriteLine($"The newly opened Rechargeable station can recharge {rechargeableStation.Capacity} robots at once.");

            Robot robot = new Robot("Robot1", 10);
            Console.WriteLine($"The new robot has capacity of {robot.Capacity} working hours.");

            int robotWorkingHours = 10;
            robot.Work(robotWorkingHours);
            Console.WriteLine($"Our robot has worked today for {robotWorkingHours} hours.");
            Console.WriteLine($"Its current power is {robot.CurrentPower}.");

            rechargeableStation.Charge(robot);
            Console.WriteLine($"The robot is being recharged.");
            Console.WriteLine($"The rechargeable station current load is {rechargeableStation.Current}.");

            rechargeableStation.Dismount();
            Console.WriteLine($"The robot is fully recharged and dismounted.");
            Console.WriteLine($"The robot current power is {robot.CurrentPower}.");
            Console.WriteLine($"The rechargeable station current load is {rechargeableStation.Current}.");

            Employee employee = new Employee("Employee1");
            int employeeWorkingHours = 8;
            employee.Work(employeeWorkingHours);
            Console.WriteLine($"Our best employee has worked for {employeeWorkingHours} hours today. Let him rest.");
            employee.Sleep();
        }
    }
}