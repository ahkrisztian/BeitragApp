using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeitragRdrDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Postdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PostDate",
                table: "Beitrags",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "Beitrags",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostDate",
                table: "Beitrags");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "Beitrags");
        }
    }
}
