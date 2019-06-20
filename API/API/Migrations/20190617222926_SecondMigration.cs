using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sudoku",
                table: "Sudoku");

            migrationBuilder.RenameTable(
                name: "Sudoku",
                newName: "Sudokus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sudokus",
                table: "Sudokus",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sudokus",
                table: "Sudokus");

            migrationBuilder.RenameTable(
                name: "Sudokus",
                newName: "Sudoku");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sudoku",
                table: "Sudoku",
                column: "Id");
        }
    }
}
