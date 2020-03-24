using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialDemo.Migrations
{
    public partial class Authorization2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Comments",
                nullable: true);
        }
    }
}
