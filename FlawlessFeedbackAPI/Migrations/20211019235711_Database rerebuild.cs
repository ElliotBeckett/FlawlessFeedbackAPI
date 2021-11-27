using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlawlessFeedbackAPI.Migrations
{
    public partial class Databasererebuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
