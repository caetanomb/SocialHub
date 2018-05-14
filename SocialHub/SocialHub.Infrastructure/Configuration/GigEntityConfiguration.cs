using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialHub.Infrastructure.Configuration
{
    public class GigEntityConfiguration : IEntityTypeConfiguration<Gig>
    {
        public void Configure(EntityTypeBuilder<Gig> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.ArtistId)
                .HasMaxLength(450)                
                .IsRequired();

            builder.Property(a => a.Datetime)
                .IsRequired();

            builder.HasOne(a => a.Genre).WithMany(b => b.Gigs);                

            builder.Property(a => a.Venue)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
