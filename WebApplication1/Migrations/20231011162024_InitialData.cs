using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "advisior",
                columns: table => new
                {
                    advisiorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    advisiorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_advisior", x => x.advisiorID);
                    table.ForeignKey(
                        name: "FK_advisior_advisior_advisiorId",
                        column: x => x.advisiorId,
                        principalTable: "advisior",
                        principalColumn: "advisiorID");
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                   customerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customerID);
                    table.ForeignKey(
                        name: "FK_customers_customers_customerId",
                        column: x => x.customerId,
                        principalTable: "customers",
                        principalColumn: "customerID");
                });

            migrationBuilder.InsertData(
                table: "advisior",
                columns: new[] { "advisiorID", "Address", "advisiorId", "Country", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("4d490a70-94ce-4d15-9494-5248280c2ce3"), "Saransk, Veselovskogo20k1", null, "Russia", "Stas", "86743643904" },
                    { new Guid("c2d4c053-49b6-410c-bc78-2d54a9991870"), "Saransk, Veselovskogo20k2", null, "Russia", "Nikita", "89530309776" }
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "customerID", "Address", "customerId", "Name", "Number", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d45-9494-5248280c2ce3"), "Saransk, Nevskogo 113", null, "Genadiy", "2", "82002769076" },
                    { new Guid("c9d4c053-49b6-430c-bc78-2d54a9991870"), "Saransk, Nevskogo 11", null, "Andrey", "1", "85882507000" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_advisiors_advisiorId",
                table: "advisiors",
                column: "advisiorId");

            migrationBuilder.CreateIndex(
                name: "IX_customers_customerId",
                table: "customers",
                column: "customerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "advisiors");

            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}
