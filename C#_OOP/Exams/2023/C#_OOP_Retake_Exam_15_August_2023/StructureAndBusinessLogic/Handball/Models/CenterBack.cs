namespace Handball.Models
{
    public class CenterBack : Player
    {
        private const double rating = 4.0;

        public CenterBack(string name) : base(name, rating)
        {
        }

        public override void DecreaseRating()
        {
            this.Rating -= 1.0;

            if (this.Rating < 1) { this.Rating = 1; }
        }

        public override void IncreaseRating()
        {
            this.Rating += 1.0;

            if (this.Rating > 10) { this.Rating = 10; }
        }
    }
}