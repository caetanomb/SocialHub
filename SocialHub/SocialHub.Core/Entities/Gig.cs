using SocialHub.Core.SharedKernel;
using System;

namespace SocialHub.Core.Entities
{
    public class Gig : BaseEntity
    {
        public string ArtistId { get; private set; }
        public DateTime DateTime { get; private set; }
        public string Venue { get; private set; }
        public int GenreId { get; private set; }
        public Genre Genre { get; private set; }

        public Gig(string artistId, Genre genre, DateTime datetime,
            string venue)
        {
            ArtistId = artistId;
            Genre = genre;
            GenreId = genre.Id;
            DateTime = datetime;
            Venue = venue;
        }
    }
}
