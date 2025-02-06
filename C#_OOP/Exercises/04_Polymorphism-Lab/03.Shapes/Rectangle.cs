namespace Shapes
{
    public class Rectangle : Shape
    {
        public double Height { get; private set; }
        public double Width { get; private set; }

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.Height + this.Width);
        }

        public override string Draw()
        {
            return $"Drawing {this.GetType().Name}";
        }
    }
}