using System.Xml.Serialization;

namespace ArtCollective.DataProcessor.ExportDTOs
{
    [XmlType("Artist")]
    public class ExportArtistDto
    {
        [XmlAttribute("Collaborations")]
        public int Collaborations { get; set; }

        [XmlElement("Username")]
        public string Username { get; set; } = null!;

        [XmlArray("Artworks")]
        public ExportArtistArtworkDto[] Artworks { get; set; } = null!;
    }
}
