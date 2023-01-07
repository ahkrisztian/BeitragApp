using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeitragRdrDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class foreignkeybeitragfaceimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_beitragFaces_Beitrags_BeitragFaceId",
                table: "beitragFaces");

            migrationBuilder.DropIndex(
                name: "IX_beitragFaces_BeitragFaceId",
                table: "beitragFaces");

            migrationBuilder.DropColumn(
                name: "BeitragFaceId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "BeitragFaceId",
                table: "beitragFaces",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_beitragFaces_BeitragFaceId",
                table: "beitragFaces",
                column: "BeitragFaceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_beitragFaces_Beitrags_BeitragFaceId",
                table: "beitragFaces",
                column: "BeitragFaceId",
                principalTable: "Beitrags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
