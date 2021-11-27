using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlawlessFeedbackAPI.Migrations
{
    public partial class Updatedusermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserPass",
                table: "UserInfos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserInfos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "UserInfos",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 1,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 11, 16, 12, 26, 32, 689, DateTimeKind.Local).AddTicks(180));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 2,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 11, 26, 12, 26, 32, 692, DateTimeKind.Local).AddTicks(6936));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 3,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 8, 18, 12, 26, 32, 692, DateTimeKind.Local).AddTicks(7116));

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserInfoID",
                keyValue: 1,
                columns: new[] { "UserEmail", "UserPass" },
                values: new object[] { "Steve@mail.com", "$2b$10$l2OSQFf3P4sOxF6cYopTheCX9olLO8AaEeasb.e7U1bMf8K8WzUR6" });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserInfoID",
                keyValue: 2,
                columns: new[] { "UserEmail", "UserName", "UserPass" },
                values: new object[] { "Admin@FlawlessFeedback.com", "Admin", "$2b$10$kyd6agU4uY0W6q/jtZhlceoiPVOGPZKQfXdmrKSMNB/k95sQFjF/." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "UserInfos");

            migrationBuilder.AlterColumn<string>(
                name: "UserPass",
                table: "UserInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

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
                columns: new[] { "UserName", "UserPass" },
                values: new object[] { "Admin@FlawlessFeedback.com", "$2b$10$0fvt6sSRxqaygDQ4YvARMuZY6u2LgeB11ylUZPyghWzO592Xo/A9i" });
        }
    }
}
