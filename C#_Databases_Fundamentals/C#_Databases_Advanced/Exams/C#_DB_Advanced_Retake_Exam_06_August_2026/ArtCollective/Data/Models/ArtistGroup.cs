using System.ComponentModel.DataAnnotations.Schema;

namespace ArtCollective.Data.Models
{
    public class ArtistGroup
    {
        [ForeignKey(nameof(Artist))]
        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; } = null!;

        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }

        public virtual Group Group { get; set; } = null!;
    }
}
