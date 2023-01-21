using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeitragRdrDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class addedphoneusercompenymodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beitrags_users_userId",
                table: "Beitrags");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "users",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "Beitrags",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Beitrags",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Beitrags",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Beitrags",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Beitrags",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserId",
                table: "Beitrags",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddressModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Country = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressModel_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumberModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumberModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumberModel_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beitrags_CompanyId",
                table: "Beitrags",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressModel_CompanyId",
                table: "AddressModel",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_UserId",
                table: "Company",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumberModel_CompanyId",
                table: "PhoneNumberModel",
                column: "CompanyId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beitrags_Company_CompanyId",
                table: "Beitrags");

            migrationBuilder.DropForeignKey(
                name: "FK_Beitrags_users_userId",
                table: "Beitrags");

            migrationBuilder.DropTable(
                name: "AddressModel");

            migrationBuilder.DropTable(
                name: "PhoneNumberModel");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Beitrags_CompanyId",
                table: "Beitrags");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Beitrags");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Beitrags");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Beitrags");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Beitrags");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserId",
                table: "Beitrags");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "users",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Beitrags",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Beitrags_users_userId",
                table: "Beitrags",
                column: "userId",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
