using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopFinder.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    Distric = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RequestMessage",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestsID = table.Column<string>(nullable: true),
                    Messsage = table.Column<string>(nullable: true),
                    MessageType = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestMessage", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShopCatagory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCatagory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Distric",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distric", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Distric_Province_ProvinceID",
                        column: x => x.ProvinceID,
                        principalTable: "Province",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistricID = table.Column<int>(nullable: false),
                    ProvinceID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.ID);
                    table.ForeignKey(
                        name: "FK_City_Distric_DistricID",
                        column: x => x.DistricID,
                        principalTable: "Distric",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    ShopName = table.Column<string>(nullable: true),
                    ShopCatagoryID = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    IsOpen = table.Column<bool>(nullable: false),
                    ConatctPerson = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    CityID = table.Column<int>(nullable: false),
                    GPSLocation = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ContactNo1 = table.Column<int>(nullable: false),
                    ContactNo2 = table.Column<int>(nullable: false),
                    ContactNo3 = table.Column<int>(nullable: false),
                    IsDiliveryAvilabel = table.Column<bool>(nullable: false),
                    IsCreditCardAccept = table.Column<bool>(nullable: false),
                    IsCreditCardAcceptOnDeliveryLocation = table.Column<bool>(nullable: false),
                    OpenTime = table.Column<DateTime>(nullable: false),
                    ClosedTime = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Shop_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shop_ShopCatagory_ShopCatagoryID",
                        column: x => x.ShopCatagoryID,
                        principalTable: "ShopCatagory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleID = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    CityID = table.Column<int>(nullable: false),
                    MobileNo = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_UserRole_UserRoleID",
                        column: x => x.UserRoleID,
                        principalTable: "UserRole",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    ShopID = table.Column<int>(nullable: false),
                    MobileNo = table.Column<int>(nullable: false),
                    RequestStatus = table.Column<string>(nullable: true),
                    RequestMessageID = table.Column<int>(nullable: true),
                    DeliverAddress = table.Column<string>(nullable: true),
                    BuyingItems = table.Column<string>(nullable: true),
                    IsCreditCardRequiredOnDlivery = table.Column<bool>(nullable: false),
                    GPSLocation = table.Column<string>(nullable: true),
                    RequestSendOn = table.Column<DateTime>(nullable: false),
                    RequestAcceptedOn = table.Column<DateTime>(nullable: false),
                    DilveryStarted = table.Column<DateTime>(nullable: false),
                    Dilverd = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Request_RequestMessage_RequestMessageID",
                        column: x => x.RequestMessageID,
                        principalTable: "RequestMessage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Request_Shop_ShopID",
                        column: x => x.ShopID,
                        principalTable: "Shop",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_DistricID",
                table: "City",
                column: "DistricID");

            migrationBuilder.CreateIndex(
                name: "IX_Distric_ProvinceID",
                table: "Distric",
                column: "ProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_Request_RequestMessageID",
                table: "Request",
                column: "RequestMessageID");

            migrationBuilder.CreateIndex(
                name: "IX_Request_ShopID",
                table: "Request",
                column: "ShopID");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_CityID",
                table: "Shop",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_ShopCatagoryID",
                table: "Shop",
                column: "ShopCatagoryID");

            migrationBuilder.CreateIndex(
                name: "IX_User_CityID",
                table: "User",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRoleID",
                table: "User",
                column: "UserRoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "RequestMessage");

            migrationBuilder.DropTable(
                name: "Shop");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "ShopCatagory");

            migrationBuilder.DropTable(
                name: "Distric");

            migrationBuilder.DropTable(
                name: "Province");
        }
    }
}
