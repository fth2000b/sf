using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopFinder.Migrations
{
    public partial class Shop3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopCatagoryID",
                table: "Shop",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shop_ShopCatagoryID",
                table: "Shop",
                column: "ShopCatagoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_ShopCatagory_ShopCatagoryID",
                table: "Shop",
                column: "ShopCatagoryID",
                principalTable: "ShopCatagory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shop_ShopCatagory_ShopCatagoryID",
                table: "Shop");

            migrationBuilder.DropIndex(
                name: "IX_Shop_ShopCatagoryID",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "ShopCatagoryID",
                table: "Shop");
        }
    }
}
