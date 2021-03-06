﻿// <auto-generated />

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace P03DomainModels.Migrations
{
  public partial class Initial : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Competions",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Competions", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Games",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            CompetionId = table.Column<int>(type: "integer", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Games", x => x.Id);
            table.ForeignKey(
                      name: "FK_Games_Competions_CompetionId",
                      column: x => x.CompetionId,
                      principalTable: "Competions",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "Players",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            FullName = table.Column<string>(type: "text", nullable: false),
            CompetionId = table.Column<int>(type: "integer", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Players", x => x.Id);
            table.ForeignKey(
                      name: "FK_Players_Competions_CompetionId",
                      column: x => x.CompetionId,
                      principalTable: "Competions",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "Competitors",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            GameId = table.Column<int>(type: "integer", nullable: false),
            PlayerId = table.Column<int>(type: "integer", nullable: false),
            Score = table.Column<int>(type: "integer", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Competitors", x => x.Id);
            table.ForeignKey(
                      name: "FK_Competitors_Games_GameId",
                      column: x => x.GameId,
                      principalTable: "Games",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_Competitors_Players_PlayerId",
                      column: x => x.PlayerId,
                      principalTable: "Players",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateIndex(
          name: "IX_Competitors_GameId",
          table: "Competitors",
          column: "GameId");

      migrationBuilder.CreateIndex(
          name: "IX_Competitors_PlayerId",
          table: "Competitors",
          column: "PlayerId");

      migrationBuilder.CreateIndex(
          name: "IX_Games_CompetionId",
          table: "Games",
          column: "CompetionId");

      migrationBuilder.CreateIndex(
          name: "IX_Players_CompetionId",
          table: "Players",
          column: "CompetionId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Competitors");

      migrationBuilder.DropTable(
          name: "Games");

      migrationBuilder.DropTable(
          name: "Players");

      migrationBuilder.DropTable(
          name: "Competions");
    }
  }
}
