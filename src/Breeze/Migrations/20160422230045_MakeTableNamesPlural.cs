using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace breeze.Migrations
{
    public partial class MakeTableNamesPlural : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Comment_Game_GameId", table: "Comments");
            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Game_GameId",
                table: "Comments",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Comment_Game_GameId", table: "Comments");
            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Game_GameId",
                table: "Comments",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
