using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodingTest.EFCore.Migrations
{
    public partial class Dta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentStates",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStates", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditCardNumber = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    CardHolder = table.Column<string>(nullable: true),
                    SecurityCode = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Status_ID = table.Column<int>(nullable: false),
                    PaymentStateID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentStates_PaymentStateID",
                        column: x => x.PaymentStateID,
                        principalTable: "PaymentStates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PaymentStates",
                columns: new[] { "ID", "Status" },
                values: new object[] { 1, "Completed" });

            migrationBuilder.InsertData(
                table: "PaymentStates",
                columns: new[] { "ID", "Status" },
                values: new object[] { 2, "Pending" });

            migrationBuilder.InsertData(
                table: "PaymentStates",
                columns: new[] { "ID", "Status" },
                values: new object[] { 3, "Failed" });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentStateID",
                table: "Payments",
                column: "PaymentStateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PaymentStates");
        }
    }
}
