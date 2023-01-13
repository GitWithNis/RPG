using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPG.Migrations
{
    /// <inheritdoc />
    public partial class Armor1to1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Armor_ArmorId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_ArmorId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ArmorId",
                table: "Characters");

            migrationBuilder.AlterColumn<decimal>(
                name: "RangeProt",
                table: "Armor",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MeleeProt",
                table: "Armor",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MagicProt",
                table: "Armor",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Armor",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Armor",
                keyColumn: "Id",
                keyValue: 1,
                column: "CharacterId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Armor",
                keyColumn: "Id",
                keyValue: 2,
                column: "CharacterId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Armor",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CharacterId", "Slot" },
                values: new object[] { null, 4 });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armor_Characters_CharacterId",
                table: "Armor");

            migrationBuilder.DropIndex(
                name: "IX_Armor_CharacterId",
                table: "Armor");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Armor");

            migrationBuilder.AddColumn<int>(
                name: "ArmorId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "RangeProt",
                table: "Armor",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MeleeProt",
                table: "Armor",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MagicProt",
                table: "Armor",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.UpdateData(
                table: "Armor",
                keyColumn: "Id",
                keyValue: 3,
                column: "Slot",
                value: 5);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ArmorId",
                table: "Characters",
                column: "ArmorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Armor_ArmorId",
                table: "Characters",
                column: "ArmorId",
                principalTable: "Armor",
                principalColumn: "Id");
        }
    }
}
