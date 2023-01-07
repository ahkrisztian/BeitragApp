using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeitragRdrDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class foreignkeybeitragface : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beitrags_beitragFaces_beitragFaceId",
                table: "Beitrags");

            migrationBuilder.DropForeignKey(
                name: "FK_BeitragTags_Tags_TagsId",
                table: "BeitragTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageModelPintr_beitragPintrs_BeitragPintrId",
                table: "ImageModelPintr");

            migrationBuilder.DropIndex(
                name: "IX_BeitragTags_TagsId",
                table: "BeitragTags");

            migrationBuilder.DropIndex(
                name: "IX_Beitrags_beitragFaceId",
                table: "Beitrags");


            migrationBuilder.DropColumn(
                name: "TagsId",
                table: "BeitragTags");

            migrationBuilder.DropColumn(
                name: "beitragFaceId",
                table: "Beitrags");


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

            migrationBuilder.AddForeignKey(
                name: "FK_BeitragTags_Tags_TagId",
                table: "BeitragTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_beitragFaces_Beitrags_BeitragFaceId",
                table: "beitragFaces");

            migrationBuilder.DropForeignKey(
                name: "FK_BeitragTags_Tags_TagId",
                table: "BeitragTags");

            migrationBuilder.DropIndex(
                name: "IX_beitragFaces_BeitragFaceId",
                table: "beitragFaces");

            migrationBuilder.DropColumn(
                name: "BeitragFaceId",
                table: "beitragFaces");


            migrationBuilder.AddColumn<int>(
                name: "TagsId",
                table: "BeitragTags",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "beitragFaceId",
                table: "Beitrags",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BeitragTags_TagsId",
                table: "BeitragTags",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Beitrags_beitragFaceId",
                table: "Beitrags",
                column: "beitragFaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beitrags_beitragFaces_beitragFaceId",
                table: "Beitrags",
                column: "beitragFaceId",
                principalTable: "beitragFaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BeitragTags_Tags_TagsId",
                table: "BeitragTags",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
