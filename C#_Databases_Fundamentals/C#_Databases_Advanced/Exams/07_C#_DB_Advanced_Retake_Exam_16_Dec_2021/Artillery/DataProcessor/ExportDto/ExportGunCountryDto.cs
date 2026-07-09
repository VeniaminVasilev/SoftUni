using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Country")]
    public class ExportGunCountryDto
    {
        [XmlAttribute("Country")]
        public string Country { get; set; } = null!;

        [XmlAttribute("ArmySize")]
        public int ArmySize { get; set; }
    }
}
