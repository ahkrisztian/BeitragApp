using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeitragRdrDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class removebedidfieldimagemodels2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeitragTags_Tags_TagId",
                table: "BeitragTags");

            migrationBuilder.AddColumn<int>(
                name: "TagsId",
                table: "BeitragTags",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeitragTags_Tags_TagsId",
                table: "BeitragTags");

            migrationBuilder.DropIndex(
                name: "IX_BeitragTags_TagsId",
                table: "BeitragTags");

            migrationBuilder.DropColumn(
                name: "TagsId",
                table: "BeitragTags");

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
