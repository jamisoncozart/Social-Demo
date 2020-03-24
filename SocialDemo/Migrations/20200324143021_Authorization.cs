using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialDemo.Migrations
{
    public partial class Authorization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Posts",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Posts",
                newName: "Author");

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
