using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Telvee32.BlackscarsSheetsSwtor.UI.Data.Migrations
{
    public partial class CharacterUserFKv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "Character");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AspNetUserId",
                table: "Character",
                nullable: true);
        }
    }
}
