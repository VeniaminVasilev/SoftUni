using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NetPay.DataProcessor.ImportDtos
{
    [XmlType("Household")]
    public class ImportHouseholdDto
    {
        [XmlElement("ContactPerson")]
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string ContactPerson { get; set; } = null!;

        [XmlElement("Email")]
        [MinLength(6)]
        [MaxLength(80)]
        public string? Email { get; set; }

        [XmlAttribute("phone")]
        [Required]
        [MinLength(15)]
        [MaxLength(15)]
        [RegularExpression(@"^\+\d{3}/\d{3}-\d{6}$")]
        public string PhoneNumber { get; set; } = null!;
    }
}
