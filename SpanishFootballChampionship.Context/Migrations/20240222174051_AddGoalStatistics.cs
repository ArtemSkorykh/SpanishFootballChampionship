using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpanishFootballChampionship.DAL.Migrations
{
    public partial class AddGoalStatistics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoalsFor",
                table: "Teams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoalsAgainst",
                table: "Teams",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoalsFor",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "GoalsAgainst",
                table: "Teams");
        }
    }
}
