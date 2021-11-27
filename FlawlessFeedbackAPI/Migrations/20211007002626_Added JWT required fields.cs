using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlawlessFeedbackAPI.Migrations
{
    public partial class AddedJWTrequiredfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_UserRole_UserRoleID",
                table: "UserInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo");

            migrationBuilder.RenameTable(
                name: "UserRole",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "UserInfo",
                newName: "UserInfos");

            migrationBuilder.RenameIndex(
                name: "IX_UserInfo_UserRoleID",
                table: "UserInfos",
                newName: "IX_UserInfos_UserRoleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                column: "UserRoleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfos",
                table: "UserInfos",
                column: "UserInfoID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_UserRoles_UserRoleID",
                table: "UserInfos",
                column: "UserRoleID",
                principalTable: "UserRoles",
                principalColumn: "UserRoleID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_UserRoles_UserRoleID",
                table: "UserInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfos",
                table: "UserInfos");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "UserRole");

            migrationBuilder.RenameTable(
                name: "UserInfos",
                newName: "UserInfo");

            migrationBuilder.RenameIndex(
                name: "IX_UserInfos_UserRoleID",
                table: "UserInfo",
                newName: "IX_UserInfo_UserRoleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole",
                column: "UserRoleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo",
                column: "UserInfoID");

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 1,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 9, 27, 9, 28, 41, 959, DateTimeKind.Local).AddTicks(531));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 2,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 10, 7, 9, 28, 41, 961, DateTimeKind.Local).AddTicks(4516));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 3,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 6, 29, 9, 28, 41, 961, DateTimeKind.Local).AddTicks(4581));

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_UserRole_UserRoleID",
                table: "UserInfo",
                column: "UserRoleID",
                principalTable: "UserRole",
                principalColumn: "UserRoleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
