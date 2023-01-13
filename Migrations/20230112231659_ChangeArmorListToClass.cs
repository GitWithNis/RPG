using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RPG.Migrations
{
    /// <inheritdoc />
    public partial class ChangeArmorListToClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Armor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Armor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Armor",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.CreateTable(
                name: "CharArmor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    HeadId = table.Column<int>(type: "int", nullable: true),
                    NeckId = table.Column<int>(type: "int", nullable: true),
                    ChestId = table.Column<int>(type: "int", nullable: true),
                    HandsId = table.Column<int>(type: "int", nullable: true),
                    LegsId = table.Column<int>(type: "int", nullable: true),
                    FeetId = table.Column<int>(type: "int", nullable: true),
                    FingerLId = table.Column<int>(type: "int", nullable: true),
                    FingerRId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharArmor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharArmor_Armor_ChestId",
                        column: x => x.ChestId,
                        principalTable: "Armor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharArmor_Armor_FeetId",
                        column: x => x.FeetId,
                        principalTable: "Armor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharArmor_Armor_FingerLId",
                        column: x => x.FingerLId,
                        principalTable: "Armor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharArmor_Armor_FingerRId",
                        column: x => x.FingerRId,
                        principalTable: "Armor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharArmor_Armor_HandsId",
                        column: x => x.HandsId,
                        principalTable: "Armor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharArmor_Armor_HeadId",
                        column: x => x.HeadId,
                        principalTable: "Armor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharArmor_Armor_LegsId",
                        column: x => x.LegsId,
                        principalTable: "Armor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharArmor_Armor_NeckId",
                        column: x => x.NeckId,
                        principalTable: "Armor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharArmor_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharArmor_CharacterId",
                table: "CharArmor",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharArmor_ChestId",
                table: "CharArmor",
                column: "ChestId");

            migrationBuilder.CreateIndex(
                name: "IX_CharArmor_FeetId",
                table: "CharArmor",
                column: "FeetId");

            migrationBuilder.CreateIndex(
                name: "IX_CharArmor_FingerLId",
                table: "CharArmor",
                column: "FingerLId");

            migrationBuilder.CreateIndex(
                name: "IX_CharArmor_FingerRId",
                table: "CharArmor",
                column: "FingerRId");

            migrationBuilder.CreateIndex(
                name: "IX_CharArmor_HandsId",
                table: "CharArmor",
                column: "HandsId");

            migrationBuilder.CreateIndex(
                name: "IX_CharArmor_HeadId",
                table: "CharArmor",
                column: "HeadId");

            migrationBuilder.CreateIndex(
                name: "IX_CharArmor_LegsId",
                table: "CharArmor",
                column: "LegsId");

            migrationBuilder.CreateIndex(
                name: "IX_CharArmor_NeckId",
                table: "CharArmor",
                column: "NeckId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharArmor");

            migrationBuilder.InsertData(
                table: "Armor",
                columns: new[] { "Id", "CharacterId", "Defense", "MagicProt", "Material", "MeleeProt", "Name", "Protection", "RangeProt", "Slot" },
                values: new object[,]
                {
                    { 1, null, 1, 0.5m, 1, 1.5m, "Leather Hat", 1, 1.5m, 0 },
                    { 2, null, 2, 0.5m, 1, 1.5m, "Leather Chest-piece", 3, 1.5m, 2 },
                    { 3, null, 2, 0.5m, 1, 1.5m, "Leather Pants", 3, 1.5m, 4 }
                });
        }
    }
}
