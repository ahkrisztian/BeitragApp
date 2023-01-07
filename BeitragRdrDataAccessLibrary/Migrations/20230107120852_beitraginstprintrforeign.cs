using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeitragRdrDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class beitraginstprintrforeign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_beitragInstas_Beitrags_Id",
                table: "beitragInstas");

            migrationBuilder.DropForeignKey(
                name: "FK_beitragPintrs_Beitrags_Id",
                table: "beitragPintrs");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "beitragPintrs",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "BeitragRef",
                table: "beitragPintrs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "beitragInstas",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "BeitragRef",
                table: "beitragInstas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_beitragPintrs_BeitragRef",
                table: "beitragPintrs",
                column: "BeitragRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_beitragInstas_BeitragRef",
                table: "beitragInstas",
                column: "BeitragRef",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_beitragInstas_Beitrags_BeitragRef",
                table: "beitragInstas",
                column: "BeitragRef",
                principalTable: "Beitrags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_beitragPintrs_Beitrags_BeitragRef",
                table: "beitragPintrs",
                column: "BeitragRef",
                principalTable: "Beitrags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_beitragInstas_Beitrags_BeitragRef",
                table: "beitragInstas");

            migrationBuilder.DropForeignKey(
                name: "FK_beitragPintrs_Beitrags_BeitragRef",
                table: "beitragPintrs");

            migrationBuilder.DropIndex(
                name: "IX_beitragPintrs_BeitragRef",
                table: "beitragPintrs");

            migrationBuilder.DropIndex(
                name: "IX_beitragInstas_BeitragRef",
                table: "beitragInstas");

            migrationBuilder.DropColumn(
                name: "BeitragRef",
                table: "beitragPintrs");

            migrationBuilder.DropColumn(
                name: "BeitragRef",
                table: "beitragInstas");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "beitragPintrs",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "beitragInstas",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_beitragInstas_Beitrags_Id",
                table: "beitragInstas",
                column: "Id",
                principalTable: "Beitrags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_beitragPintrs_Beitrags_Id",
                table: "beitragPintrs",
                column: "Id",
                principalTable: "Beitrags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
