using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Telvee32.BlackscarsSheetsSwtor.UI.Data.Migrations
{
    public partial class AttributeSkill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_AspNetUsers_UserId",
                table: "Character");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Character",
                table: "Character");

            migrationBuilder.RenameTable(
                name: "Character",
                newName: "Characters");

            migrationBuilder.RenameIndex(
                name: "IX_Character_UserId",
                table: "Characters",
                newName: "IX_Characters_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Characters",
                table: "Characters",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Charisma = table.Column<int>(nullable: false),
                    Dexterity = table.Column<int>(nullable: false),
                    FK_Attributes_Characters_Id = table.Column<Guid>(nullable: true),
                    Intelligence = table.Column<int>(nullable: false),
                    Stamina = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Willpower = table.Column<int>(nullable: false),
                    Wits = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attributes_Characters_FK_Attributes_Characters_Id",
                        column: x => x.FK_Attributes_Characters_Id,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnimalKen = table.Column<int>(nullable: false),
                    Athletics = table.Column<int>(nullable: false),
                    Brawling = table.Column<int>(nullable: false),
                    FK_Skills_Characters_Id = table.Column<Guid>(nullable: true),
                    Firearms = table.Column<int>(nullable: false),
                    HeavyOrdnance = table.Column<int>(nullable: false),
                    Interrogation = table.Column<int>(nullable: false),
                    Larceny = table.Column<int>(nullable: false),
                    Mechanics = table.Column<int>(nullable: false),
                    Medicine = table.Column<int>(nullable: false),
                    Persuasion = table.Column<int>(nullable: false),
                    Piloting = table.Column<int>(nullable: false),
                    Slicing = table.Column<int>(nullable: false),
                    Stealth = table.Column<int>(nullable: false),
                    Survival = table.Column<int>(nullable: false),
                    Weaponry = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Characters_FK_Skills_Characters_Id",
                        column: x => x.FK_Skills_Characters_Id,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_FK_Attributes_Characters_Id",
                table: "Attributes",
                column: "FK_Attributes_Characters_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_FK_Skills_Characters_Id",
                table: "Skills",
                column: "FK_Skills_Characters_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_AspNetUsers_UserId",
                table: "Characters",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_AspNetUsers_UserId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Characters",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "Characters");

            migrationBuilder.RenameTable(
                name: "Characters",
                newName: "Character");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_UserId",
                table: "Character",
                newName: "IX_Character_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Character",
                table: "Character",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_AspNetUsers_UserId",
                table: "Character",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
