using System.Xml.Serialization;

namespace ArtCollective.DataProcessor.ExportDTOs
{
    [XmlType("Artwork")]
    public class ExportArtistArtworkDto
    {
        [XmlElement("Title")]
        public string Title { get; set; } = null!;

        [XmlElement("CreatedOn")]
        public string CreatedOn { get; set; } = null!;
    }
}
