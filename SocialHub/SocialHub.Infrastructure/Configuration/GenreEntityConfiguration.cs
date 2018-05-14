using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialHub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialHub.Infrastructure.Configuration
{
    public class GenreEntityConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(a => a.Id);            

            builder.Property(a => a.Name)
                .HasMaxLength(255)
                .IsRequired();            
        }
    }
}
