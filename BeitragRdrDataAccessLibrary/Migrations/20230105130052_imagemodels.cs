using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeitragRdrDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class imagemodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_beitragFaces_Images_ImageId",
                table: "beitragFaces");

            migrationBuilder.DropForeignKey(
                name: "FK_beitragInstas_Images_ImageId",
                table: "beitragInstas");

            migrationBuilder.DropForeignKey(
                name: "FK_beitragPintrs_Images_ImageId",
                table: "beitragPintrs");

            migrationBuilder.DropForeignKey(
                name: "FK_BeitragTags_Tags_TagId",
                table: "BeitragTags");

            migrationBuilder.DropIndex(
                name: "IX_beitragPintrs_ImageId",
                table: "beitragPintrs");

            migrationBuilder.DropIndex(
                name: "IX_beitragInstas_ImageId",
                table: "beitragInstas");

            migrationBuilder.DropIndex(
                name: "IX_beitragFaces_ImageId",
                table: "beitragFaces");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "beitragPintrs",
                newName: "ImageModelPinteresId");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "beitragInstas",
                newName: "ImageModelInstagramId");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "beitragFaces",
                newName: "ImageModelFacebookId");

            migrationBuilder.AddColumn<int>(
                name: "BeitragFaceId",
                table: "Images",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BeitragInstaId",
                table: "Images",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BeitragPintrId",
                table: "Images",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Images",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TagsId",
                table: "BeitragTags",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Images_BeitragFaceId",
                table: "Images",
                column: "BeitragFaceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_BeitragInstaId",
                table: "Images",
                column: "BeitragInstaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_BeitragPintrId",
                table: "Images",
                column: "BeitragPintrId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BeitragTags_TagsId",
                table: "BeitragTags",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeitragTags_Tags_TagsId",
                table: "BeitragTags",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_beitragFaces_BeitragFaceId",
                table: "Images",
                column: "BeitragFaceId",
                principalTable: "beitragFaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_beitragInstas_BeitragInstaId",
                table: "Images",
                column: "BeitragInstaId",
                principalTable: "beitragInstas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_beitragPintrs_BeitragPintrId",
                table: "Images",
                column: "BeitragPintrId",
                principalTable: "beitragPintrs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeitragTags_Tags_TagsId",
                table: "BeitragTags");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_beitragFaces_BeitragFaceId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_beitragInstas_BeitragInstaId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_beitragPintrs_BeitragPintrId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_BeitragFaceId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_BeitragInstaId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_BeitragPintrId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_BeitragTags_TagsId",
                table: "BeitragTags");

            migrationBuilder.DropColumn(
                name: "BeitragFaceId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "BeitragInstaId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "BeitragPintrId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "TagsId",
                table: "BeitragTags");

            migrationBuilder.RenameColumn(
                name: "ImageModelPinteresId",
                table: "beitragPintrs",
                newName: "ImageId");

            migrationBuilder.RenameColumn(
                name: "ImageModelInstagramId",
                table: "beitragInstas",
                newName: "ImageId");

            migrationBuilder.RenameColumn(
                name: "ImageModelFacebookId",
                table: "beitragFaces",
                newName: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_beitragPintrs_ImageId",
                table: "beitragPintrs",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_beitragInstas_ImageId",
                table: "beitragInstas",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_beitragFaces_ImageId",
                table: "beitragFaces",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_beitragFaces_Images_ImageId",
                table: "beitragFaces",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_beitragInstas_Images_ImageId",
                table: "beitragInstas",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_beitragPintrs_Images_ImageId",
                table: "beitragPintrs",
                column: "ImageId",
                principalTable: "Images",
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
    }
}
