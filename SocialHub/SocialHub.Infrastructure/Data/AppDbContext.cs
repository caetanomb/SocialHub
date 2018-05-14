using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using SocialHub.Core.Entities;
using SocialHub.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialHub.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public AppDbContext(DbContextOptions options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GenreEntityConfiguration());
            modelBuilder.ApplyConfiguration(new GigEntityConfiguration());            
        }
    }
}
