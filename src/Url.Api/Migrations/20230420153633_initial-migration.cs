using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Url.Api.Migrations;

/// <inheritdoc />
public partial class initialmigration : Migration
{
  /// <inheritdoc />
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.CreateTable(
        name: "UrlEntities",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "TEXT", nullable: false),
          ShortName = table.Column<string>(type: "TEXT", nullable: false),
          ForwardTo = table.Column<string>(type: "TEXT", nullable: false),
          Description = table.Column<string>(type: "TEXT", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_UrlEntities", x => x.Id);
        });
  }

  /// <inheritdoc />
  protected override void Down(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.DropTable(
        name: "UrlEntities");
  }
}
