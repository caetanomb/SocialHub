using SocialHub.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialHub.Core.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; private set; }
        public virtual ICollection<Gig> Gigs { get; set; }

        public Genre(string name)
        {
            Name = name;
        }
    }
}
