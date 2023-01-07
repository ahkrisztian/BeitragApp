using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeitragRdrDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class optforeignkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beitrags_beitragInstas_beitragInstaId",
                table: "Beitrags");

            migrationBuilder.DropForeignKey(
                name: "FK_Beitrags_beitragPintrs_beitragPintrId",
                table: "Beitrags");

            migrationBuilder.DropIndex(
                name: "IX_Beitrags_beitragInstaId",
                table: "Beitrags");

            migrationBuilder.DropIndex(
                name: "IX_Beitrags_beitragPintrId",
                table: "Beitrags");

            migrationBuilder.DropColumn(
                name: "beitragInstaId",
                table: "Beitrags");

            migrationBuilder.DropColumn(
                name: "beitragPintrId",
                table: "Beitrags");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_beitragInstas_Beitrags_Id",
                table: "beitragInstas");

            migrationBuilder.DropForeignKey(
                name: "FK_beitragPintrs_Beitrags_Id",
                table: "beitragPintrs");

            migrationBuilder.AddColumn<int>(
                name: "beitragInstaId",
                table: "Beitrags",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "beitragPintrId",
                table: "Beitrags",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "beitragPintrs",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "beitragInstas",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_Beitrags_beitragInstaId",
                table: "Beitrags",
                column: "beitragInstaId");

            migrationBuilder.CreateIndex(
                name: "IX_Beitrags_beitragPintrId",
                table: "Beitrags",
                column: "beitragPintrId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beitrags_beitragInstas_beitragInstaId",
                table: "Beitrags",
                column: "beitragInstaId",
                principalTable: "beitragInstas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Beitrags_beitragPintrs_beitragPintrId",
                table: "Beitrags",
                column: "beitragPintrId",
                principalTable: "beitragPintrs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
