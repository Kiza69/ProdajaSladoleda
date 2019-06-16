using Microsoft.EntityFrameworkCore.Migrations;

namespace ProdajaSladoleda.DataAccess.Migrations
{
    public partial class ActiveAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "OrderDetails",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "OrderDetails");
        }
    }
}
