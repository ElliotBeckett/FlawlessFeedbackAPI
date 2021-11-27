using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlawlessFeedbackAPI.Migrations
{
    public partial class AddedinFFuserlogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 1,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 10, 19, 6, 28, 58, 142, DateTimeKind.Local).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 2,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 10, 29, 6, 28, 58, 145, DateTimeKind.Local).AddTicks(2490));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 3,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 7, 21, 6, 28, 58, 145, DateTimeKind.Local).AddTicks(2575));

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "UserInfoID", "UserName", "UserPass", "UserRoleID" },
                values: new object[] { 2, "Admin@FlawlessFeedback.com", "FlawlessFeedback!21", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "UserInfoID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 1,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 10, 10, 9, 57, 11, 450, DateTimeKind.Local).AddTicks(5194));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 2,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 10, 20, 9, 57, 11, 452, DateTimeKind.Local).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 3,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 7, 12, 9, 57, 11, 452, DateTimeKind.Local).AddTicks(1621));
        }
    }
}
