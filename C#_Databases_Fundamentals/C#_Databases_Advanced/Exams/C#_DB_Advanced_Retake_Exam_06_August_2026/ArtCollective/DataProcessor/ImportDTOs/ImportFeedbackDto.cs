using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ArtCollective.DataProcessor.ImportDTOs
{
    [XmlType("Feedback")]
    public class ImportFeedbackDto
    {
        [XmlAttribute("GivenOn")]
        [Required]
        public string GivenOn { get; set; } = null!;

        [XmlElement("Content")]
        [Required]
        [MaxLength(200)]
        [MinLength(3)]
        public string Content { get; set; } = null!;

        [XmlElement("Status")]
        [Required]
        public string Status { get; set; } = null!;

        [XmlElement("GroupId")]
        [Required]
        public int GroupId { get; set; }

        [XmlElement("ArtistId")]
        [Required]
        public int ArtistId { get; set; }
    }
}
