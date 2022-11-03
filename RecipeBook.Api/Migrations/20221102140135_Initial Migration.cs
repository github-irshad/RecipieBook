using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBook.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipies",
                columns: table => new
                {
                    RecipieId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipieTitle = table.Column<string>(type: "text", nullable: false),
                    RecipieDescription = table.Column<string>(type: "text", nullable: false),
                    RecipiePhotoName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipies", x => x.RecipieId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipies");
        }
    }
}
