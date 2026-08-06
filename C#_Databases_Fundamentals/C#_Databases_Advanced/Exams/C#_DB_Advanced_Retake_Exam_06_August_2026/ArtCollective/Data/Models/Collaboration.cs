using System.ComponentModel.DataAnnotations.Schema;

namespace ArtCollective.Data.Models
{
    public class Collaboration
    {
        public int ArtistOneId { get; set; }

        [ForeignKey(nameof(ArtistOneId))]
        public Artist ArtistOne { get; set; } = null!;

        public int ArtistTwoId { get; set; }

        [ForeignKey(nameof(ArtistTwoId))]
        public Artist ArtistTwo { get; set; } = null!;
    }
}
