using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeitragRdrDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class enums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BeitragStatus",
                table: "Beitrags",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeitragStatus",
                table: "Beitrags");
        }
    }
}
