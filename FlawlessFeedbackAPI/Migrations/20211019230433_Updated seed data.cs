using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlawlessFeedbackAPI.Migrations
{
    public partial class Updatedseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 1,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 10, 10, 9, 4, 32, 911, DateTimeKind.Local).AddTicks(8137));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 2,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 10, 20, 9, 4, 32, 913, DateTimeKind.Local).AddTicks(2466));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 3,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 7, 12, 9, 4, 32, 913, DateTimeKind.Local).AddTicks(2524));

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserInfoID",
                keyValue: 1,
                columns: new[] { "UserName", "UserPass" },
                values: new object[] { "Steve", "abc_123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 1,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 9, 27, 10, 26, 26, 263, DateTimeKind.Local).AddTicks(2068));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 2,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 10, 7, 10, 26, 26, 264, DateTimeKind.Local).AddTicks(8143));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 3,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 6, 29, 10, 26, 26, 264, DateTimeKind.Local).AddTicks(8204));

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserInfoID",
                keyValue: 1,
                columns: new[] { "UserName", "UserPass" },
                values: new object[] { "Admin@FlawlessFeedback.com", "FlawlessFeedback!21" });
        }
    }
}
