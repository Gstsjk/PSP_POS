using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSP_PoS.Migrations
{
    /// <inheritdoc />
    public partial class addedNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Discounts_DiscountId",
                table: "Items");

            migrationBuilder.AlterColumn<Guid>(
                name: "DiscountId",
                table: "Items",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Discounts_DiscountId",
                table: "Items",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Discounts_DiscountId",
                table: "Items");

            migrationBuilder.AlterColumn<Guid>(
                name: "DiscountId",
                table: "Items",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Discounts_DiscountId",
                table: "Items",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
