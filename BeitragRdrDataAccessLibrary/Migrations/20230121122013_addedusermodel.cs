using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeitragRdrDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class addedusermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Beitrags",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ObjectIdentifier = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beitrags_userId",
                table: "Beitrags",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beitrags_users_userId",
                table: "Beitrags",
                column: "userId",
                principalTable: "users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beitrags_users_userId",
                table: "Beitrags");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropIndex(
                name: "IX_Beitrags_userId",
                table: "Beitrags");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Beitrags");
        }
    }
}
