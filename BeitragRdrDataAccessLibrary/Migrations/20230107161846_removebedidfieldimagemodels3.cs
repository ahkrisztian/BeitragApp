using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeitragRdrDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class removebedidfieldimagemodels3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeitragTags_Beitrags_BeitragId",
                table: "BeitragTags");

            migrationBuilder.DropForeignKey(
                name: "FK_BeitragTags_Tags_TagsId",
                table: "BeitragTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BeitragTags",
                table: "BeitragTags");

            migrationBuilder.DropIndex(
                name: "IX_BeitragTags_BeitragId",
                table: "BeitragTags");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "BeitragTags");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "BeitragTags",
                newName: "tagsId");

            migrationBuilder.RenameColumn(
                name: "BeitragId",
                table: "BeitragTags",
                newName: "BeitragsId");

            migrationBuilder.RenameIndex(
                name: "IX_BeitragTags_TagsId",
                table: "BeitragTags",
                newName: "IX_BeitragTags_tagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BeitragTags",
                table: "BeitragTags",
                columns: new[] { "BeitragsId", "tagsId" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeitragTags_Beitrags_BeitragsId",
                table: "BeitragTags");

            migrationBuilder.DropForeignKey(
                name: "FK_BeitragTags_Tags_tagsId",
                table: "BeitragTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BeitragTags",
                table: "BeitragTags");

            migrationBuilder.RenameColumn(
                name: "tagsId",
                table: "BeitragTags",
                newName: "TagsId");

            migrationBuilder.RenameColumn(
                name: "BeitragsId",
                table: "BeitragTags",
                newName: "BeitragId");

            migrationBuilder.RenameIndex(
                name: "IX_BeitragTags_tagsId",
                table: "BeitragTags",
                newName: "IX_BeitragTags_TagsId");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "BeitragTags",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BeitragTags",
                table: "BeitragTags",
                columns: new[] { "TagId", "BeitragId" });

            migrationBuilder.CreateIndex(
                name: "IX_BeitragTags_BeitragId",
                table: "BeitragTags",
                column: "BeitragId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeitragTags_Beitrags_BeitragId",
                table: "BeitragTags",
                column: "BeitragId",
                principalTable: "Beitrags",
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
