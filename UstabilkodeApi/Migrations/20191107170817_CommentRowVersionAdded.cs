﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UstabilkodeApi.Migrations
{
    public partial class CommentRowVersionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Comment",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Comment");
        }
    }
}
