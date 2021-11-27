using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlawlessFeedbackAPI.Migrations
{
    public partial class AddedOptionsdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Questions_QuestionID",
                table: "Options");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionID",
                table: "Options",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OptionOrder",
                table: "Options",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "OptionID", "OptionOrder", "OptionText", "QuestionID" },
                values: new object[] { 1, 1, "True", 1 });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Questions_QuestionID",
                table: "Options",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "QuestionID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Questions_QuestionID",
                table: "Options");

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionID",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionID",
                table: "Options",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "OptionOrder",
                table: "Options",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 1,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 9, 26, 12, 28, 31, 185, DateTimeKind.Local).AddTicks(1017));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 2,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 10, 6, 12, 28, 31, 187, DateTimeKind.Local).AddTicks(591));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 3,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 6, 28, 12, 28, 31, 187, DateTimeKind.Local).AddTicks(672));

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Questions_QuestionID",
                table: "Options",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "QuestionID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
