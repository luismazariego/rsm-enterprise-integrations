using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DIYBeers.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExternalId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Tagline = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    FirstBrewed = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", nullable: false),
                    Abv = table.Column<double>(type: "float", nullable: false),
                    Ibu = table.Column<double>(type: "float", nullable: false),
                    TargetFg = table.Column<double>(type: "float", nullable: false),
                    TargetOg = table.Column<double>(type: "float", nullable: false),
                    Ebc = table.Column<double>(type: "float", nullable: false),
                    Srm = table.Column<double>(type: "float", nullable: false),
                    Ph = table.Column<double>(type: "float", nullable: false),
                    AttenuationLevel = table.Column<double>(type: "float", nullable: false),
                    IngredientsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodPairing = table.Column<string>(type: "varchar(max)", nullable: false),
                    BrewersTips = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Yeast = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    BeerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Beer_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Unit = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    Add = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attribute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IngredientsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hops_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Malt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Unit = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    IngredientsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Malt_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hops_IngredientsId",
                table: "Hops",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_BeerId",
                table: "Ingredients",
                column: "BeerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Malt_IngredientsId",
                table: "Malt",
                column: "IngredientsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hops");

            migrationBuilder.DropTable(
                name: "Malt");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Beer");
        }
    }
}
