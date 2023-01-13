using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPG.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCharacterToArmorToCharArmorLoop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armor_Characters_CharacterId",
                table: "Armor");

            migrationBuilder.DropIndex(
                name: "IX_Armor_CharacterId",
                table: "Armor");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "Armor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "Armor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Armor_CharacterId",
                table: "Armor",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Armor_Characters_CharacterId",
                table: "Armor",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");
        }
    }
}
