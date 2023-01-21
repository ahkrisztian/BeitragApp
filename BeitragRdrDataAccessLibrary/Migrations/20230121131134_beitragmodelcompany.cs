using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeitragRdrDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class beitragmodelcompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressModel_Company_CompanyId",
                table: "AddressModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Beitrags_Company_CompanyId",
                table: "Beitrags");

            migrationBuilder.DropForeignKey(
                name: "FK_Beitrags_users_userId",
                table: "Beitrags");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_users_UserId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumberModel_Company_CompanyId",
                table: "PhoneNumberModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneNumberModel",
                table: "PhoneNumberModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressModel",
                table: "AddressModel");

            migrationBuilder.RenameTable(
                name: "PhoneNumberModel",
                newName: "phoneNumbers");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "companies");

            migrationBuilder.RenameTable(
                name: "AddressModel",
                newName: "addresses");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Beitrags",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Beitrags",
                newName: "companyId");

            migrationBuilder.RenameIndex(
                name: "IX_Beitrags_userId",
                table: "Beitrags",
                newName: "IX_Beitrags_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Beitrags_CompanyId",
                table: "Beitrags",
                newName: "IX_Beitrags_companyId");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneNumberModel_CompanyId",
                table: "phoneNumbers",
                newName: "IX_phoneNumbers_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Company_UserId",
                table: "companies",
                newName: "IX_companies_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AddressModel_CompanyId",
                table: "addresses",
                newName: "IX_addresses_CompanyId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Beitrags",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "companyId",
                table: "Beitrags",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_phoneNumbers",
                table: "phoneNumbers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_companies",
                table: "companies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_addresses",
                table: "addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_addresses_companies_CompanyId",
                table: "addresses",
                column: "CompanyId",
                principalTable: "companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Beitrags_companies_companyId",
                table: "Beitrags",
                column: "companyId",
                principalTable: "companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Beitrags_users_UserId",
                table: "Beitrags",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_companies_users_UserId",
                table: "companies",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_phoneNumbers_companies_CompanyId",
                table: "phoneNumbers",
                column: "CompanyId",
                principalTable: "companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_addresses_companies_CompanyId",
                table: "addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Beitrags_companies_companyId",
                table: "Beitrags");

            migrationBuilder.DropForeignKey(
                name: "FK_Beitrags_users_UserId",
                table: "Beitrags");

            migrationBuilder.DropForeignKey(
                name: "FK_companies_users_UserId",
                table: "companies");

            migrationBuilder.DropForeignKey(
                name: "FK_phoneNumbers_companies_CompanyId",
                table: "phoneNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_phoneNumbers",
                table: "phoneNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_companies",
                table: "companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_addresses",
                table: "addresses");

            migrationBuilder.RenameTable(
                name: "phoneNumbers",
                newName: "PhoneNumberModel");

            migrationBuilder.RenameTable(
                name: "companies",
                newName: "Company");

            migrationBuilder.RenameTable(
                name: "addresses",
                newName: "AddressModel");

            migrationBuilder.RenameColumn(
                name: "companyId",
                table: "Beitrags",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Beitrags",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Beitrags_UserId",
                table: "Beitrags",
                newName: "IX_Beitrags_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Beitrags_companyId",
                table: "Beitrags",
                newName: "IX_Beitrags_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_phoneNumbers_CompanyId",
                table: "PhoneNumberModel",
                newName: "IX_PhoneNumberModel_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_companies_UserId",
                table: "Company",
                newName: "IX_Company_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_addresses_CompanyId",
                table: "AddressModel",
                newName: "IX_AddressModel_CompanyId");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Beitrags",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "Beitrags",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneNumberModel",
                table: "PhoneNumberModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressModel",
                table: "AddressModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressModel_Company_CompanyId",
                table: "AddressModel",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Beitrags_Company_CompanyId",
                table: "Beitrags",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Beitrags_users_userId",
                table: "Beitrags",
                column: "userId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_users_UserId",
                table: "Company",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumberModel_Company_CompanyId",
                table: "PhoneNumberModel",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
