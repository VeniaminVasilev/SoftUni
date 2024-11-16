using System.Runtime.CompilerServices;

namespace _01.ClassBoxData
{
    public class Box
    {
        private double _length;
        private double _width;
        private double _height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get { return _length; }
            private set
            { 
                if (value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                _length = value;
            }
        }

        public double Width
        {
            get { return _width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                _width = value;
            }
        }

        public double Height
        {
            get { return _height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }
                _height = value;
            }
        }

        public double SurfaceArea()
        {
            return (2 * Length * _width) + (2 * _length * _height) + (2 * _width * _height);
        }

        public double LateralSurfaceArea()
        {
            return (2 * _length * _height) + (2 * _width * _height);
        }

        public double Volume()
        {
            return _length * _width * _height;
        }
    }
}