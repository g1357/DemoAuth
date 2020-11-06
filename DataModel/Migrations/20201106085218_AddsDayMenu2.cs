using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataModel.Migrations
{
    public partial class AddsDayMenu2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayMenuId",
                table: "Dishes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DayMenus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayMenus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_DayMenuId",
                table: "Dishes",
                column: "DayMenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_DayMenus_DayMenuId",
                table: "Dishes",
                column: "DayMenuId",
                principalTable: "DayMenus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_DayMenus_DayMenuId",
                table: "Dishes");

            migrationBuilder.DropTable(
                name: "DayMenus");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_DayMenuId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "DayMenuId",
                table: "Dishes");
        }
    }
}
