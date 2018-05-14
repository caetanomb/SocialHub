using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SocialHub.Infrastructure.Migrations.AppDb
{
    public partial class GigAndGenreEntityOverrideV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ArtistId",
                table: "Gigs",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ArtistId",
                table: "Gigs",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 450);
        }
    }
}
