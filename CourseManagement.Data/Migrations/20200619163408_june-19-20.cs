using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz.CourseManagement.Data.Migrations
{
    public partial class june1920 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                schema: "CourseManagement",
                table: "Answers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCorrect",
                schema: "CourseManagement",
                table: "Answers");
        }
    }
}
