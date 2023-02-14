using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPG.Migrations
{
    /// <inheritdoc />
    public partial class ChangeArmorsToListAndAddWeapon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Monsters_MonsterId",
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
                name: "IX_Characters_MonsterId",
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

            migrationBuilder.AddColumn<int>(
                name: "SlotOnChar",
                table: "Armor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttackType = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Pierce = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapons_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_CharacterId",
                table: "Monsters",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_CharacterId",
                table: "Weapons",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_Characters_CharacterId",
                table: "Monsters",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_Characters_CharacterId",
                table: "Monsters");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Monsters_CharacterId",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "SlotOnChar",
                table: "Armor");

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
                name: "IX_Characters_MonsterId",
                table: "Characters",
                column: "MonsterId",
                unique: true,
                filter: "[MonsterId] IS NOT NULL");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Monsters_MonsterId",
                table: "Characters",
                column: "MonsterId",
                principalTable: "Monsters",
                principalColumn: "Id");
        }
    }
}
