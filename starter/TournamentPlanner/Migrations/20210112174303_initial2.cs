using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentPlanner.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_Player1ID",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_Player2ID",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_WinnerID",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_Player1ID",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_Player2ID",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_WinnerID",
                table: "Matches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Player1ID",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Player2ID",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "WinnerID",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Players");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Blogs");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs");

            migrationBuilder.RenameTable(
                name: "Blogs",
                newName: "Players");

            migrationBuilder.AddColumn<int>(
                name: "Player1ID",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Player2ID",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WinnerID",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Players",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Players",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Player1ID",
                table: "Matches",
                column: "Player1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Player2ID",
                table: "Matches",
                column: "Player2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_WinnerID",
                table: "Matches",
                column: "WinnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_Player1ID",
                table: "Matches",
                column: "Player1ID",
                principalTable: "Players",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_Player2ID",
                table: "Matches",
                column: "Player2ID",
                principalTable: "Players",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_WinnerID",
                table: "Matches",
                column: "WinnerID",
                principalTable: "Players",
                principalColumn: "ID");
        }
    }
}
