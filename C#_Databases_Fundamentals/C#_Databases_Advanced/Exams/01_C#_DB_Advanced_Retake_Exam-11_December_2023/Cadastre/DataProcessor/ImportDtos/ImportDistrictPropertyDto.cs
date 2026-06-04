using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType("Property")]
    public class ImportDistrictPropertyDto
    {
        [XmlElement("PropertyIdentifier")]
        [Required]
        [MinLength(16)]
        [MaxLength(20)]
        public string PropertyIdentifier { get; set; } = null!;

        [XmlElement("Area")]
        [Required]
        [Range(0, int.MaxValue)] // prevents negative values
        public int Area { get; set; }

        [XmlElement("Details")]
        [MinLength(5)]
        [MaxLength(500)]
        public string? Details { get; set; }

        [XmlElement("Address")]
        [Required]
        [MinLength(5)]
        [MaxLength(200)]
        public string Address { get; set; } = null!;

        [XmlElement("DateOfAcquisition")]
        [Required]
        public string DateOfAcquisition { get; set; } = null!;
    }
}
