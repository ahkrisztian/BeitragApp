using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeitragRdrDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class removebeitragsfromuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beitrags_users_UserId",
                table: "Beitrags");

            migrationBuilder.DropIndex(
                name: "IX_Beitrags_UserId",
                table: "Beitrags");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Beitrags");

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedUserId",
                table: "Beitrags",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                table: "Beitrags",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedUserId",
                table: "Beitrags",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                table: "Beitrags",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Beitrags",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beitrags_UserId",
                table: "Beitrags",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beitrags_users_UserId",
                table: "Beitrags",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
