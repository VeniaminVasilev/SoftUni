using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ArtCollective.DataProcessor.ImportDTOs
{
    public class ImportArtworkDto
    {
        [JsonProperty("Title")]
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Title { get; set; } = null!;

        [JsonProperty("Description")]
        [MaxLength(300)]
        [MinLength(10)]
        public string? Description { get; set; }

        [JsonProperty("CreatedOn")]
        [Required]
        public string CreatedOn { get; set; } = null!;

        [JsonProperty("ArtistId")]
        [Required]
        public int ArtistId { get; set; }
    }
}
