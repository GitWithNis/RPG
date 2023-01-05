using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RPG.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxHP = table.Column<int>(type: "int", nullable: false),
                    HP = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Defense", "Dexterity", "HP", "Intelligence", "MaxHP", "Name", "Strength" },
                values: new object[,]
                {
                    { 1, 10, 10, 100, 10, 100, "FirstTestPlayer", 10 },
                    { 2, 10, 10, 100, 10, 100, "SecondTestPlayer", 10 },
                    { 3, 10, 10, 100, 10, 100, "ThirdTestPlayer", 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
