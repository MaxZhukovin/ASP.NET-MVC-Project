using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperShop.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "img1",
                table: "CarDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "img2",
                table: "CarDetails",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "car",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img1",
                table: "CarDetails");

            migrationBuilder.DropColumn(
                name: "img2",
                table: "CarDetails");

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "car",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
