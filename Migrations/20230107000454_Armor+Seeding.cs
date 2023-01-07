using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RPG.Migrations
{
    /// <inheritdoc />
    public partial class ArmorSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Protection = table.Column<int>(type: "int", nullable: false),
                    Slot = table.Column<int>(type: "int", nullable: false),
                    Material = table.Column<int>(type: "int", nullable: false),
                    MeleeProt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RangeProt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MagicProt = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armor", x => x.Id);
                });

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
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Class = table.Column<int>(type: "int", nullable: false),
                    ArmorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Armor_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Armor",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Armor",
                columns: new[] { "Id", "Defense", "MagicProt", "Material", "MeleeProt", "Name", "Protection", "RangeProt", "Slot" },
                values: new object[,]
                {
                    { 1, 1, 0.5m, 1, 1.5m, "Leather Hat", 1, 1.5m, 0 },
                    { 2, 2, 0.5m, 1, 1.5m, "Leather Chest-piece", 3, 1.5m, 2 },
                    { 3, 2, 0.5m, 1, 1.5m, "Leather Pants", 3, 1.5m, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ArmorId",
                table: "Characters",
                column: "ArmorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Armor");
        }
    }
}
