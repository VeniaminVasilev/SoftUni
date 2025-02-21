using CarDealership.Core.Contracts;
using CarDealership.Models;
using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;
using System.Text;

namespace CarDealership.Core
{
    public class Controller : IController
    {
        private IDealership _dealership;

        public Controller() { _dealership = new Dealership(); }

        public string AddCustomer(string customerTypeName, string customerName)
        {
            if (customerTypeName != "IndividualClient" && customerTypeName != "LegalEntityCustomer")
            {
                return String.Format(OutputMessages.InvalidType, customerTypeName);
            }

            if (_dealership.Customers.Exists(customerName))
            {
                return String.Format(OutputMessages.CustomerAlreadyAdded, customerName);
            }

            if (customerTypeName == "IndividualClient")
            {
                ICustomer customer = new IndividualClient(customerName);
                _dealership.Customers.Add(customer);
            }

            if (customerTypeName == "LegalEntityCustomer")
            {
                ICustomer customer = new LegalEntityCustomer(customerName);
                _dealership.Customers.Add(customer);
            }

            return String.Format(OutputMessages.CustomerAddedSuccessfully, customerName);
        }

        public string AddVehicle(string vehicleTypeName, string model, double price)
        {
            if (vehicleTypeName != "SaloonCar" && vehicleTypeName != "SUV" && vehicleTypeName != "Truck")
            {
                return String.Format(OutputMessages.InvalidType, vehicleTypeName);
            }

            if (_dealership.Vehicles.Exists(model))
            {
                return String.Format(OutputMessages.VehicleAlreadyAdded, model);
            }

            double updatePrice = 0;

            if (vehicleTypeName == "SaloonCar")
            {
                IVehicle saloonCar = new SaloonCar(model, price);
                _dealership.Vehicles.Add(saloonCar);
                updatePrice = 1.10;
            }

            if (vehicleTypeName == "SUV")
            {
                IVehicle suv = new SUV(model, price);
                _dealership.Vehicles.Add(suv);
                updatePrice = 1.20;
            }

            if (vehicleTypeName == "Truck")
            {
                IVehicle truck = new Truck(model, price);
                _dealership.Vehicles.Add(truck);
                updatePrice = 1.30;
            }

            double recalculatedPrice = price * updatePrice;
            string recalculatedPriceString = recalculatedPrice.ToString("F2");

            return String.Format(OutputMessages.VehicleAddedSuccessfully, vehicleTypeName, model, recalculatedPriceString);
        }

        public string CustomerReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Customer Report:");

            List<ICustomer> customers = _dealership.Customers.Models.OrderBy(c => c.Name).ToList();

            for (int i = 0; i < customers.Count; i++)
            {
                ICustomer customer = customers[i];

                sb.AppendLine(customer.ToString());
                sb.AppendLine("-Models:");

                List<string> vehicles = customer.Purchases.OrderBy(model => model).ToList();

                if (vehicles.Count == 0)
                {
                    sb.AppendLine("--none");
                    continue;
                }

                foreach (string vehicle in vehicles)
                {
                    sb.AppendLine($"--{vehicle}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string PurchaseVehicle(string vehicleTypeName, string customerName, double budget)
        {
            if (!_dealership.Customers.Exists(customerName))
            {
                return String.Format(OutputMessages.CustomerNotFound, customerName);
            }

            if (!_dealership.Vehicles.Models.Any(m => m.GetType().Name == vehicleTypeName))
            {
                return String.Format(OutputMessages.VehicleTypeNotFound, vehicleTypeName);
            }

            ICustomer customer = _dealership.Customers.Get(customerName);

            if (customer.GetType().Name == "IndividualClient" && vehicleTypeName != "SaloonCar" && vehicleTypeName != "SUV")
            {
                return String.Format(OutputMessages.CustomerNotEligibleToPurchaseVehicle, customerName, vehicleTypeName);
            }

            if (customer.GetType().Name == "LegalEntityCustomer" && vehicleTypeName != "SUV" && vehicleTypeName != "Truck")
            {
                return String.Format(OutputMessages.CustomerNotEligibleToPurchaseVehicle, customerName, vehicleTypeName);
            }

            List<IVehicle> affordableVehicles = _dealership
                .Vehicles
                .Models
                .Where(m => m.GetType().Name == vehicleTypeName)
                .Where(m => m.Price <= budget)
                .ToList();

            if (affordableVehicles.Count == 0)
            {
                return String.Format(OutputMessages.BudgetIsNotEnough, customerName, vehicleTypeName);
            }

            IVehicle vehicleToBeBought = affordableVehicles.OrderByDescending(m => m.Price).FirstOrDefault();
            customer.BuyVehicle(vehicleToBeBought.Model);
            vehicleToBeBought.SellVehicle(customerName);

            return String.Format(OutputMessages.VehiclePurchasedSuccessfully, customerName, vehicleToBeBought.Model);
        }

        public string SalesReport(string vehicleTypeName)
        {
            StringBuilder sb = new StringBuilder();

            List<IVehicle> cars = _dealership
                .Vehicles
                .Models
                .Where(m => m.GetType().Name == vehicleTypeName)
                .OrderBy(m => m.Model)
                .ToList();

            sb.AppendLine($"{vehicleTypeName} Sales Report:");

            int carsCount = 0;

            foreach (IVehicle vehicle in cars)
            {
                sb.AppendLine($"--{vehicle.ToString()}");
                carsCount += vehicle.SalesCount;
            }

            sb.AppendLine($"-Total Purchases: {carsCount}");

            return sb.ToString().TrimEnd();
        }
    }
}