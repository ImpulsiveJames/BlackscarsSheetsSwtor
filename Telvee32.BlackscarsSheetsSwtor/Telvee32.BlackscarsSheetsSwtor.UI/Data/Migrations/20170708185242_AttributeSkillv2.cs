using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Telvee32.BlackscarsSheetsSwtor.UI.Data.Migrations
{
    public partial class AttributeSkillv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_Characters_FK_Attributes_Characters_Id",
                table: "Attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Characters_FK_Skills_Characters_Id",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_FK_Skills_Characters_Id",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Attributes_FK_Attributes_Characters_Id",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "FK_Skills_Characters_Id",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "FK_Attributes_Characters_Id",
                table: "Attributes");

            migrationBuilder.AddColumn<int>(
                name: "AttributeId",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "Characters",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Attributes_AttributeId",
                table: "Characters",
                column: "AttributeId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Skills_SkillId",
                table: "Characters",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Attributes_AttributeId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Skills_SkillId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_AttributeId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_SkillId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "AttributeId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "Characters");

            migrationBuilder.AddColumn<Guid>(
                name: "FK_Skills_Characters_Id",
                table: "Skills",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FK_Attributes_Characters_Id",
                table: "Attributes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_FK_Skills_Characters_Id",
                table: "Skills",
                column: "FK_Skills_Characters_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_FK_Attributes_Characters_Id",
                table: "Attributes",
                column: "FK_Attributes_Characters_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_Characters_FK_Attributes_Characters_Id",
                table: "Attributes",
                column: "FK_Attributes_Characters_Id",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Characters_FK_Skills_Characters_Id",
                table: "Skills",
                column: "FK_Skills_Characters_Id",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
