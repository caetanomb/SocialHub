using SocialHub.Core.SharedKernel;
using System;

namespace SocialHub.Core.Entities
{
    public class Gig : BaseEntity
    {
        public string ArtistId { get; private set; }
        public DateTime Datetime { get; private set; }
        public string Venue { get; private set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        protected Gig(string artistId, int genreId)
        {
            ArtistId = artistId;
            GenreId = genreId;
        }
    }
}
