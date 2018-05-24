using SocialHub.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialHub.Models
{
    public class GigViewModel
    {        
        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        public string Venue { get; set; }

        [DisplayName("Genre")]
        public int GenreId { get; set; }                

        public IEnumerable<GenreViewModel> Genres { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse($"{Date} {Time}");
        }
    }
}
