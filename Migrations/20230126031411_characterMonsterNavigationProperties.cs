using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPG.Migrations
{
    /// <inheritdoc />
    public partial class characterMonsterNavigationProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_Characters_CharacterId",
                table: "Monsters");

            migrationBuilder.DropIndex(
                name: "IX_Monsters_CharacterId",
                table: "Monsters");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_MonsterId",
                table: "Characters",
                column: "MonsterId",
                unique: true,
                filter: "[MonsterId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Monsters_MonsterId",
                table: "Characters",
                column: "MonsterId",
                principalTable: "Monsters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Monsters_MonsterId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_MonsterId",
                table: "Characters");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_CharacterId",
                table: "Monsters",
                column: "CharacterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_Characters_CharacterId",
                table: "Monsters",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
