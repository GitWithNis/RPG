using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPG.Migrations
{
    /// <inheritdoc />
    public partial class monsterIdInCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Monsters_CharacterId",
                table: "Monsters");

            migrationBuilder.AddColumn<int>(
                name: "MonsterId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_CharacterId",
                table: "Monsters",
                column: "CharacterId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Monsters_CharacterId",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "MonsterId",
                table: "Characters");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_CharacterId",
                table: "Monsters",
                column: "CharacterId");
        }
    }
}
