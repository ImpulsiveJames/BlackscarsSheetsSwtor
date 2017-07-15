using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Telvee32.BlackscarsSheetsSwtor.UI.Data.Migrations
{
    public partial class RemoveCyclicReferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Characters_AttributeId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_SkillId",
                table: "Characters");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AttributeId",
                table: "Characters",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SkillId",
                table: "Characters",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Characters_AttributeId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_SkillId",
                table: "Characters");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AttributeId",
                table: "Characters",
                column: "AttributeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SkillId",
                table: "Characters",
                column: "SkillId",
                unique: true);
        }
    }
}
