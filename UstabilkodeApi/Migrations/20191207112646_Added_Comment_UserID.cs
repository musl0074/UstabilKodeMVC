using Microsoft.EntityFrameworkCore.Migrations;

namespace UstabilkodeApi.Migrations
{
    public partial class Added_Comment_UserID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Comment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Comment");
        }
    }
}
