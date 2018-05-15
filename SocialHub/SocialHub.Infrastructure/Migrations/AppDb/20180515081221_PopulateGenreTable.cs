using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SocialHub.Infrastructure.Migrations.AppDb
{
    public partial class PopulateGenreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT Genres ON");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Jazz')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Blues')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Rock')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Country')");
            migrationBuilder.Sql("SET IDENTITY_INSERT Genres OFF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Genres WHERE Id IN (1, 2, 3, 4)");
        }
    }
}
