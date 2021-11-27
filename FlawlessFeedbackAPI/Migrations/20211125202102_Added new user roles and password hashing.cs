using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlawlessFeedbackAPI.Migrations
{
    public partial class Addednewuserrolesandpasswordhashing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 1,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 11, 16, 6, 21, 1, 367, DateTimeKind.Local).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 2,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 11, 26, 6, 21, 1, 370, DateTimeKind.Local).AddTicks(4538));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 3,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 8, 18, 6, 21, 1, 370, DateTimeKind.Local).AddTicks(4638));

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserInfoID",
                keyValue: 1,
                column: "UserPass",
                value: "$2b$10$k9Ryi0iHunZRlc1c.ocgP.1FvXG8A3K2CEsdGPiosyVg20UUJLHA2");

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserInfoID",
                keyValue: 2,
                column: "UserPass",
                value: "$2b$10$0fvt6sSRxqaygDQ4YvARMuZY6u2LgeB11ylUZPyghWzO592Xo/A9i");

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleID", "UserRoleTitle" },
                values: new object[,]
                {
                    { 2, "User" },
                    { 3, "ViewOnly" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "UserRoleID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "UserRoleID",
                keyValue: 3);

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

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserInfoID",
                keyValue: 1,
                column: "UserPass",
                value: "abc_123");

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserInfoID",
                keyValue: 2,
                column: "UserPass",
                value: "FlawlessFeedback!21");
        }
    }
}
