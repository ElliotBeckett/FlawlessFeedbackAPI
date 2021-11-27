using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlawlessFeedbackAPI.Migrations
{
    public partial class FixestoQuestionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 1,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 9, 26, 18, 31, 4, 260, DateTimeKind.Local).AddTicks(5087));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 2,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 10, 6, 18, 31, 4, 263, DateTimeKind.Local).AddTicks(4281));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 3,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 6, 28, 18, 31, 4, 263, DateTimeKind.Local).AddTicks(4383));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 1,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 9, 26, 16, 12, 7, 456, DateTimeKind.Local).AddTicks(3495));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 2,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 10, 6, 16, 12, 7, 458, DateTimeKind.Local).AddTicks(3006));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 3,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 6, 28, 16, 12, 7, 458, DateTimeKind.Local).AddTicks(3081));
        }
    }
}
