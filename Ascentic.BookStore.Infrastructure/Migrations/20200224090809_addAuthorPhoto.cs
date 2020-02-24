using Microsoft.EntityFrameworkCore.Migrations;

namespace Ascentic.BookStore.Infrastructure.Migrations
{
    public partial class addAuthorPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "Author",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "Author");
        }
    }
}
