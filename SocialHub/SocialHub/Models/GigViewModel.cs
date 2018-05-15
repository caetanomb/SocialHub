using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SocialHub.Models
{
    public class GigViewModel
    {
        public string ArtistId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Venue { get; set; }
        [DisplayName("Genre")]
        public int GenreId { get; set; }
        public IEnumerable<GenreViewModel> Genres { get; set; }
    }
}
