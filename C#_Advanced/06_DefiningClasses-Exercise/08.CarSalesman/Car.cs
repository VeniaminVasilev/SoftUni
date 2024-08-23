namespace _08.CarSalesman
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int? Weight { get; set; }
        public string Color { get; set; }

        public Car(string model, Engine engine, int? weight = null, string color = null)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }
    }
}
