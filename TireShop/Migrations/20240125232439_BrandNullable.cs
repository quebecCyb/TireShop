using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TireShop.Migrations
{
    /// <inheritdoc />
    public partial class BrandNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tires_Brands_BrandId",
                table: "Tires");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Tires",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tires_Brands_BrandId",
                table: "Tires",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tires_Brands_BrandId",
                table: "Tires");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Tires",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tires_Brands_BrandId",
                table: "Tires",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
