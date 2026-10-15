using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace computerwebshop.Migrations
{
    /// <inheritdoc />
    public partial class CompTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computer_Osystems_OsId",
                table: "Computer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Computer",
                table: "Computer");

            migrationBuilder.RenameTable(
                name: "Computer",
                newName: "Comp");

            migrationBuilder.RenameIndex(
                name: "IX_Computer_OsId",
                table: "Comp",
                newName: "IX_Comp_OsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comp",
                table: "Comp",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comp_Osystems_OsId",
                table: "Comp",
                column: "OsId",
                principalTable: "Osystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comp_Osystems_OsId",
                table: "Comp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comp",
                table: "Comp");

            migrationBuilder.RenameTable(
                name: "Comp",
                newName: "Computer");

            migrationBuilder.RenameIndex(
                name: "IX_Comp_OsId",
                table: "Computer",
                newName: "IX_Computer_OsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Computer",
                table: "Computer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Computer_Osystems_OsId",
                table: "Computer",
                column: "OsId",
                principalTable: "Osystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
