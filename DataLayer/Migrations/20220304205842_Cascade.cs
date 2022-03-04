using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class Cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cli_Client_Address_Cli_Client_ClientId",
                table: "Cli_Client_Address");

            migrationBuilder.AddForeignKey(
                name: "FK_Cli_Client_Address_Cli_Client_ClientId",
                table: "Cli_Client_Address",
                column: "ClientId",
                principalTable: "Cli_Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cli_Client_Address_Cli_Client_ClientId",
                table: "Cli_Client_Address");

            migrationBuilder.AddForeignKey(
                name: "FK_Cli_Client_Address_Cli_Client_ClientId",
                table: "Cli_Client_Address",
                column: "ClientId",
                principalTable: "Cli_Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
