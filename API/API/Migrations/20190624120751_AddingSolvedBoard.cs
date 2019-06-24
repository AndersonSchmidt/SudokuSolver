using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddingSolvedBoard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SolvedBoard",
                table: "Sudokus",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SolvedBoard",
                table: "Sudokus");
        }
    }
}
