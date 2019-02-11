using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HolidayWeb.Migrations
{
    public partial class trest335 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "HolidayEntitlements",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayEntitlements_UserId",
                table: "HolidayEntitlements",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HolidayEntitlements_AspNetUsers_UserId",
                table: "HolidayEntitlements",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HolidayEntitlements_AspNetUsers_UserId",
                table: "HolidayEntitlements");

            migrationBuilder.DropIndex(
                name: "IX_HolidayEntitlements_UserId",
                table: "HolidayEntitlements");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HolidayEntitlements");
        }
    }
}
