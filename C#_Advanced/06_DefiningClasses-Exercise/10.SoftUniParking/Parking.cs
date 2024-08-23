using System.Collections.Generic;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public int Count
        {
            get { return cars.Count; }
        }

        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.capacity = capacity;
        }

        public string AddCar(Car car)
        {
            string registrationNumber = car.RegistrationNumber;
            bool carExists = false;

            foreach (Car car1 in cars)
            {
                if (car1.RegistrationNumber == registrationNumber)
                {
                    carExists = true;
                    return "Car with that registration number, already exists!";
                }
            }

            if (!carExists)
            {
                if (cars.Count >= capacity)
                {
                    return "Parking is full!";
                }
                else
                {
                    cars.Add(car);
                    return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
                }
            }
            else
            {
                return null;
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            Car carToRemove = cars.Find(c => c.RegistrationNumber == registrationNumber);

            if (carToRemove != null)
            {
                cars.Remove(carToRemove);
                return $"Successfully removed {registrationNumber}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return cars.Find(c => c.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (string registrationNumber in registrationNumbers)
            {
                Car carToFind = cars.Find(cars => cars.RegistrationNumber == registrationNumber);

                if (carToFind != null)
                {
                    cars.Remove(carToFind);
                }
            }
        }
    }
}