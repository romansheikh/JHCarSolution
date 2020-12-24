using Microsoft.EntityFrameworkCore.Migrations;

namespace JHCarCenter.Migrations
{
    public partial class inittwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeliverd",
                table: "Sales",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeliverd",
                table: "Sales");
        }
    }
}
