using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlawlessFeedbackAPI.Migrations
{
    public partial class Added3rduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 1,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 11, 16, 14, 32, 8, 367, DateTimeKind.Local).AddTicks(8281));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 2,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 11, 26, 14, 32, 8, 370, DateTimeKind.Local).AddTicks(8917));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 3,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 8, 18, 14, 32, 8, 370, DateTimeKind.Local).AddTicks(9025));

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserInfoID",
                keyValue: 1,
                column: "UserPass",
                value: "$2b$10$WHf52CO/fYrpeet1w/LFC.5EgU9soQn6mG00sXOfpDLnsI3BsgBTC");

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserInfoID",
                keyValue: 2,
                column: "UserPass",
                value: "$2b$10$GambcjiWcyPfguEwk6tadutuog58ILT2UmUFpDwNFxL6L4Z09Aixa");

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "UserInfoID", "UserEmail", "UserName", "UserPass", "UserRoleID" },
                values: new object[] { 3, "lyam@email.com", "Lyam", "$2b$10$6m0ngMMwZXFqXUnKDzdyEeoYuge6hq42nOhh.lx2.vvNdyaKJWIJu", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "UserInfoID",
                keyValue: 3);

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
                column: "UserPass",
                value: "$2b$10$l2OSQFf3P4sOxF6cYopTheCX9olLO8AaEeasb.e7U1bMf8K8WzUR6");

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserInfoID",
                keyValue: 2,
                column: "UserPass",
                value: "$2b$10$kyd6agU4uY0W6q/jtZhlceoiPVOGPZKQfXdmrKSMNB/k95sQFjF/.");
        }
    }
}
