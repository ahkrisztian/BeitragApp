using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeitragRdrDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class tagslistbeitrag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Beitrags_BeitragId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_BeitragId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "BeitragId",
                table: "Tags");

            migrationBuilder.CreateTable(
                name: "BeitragTags",
                columns: table => new
                {
                    BeitragsId = table.Column<int>(type: "INTEGER", nullable: false),
                    tagsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeitragTags", x => new { x.BeitragsId, x.tagsId });
                    table.ForeignKey(
                        name: "FK_BeitragTags_Beitrags_BeitragsId",
                        column: x => x.BeitragsId,
                        principalTable: "Beitrags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeitragTags_Tags_tagsId",
                        column: x => x.tagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeitragTags_tagsId",
                table: "BeitragTags",
                column: "tagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeitragTags");

            migrationBuilder.AddColumn<int>(
                name: "BeitragId",
                table: "Tags",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_BeitragId",
                table: "Tags",
                column: "BeitragId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Beitrags_BeitragId",
                table: "Tags",
                column: "BeitragId",
                principalTable: "Beitrags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
