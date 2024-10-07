namespace SharkTaxonomy
{
    public class Shark
    {
        private string _kind;
        private int _length;
        private string _food;
        private string _habitat;

        public string Kind { get { return _kind; } }
        public int Length { get { return _length; } }
        public string Food { get { return _food; } }
        public string Habitat { get { return _habitat; } }

        public Shark(string kind, int length, string food, string habitat)
        {
            _kind = kind;
            _length = length;
            _food = food;
            _habitat = habitat;
        }

        public override string ToString()
        {
            return $"{_kind} shark: {_length}m long.\nCould be spotted in the {_habitat}, typical menu: {_food}";
        }
    }
}