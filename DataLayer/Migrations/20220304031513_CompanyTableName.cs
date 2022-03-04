using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class CompanyTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cli_Client_Comapnies_CompanyId",
                table: "Cli_Client");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientAddress_Cli_Client_ClientId",
                table: "ClientAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Usr_User_Comapnies_CompanyId",
                table: "Usr_User");

            migrationBuilder.DropTable(
                name: "Comapnies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientAddress",
                table: "ClientAddress");

            migrationBuilder.RenameTable(
                name: "ClientAddress",
                newName: "Cli_Client_Address");

            migrationBuilder.RenameIndex(
                name: "IX_ClientAddress_ClientId",
                table: "Cli_Client_Address",
                newName: "IX_Cli_Client_Address_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cli_Client_Address",
                table: "Cli_Client_Address",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Sis_Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sis_Company", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cli_Client_Sis_Company_CompanyId",
                table: "Cli_Client",
                column: "CompanyId",
                principalTable: "Sis_Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cli_Client_Address_Cli_Client_ClientId",
                table: "Cli_Client_Address",
                column: "ClientId",
                principalTable: "Cli_Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usr_User_Sis_Company_CompanyId",
                table: "Usr_User",
                column: "CompanyId",
                principalTable: "Sis_Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cli_Client_Sis_Company_CompanyId",
                table: "Cli_Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Cli_Client_Address_Cli_Client_ClientId",
                table: "Cli_Client_Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Usr_User_Sis_Company_CompanyId",
                table: "Usr_User");

            migrationBuilder.DropTable(
                name: "Sis_Company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cli_Client_Address",
                table: "Cli_Client_Address");

            migrationBuilder.RenameTable(
                name: "Cli_Client_Address",
                newName: "ClientAddress");

            migrationBuilder.RenameIndex(
                name: "IX_Cli_Client_Address_ClientId",
                table: "ClientAddress",
                newName: "IX_ClientAddress_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientAddress",
                table: "ClientAddress",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Comapnies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comapnies", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cli_Client_Comapnies_CompanyId",
                table: "Cli_Client",
                column: "CompanyId",
                principalTable: "Comapnies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientAddress_Cli_Client_ClientId",
                table: "ClientAddress",
                column: "ClientId",
                principalTable: "Cli_Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usr_User_Comapnies_CompanyId",
                table: "Usr_User",
                column: "CompanyId",
                principalTable: "Comapnies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
