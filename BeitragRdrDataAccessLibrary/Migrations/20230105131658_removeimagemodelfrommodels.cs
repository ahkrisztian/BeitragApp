using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeitragRdrDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class removeimagemodelfrommodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageModelFacebook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    base64data = table.Column<string>(type: "TEXT", nullable: false),
                    BeitragFaceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageModelFacebook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageModelFacebook_beitragFaces_BeitragFaceId",
                        column: x => x.BeitragFaceId,
                        principalTable: "beitragFaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageModelInstagram",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    base64data = table.Column<string>(type: "TEXT", nullable: false),
                    BeitragInstaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageModelInstagram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageModelInstagram_beitragInstas_BeitragInstaId",
                        column: x => x.BeitragInstaId,
                        principalTable: "beitragInstas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageModelFacebook_BeitragFaceId",
                table: "ImageModelFacebook",
                column: "BeitragFaceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageModelInstagram_BeitragInstaId",
                table: "ImageModelInstagram",
                column: "BeitragInstaId",
                unique: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropTable(
                name: "ImageModelFacebook");

            migrationBuilder.DropTable(
                name: "ImageModelInstagram");

        }
    }
}
