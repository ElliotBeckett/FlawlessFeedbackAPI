using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlawlessFeedbackAPI.Migrations
{
    public partial class AddedMoreOptionsdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "OptionID", "OptionOrder", "OptionText", "QuestionID" },
                values: new object[,]
                {
                    { 2, 2, "False", 1 },
                    { 3, 1, "A", 2 },
                    { 4, 2, "B", 2 },
                    { 5, 3, "C", 2 }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionID",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 1,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 9, 26, 15, 11, 19, 309, DateTimeKind.Local).AddTicks(4071));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 2,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 10, 6, 15, 11, 19, 311, DateTimeKind.Local).AddTicks(1602));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 3,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 6, 28, 15, 11, 19, 311, DateTimeKind.Local).AddTicks(1653));
        }
    }
}
