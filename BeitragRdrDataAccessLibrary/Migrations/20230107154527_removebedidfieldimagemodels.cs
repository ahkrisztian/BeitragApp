using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeitragRdrDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class removebedidfieldimagemodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageModelFacebook_beitragFaces_BeitragFaceId",
                table: "ImageModelFacebook");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageModelInstagram_beitragInstas_BeitragInstaId",
                table: "ImageModelInstagram");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageModelPintr_beitragPintrs_BeitragPintrId",
                table: "ImageModelPintr");

            migrationBuilder.DropIndex(
                name: "IX_ImageModelPintr_BeitragPintrId",
                table: "ImageModelPintr");

            migrationBuilder.DropIndex(
                name: "IX_ImageModelInstagram_BeitragInstaId",
                table: "ImageModelInstagram");

            migrationBuilder.DropIndex(
                name: "IX_ImageModelFacebook_BeitragFaceId",
                table: "ImageModelFacebook");

            migrationBuilder.DropColumn(
                name: "BeitragPintrId",
                table: "ImageModelPintr");

            migrationBuilder.DropColumn(
                name: "BeitragInstaId",
                table: "ImageModelInstagram");

            migrationBuilder.DropColumn(
                name: "BeitragFaceId",
                table: "ImageModelFacebook");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ImageModelPintr",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ImageModelInstagram",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ImageModelFacebook",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageModelFacebook_beitragFaces_Id",
                table: "ImageModelFacebook",
                column: "Id",
                principalTable: "beitragFaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageModelInstagram_beitragInstas_Id",
                table: "ImageModelInstagram",
                column: "Id",
                principalTable: "beitragInstas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageModelPintr_beitragPintrs_Id",
                table: "ImageModelPintr",
                column: "Id",
                principalTable: "beitragPintrs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageModelFacebook_beitragFaces_Id",
                table: "ImageModelFacebook");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageModelInstagram_beitragInstas_Id",
                table: "ImageModelInstagram");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageModelPintr_beitragPintrs_Id",
                table: "ImageModelPintr");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ImageModelPintr",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "BeitragPintrId",
                table: "ImageModelPintr",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ImageModelInstagram",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "BeitragInstaId",
                table: "ImageModelInstagram",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ImageModelFacebook",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "BeitragFaceId",
                table: "ImageModelFacebook",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ImageModelPintr_BeitragPintrId",
                table: "ImageModelPintr",
                column: "BeitragPintrId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageModelInstagram_BeitragInstaId",
                table: "ImageModelInstagram",
                column: "BeitragInstaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageModelFacebook_BeitragFaceId",
                table: "ImageModelFacebook",
                column: "BeitragFaceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageModelFacebook_beitragFaces_BeitragFaceId",
                table: "ImageModelFacebook",
                column: "BeitragFaceId",
                principalTable: "beitragFaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageModelInstagram_beitragInstas_BeitragInstaId",
                table: "ImageModelInstagram",
                column: "BeitragInstaId",
                principalTable: "beitragInstas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageModelPintr_beitragPintrs_BeitragPintrId",
                table: "ImageModelPintr",
                column: "BeitragPintrId",
                principalTable: "beitragPintrs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
