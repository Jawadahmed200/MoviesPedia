﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesPediaDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class GenreUniquness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Genres_Name",
                table: "Genres");
        }
    }
}
