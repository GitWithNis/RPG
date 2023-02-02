using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPG.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCharArmor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharArmor");

            migrationBuilder.AddColumn<int>(
                name: "ChestId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeetId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FingerLId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FingerRId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HandsId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HeadId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LegsId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NeckId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ChestId",
                table: "Characters",
                column: "ChestId",
                unique: true,
                filter: "[ChestId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_FeetId",
                table: "Characters",
                column: "FeetId",
                unique: true,
                filter: "[FeetId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_FingerLId",
                table: "Characters",
                column: "FingerLId",
                unique: true,
                filter: "[FingerLId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_FingerRId",
                table: "Characters",
                column: "FingerRId",
                unique: true,
                filter: "[FingerRId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_HandsId",
                table: "Characters",
                column: "HandsId",
                unique: true,
                filter: "[HandsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_HeadId",
                table: "Characters",
                column: "HeadId",
                unique: true,
                filter: "[HeadId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_LegsId",
                table: "Characters",
                column: "LegsId",
                unique: true,
                filter: "[LegsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_NeckId",
                table: "Characters",
                column: "NeckId",
                unique: true,
                filter: "[NeckId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Armor_ChestId",
                table: "Characters",
                column: "ChestId",
                principalTable: "Armor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Armor_FeetId",
                table: "Characters",
                column: "FeetId",
                principalTable: "Armor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Armor_FingerLId",
                table: "Characters",
                column: "FingerLId",
                principalTable: "Armor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Armor_FingerRId",
                table: "Characters",
                column: "FingerRId",
                principalTable: "Armor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Armor_HandsId",
                table: "Characters",
                column: "HandsId",
                principalTable: "Armor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Armor_HeadId",
                table: "Characters",
                column: "HeadId",
                principalTable: "Armor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Armor_LegsId",
                table: "Characters",
                column: "LegsId",
                principalTable: "Armor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Armor_NeckId",
                table: "Characters",
                column: "NeckId",
                principalTable: "Armor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Armor_ChestId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Armor_FeetId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Armor_FingerLId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Armor_FingerRId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Armor_HandsId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Armor_HeadId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Armor_LegsId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Armor_NeckId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_ChestId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_FeetId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_FingerLId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_FingerRId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_HandsId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_HeadId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_LegsId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_NeckId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ChestId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "FeetId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "FingerLId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "FingerRId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "HandsId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "HeadId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "LegsId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "NeckId",
                table: "Characters");

            migrationBuilder.CreateTable(
                name: "CharArmor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    ChestId = table.Column<int>(type: "int", nullable: true),
                    FeetId = table.Column<int>(type: "int", nullable: true),
                    FingerLId = table.Column<int>(type: "int", nullable: true),
                    FingerRId = table.Column<int>(type: "int", nullable: true),
                    HandsId = table.Column<int>(type: "int", nullable: true),
                    HeadId = table.Column<int>(type: "int", nullable: true),
                    LegsId = table.Column<int>(type: "int", nullable: true),
                    NeckId = table.Column<int>(type: "int", nullable: true)
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
    }
}
