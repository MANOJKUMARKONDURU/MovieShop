using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MovieCasts",
                keyColumns: new[] { "CastId", "Character", "MovieId" },
                keyValues: new object[] { 1, "Cobb", 1 });

            migrationBuilder.DeleteData(
                table: "MovieCasts",
                keyColumns: new[] { "CastId", "Character", "MovieId" },
                keyValues: new object[] { 2, "Batman", 2 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Casts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Casts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "BackdropUrl",
                table: "Movies",
                type: "nvarchar(2084)",
                maxLength: 2084,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                table: "Movies",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImdbUrl",
                table: "Movies",
                type: "nvarchar(2084)",
                maxLength: 2084,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OriginalLanguage",
                table: "Movies",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RunTime",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tagline",
                table: "Movies",
                type: "nvarchar(2084)",
                maxLength: 2084,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TmdbUrl",
                table: "Movies",
                type: "nvarchar(2084)",
                maxLength: 2084,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackdropUrl",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ImdbUrl",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "OriginalLanguage",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "RunTime",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Tagline",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "TmdbUrl",
                table: "Movies");

            migrationBuilder.InsertData(
                table: "Casts",
                columns: new[] { "Id", "Name", "ProfilePath" },
                values: new object[,]
                {
                    { 1, "Leonardo DiCaprio", "/images/cast/leo.jpg" },
                    { 2, "Christian Bale", "/images/cast/bale.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Drama" },
                    { 3, "Comedy" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Overview", "PosterUrl", "Revenue", "Title" },
                values: new object[,]
                {
                    { 1, "A thief who steals corporate secrets through dream-sharing technology.", "/images/inception.jpg", 825532764m, "Inception" },
                    { 2, "Batman faces the Joker in Gotham City.", "/images/darkknight.jpg", 1004558444m, "The Dark Knight" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "HashedPassword", "Salt" },
                values: new object[] { 1, "test@example.com", "password", "" });

            migrationBuilder.InsertData(
                table: "MovieCasts",
                columns: new[] { "CastId", "Character", "MovieId" },
                values: new object[,]
                {
                    { 1, "Cobb", 1 },
                    { 2, "Batman", 2 }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });
        }
    }
}
