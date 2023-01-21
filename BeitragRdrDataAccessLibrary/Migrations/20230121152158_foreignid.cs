using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeitragRdrDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class foreignid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beitrags_companies_companyId",
                table: "Beitrags");

            migrationBuilder.RenameColumn(
                name: "companyId",
                table: "Beitrags",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Beitrags_companyId",
                table: "Beitrags",
                newName: "IX_Beitrags_CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beitrags_companies_CompanyId",
                table: "Beitrags",
                column: "CompanyId",
                principalTable: "companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beitrags_companies_CompanyId",
                table: "Beitrags");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Beitrags",
                newName: "companyId");

            migrationBuilder.RenameIndex(
                name: "IX_Beitrags_CompanyId",
                table: "Beitrags",
                newName: "IX_Beitrags_companyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beitrags_companies_companyId",
                table: "Beitrags",
                column: "companyId",
                principalTable: "companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
