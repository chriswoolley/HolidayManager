using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HolidayWeb.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Event");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Event",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_UserId",
                table: "Event",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_AspNetUsers_UserId",
                table: "Event",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_AspNetUsers_UserId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_UserId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Event");

            migrationBuilder.AddColumn<float>(
                name: "Duration",
                table: "Event",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
