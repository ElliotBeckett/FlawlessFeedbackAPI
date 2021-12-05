using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlawlessFeedbackAPI.Migrations
{
    public partial class DatabaseRebuild2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserInfos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 1,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 11, 23, 11, 46, 28, 606, DateTimeKind.Local).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 2,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 12, 3, 11, 46, 28, 608, DateTimeKind.Local).AddTicks(8988));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 3,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 8, 25, 11, 46, 28, 608, DateTimeKind.Local).AddTicks(9084));

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserInfoID",
                keyValue: 1,
                column: "UserPass",
                value: "$2b$10$MORpsQPzBH2NRN9KuNpAcOLS4RNN6g6tW9sR7EtRQ7kERvQVIfNvW");

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserInfoID",
                keyValue: 2,
                column: "UserPass",
                value: "$2b$10$0mcFQ2.A/suLOMjGHvqgNuOoRscFNZViWRg8Z61YZkHc6.Cwh42Da");

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserInfoID",
                keyValue: 3,
                column: "UserPass",
                value: "$2b$10$PrhDpDMajly9Xa/awswRuebhmtuGvmjdsal01St1knxPmG6/q.Urq");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserInfos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "UserInfoID",
                keyValue: 3,
                column: "UserPass",
                value: "$2b$10$6m0ngMMwZXFqXUnKDzdyEeoYuge6hq42nOhh.lx2.vvNdyaKJWIJu");
        }
    }
}
