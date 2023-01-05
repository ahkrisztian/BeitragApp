using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeitragRdrDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class tagslist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeitragTags_Beitrags_BeitragsId",
                table: "BeitragTags");

            migrationBuilder.DropForeignKey(
                name: "FK_BeitragTags_Tags_tagsId",
                table: "BeitragTags");

            migrationBuilder.RenameColumn(
                name: "tagsId",
                table: "BeitragTags",
                newName: "BeitragId");

            migrationBuilder.RenameColumn(
                name: "BeitragsId",
                table: "BeitragTags",
                newName: "TagId");

            migrationBuilder.RenameIndex(
                name: "IX_BeitragTags_tagsId",
                table: "BeitragTags",
                newName: "IX_BeitragTags_BeitragId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeitragTags_Beitrags_BeitragId",
                table: "BeitragTags",
                column: "BeitragId",
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
                name: "FK_BeitragTags_Beitrags_BeitragId",
                table: "BeitragTags");

            migrationBuilder.DropForeignKey(
                name: "FK_BeitragTags_Tags_TagId",
                table: "BeitragTags");

            migrationBuilder.RenameColumn(
                name: "BeitragId",
                table: "BeitragTags",
                newName: "tagsId");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "BeitragTags",
                newName: "BeitragsId");

            migrationBuilder.RenameIndex(
                name: "IX_BeitragTags_BeitragId",
                table: "BeitragTags",
                newName: "IX_BeitragTags_tagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeitragTags_Beitrags_BeitragsId",
                table: "BeitragTags",
                column: "BeitragsId",
                principalTable: "Beitrags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BeitragTags_Tags_tagsId",
                table: "BeitragTags",
                column: "tagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
