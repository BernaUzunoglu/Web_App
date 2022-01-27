using Microsoft.EntityFrameworkCore.Migrations;

namespace ItServiceApp.Migrations
{
    public partial class kolonisimgüncelleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PotstCode",
                table: "Addresses",
                newName: "PostCode");

            migrationBuilder.RenameColumn(
                name: "AdressTypes",
                table: "Addresses",
                newName: "AddressTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostCode",
                table: "Addresses",
                newName: "PotstCode");

            migrationBuilder.RenameColumn(
                name: "AddressTypes",
                table: "Addresses",
                newName: "AdressTypes");
        }
    }
}
