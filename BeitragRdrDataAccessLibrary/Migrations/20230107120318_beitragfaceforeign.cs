using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeitragRdrDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class beitragfaceforeign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_beitragFaces_Beitrags_Id",
                table: "beitragFaces");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "beitragFaces",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "BeitragRef",
                table: "beitragFaces",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_beitragFaces_BeitragRef",
                table: "beitragFaces",
                column: "BeitragRef",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_beitragFaces_Beitrags_BeitragRef",
                table: "beitragFaces",
                column: "BeitragRef",
                principalTable: "Beitrags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_beitragFaces_Beitrags_BeitragRef",
                table: "beitragFaces");

            migrationBuilder.DropIndex(
                name: "IX_beitragFaces_BeitragRef",
                table: "beitragFaces");

            migrationBuilder.DropColumn(
                name: "BeitragRef",
                table: "beitragFaces");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "beitragFaces",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_beitragFaces_Beitrags_Id",
                table: "beitragFaces",
                column: "Id",
                principalTable: "Beitrags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
