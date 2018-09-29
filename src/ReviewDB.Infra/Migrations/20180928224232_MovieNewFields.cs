using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReviewDB.Infra.Migrations
{
    public partial class MovieNewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Movies",
                newName: "OriginalTitle");

            migrationBuilder.AddColumn<bool>(
                name: "Adult",
                table: "Movies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Homepage",
                table: "Movies",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImdbId",
                table: "Movies",
                maxLength: 12,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Overview",
                table: "Movies",
                maxLength: 1500,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Popularity",
                table: "Movies",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TmdbId",
                table: "Movies",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adult",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Homepage",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ImdbId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Overview",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Popularity",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "TmdbId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "OriginalTitle",
                table: "Movies",
                newName: "Title");
        }
    }
}
