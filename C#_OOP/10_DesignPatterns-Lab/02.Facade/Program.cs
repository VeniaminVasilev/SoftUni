namespace _02.Facade
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
                .Info
                    .WithType("Toyota")
                    .WithColor("White")
                    .WithNumberOfDoors(5)
                .Built
                    .InCity("Tokyo")
                    .AtAddress("Some address 254")
                .Build();

            Console.WriteLine(car);
        }
    }
}