﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SocialHub.Infrastructure.Data;
using System;

namespace SocialHub.Infrastructure.Migrations.AppDb
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180514181809_GigAndGenreEntity")]
    partial class GigAndGenreEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SocialHub.Core.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("SocialHub.Core.Entities.Gig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArtistId");

                    b.Property<DateTime>("Datetime");

                    b.Property<int?>("GenreId");

                    b.Property<string>("Venue");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Gigs");
                });

            modelBuilder.Entity("SocialHub.Core.Entities.Gig", b =>
                {
                    b.HasOne("SocialHub.Core.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId");
                });
#pragma warning restore 612, 618
        }
    }
}
