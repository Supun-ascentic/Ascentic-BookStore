using Microsoft.EntityFrameworkCore.Migrations;

namespace Ascentic.BookStore.Infrastructure.Migrations
{
    public partial class photoUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "Book",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "Book");
        }
    }
}
