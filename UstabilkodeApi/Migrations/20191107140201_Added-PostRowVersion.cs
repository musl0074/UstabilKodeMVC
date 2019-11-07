using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UstabilkodeApi.Migrations
{
    public partial class AddedPostRowVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Post",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostID",
                table: "Comment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostID",
                table: "Comment",
                column: "PostID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_PostID",
                table: "Comment",
                column: "PostID",
                principalTable: "Post",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Post_PostID",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_PostID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "PostID",
                table: "Comment");
        }
    }
}
