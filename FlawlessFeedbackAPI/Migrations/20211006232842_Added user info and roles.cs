using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlawlessFeedbackAPI.Migrations
{
    public partial class Addeduserinfoandroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserRoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.UserRoleID);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    UserInfoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    UserPass = table.Column<string>(nullable: true),
                    UserRoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.UserInfoID);
                    table.ForeignKey(
                        name: "FK_UserInfo_UserRole_UserRoleID",
                        column: x => x.UserRoleID,
                        principalTable: "UserRole",
                        principalColumn: "UserRoleID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleID", "UserRoleTitle" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "UserInfoID", "UserName", "UserPass", "UserRoleID" },
                values: new object[] { 1, "Admin@FlawlessFeedback.com", "FlawlessFeedback!21", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_UserRoleID",
                table: "UserInfo",
                column: "UserRoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 1,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 9, 26, 18, 31, 4, 260, DateTimeKind.Local).AddTicks(5087));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 2,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 10, 6, 18, 31, 4, 263, DateTimeKind.Local).AddTicks(4281));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyID",
                keyValue: 3,
                column: "SurveyDateCreated",
                value: new DateTime(2021, 6, 28, 18, 31, 4, 263, DateTimeKind.Local).AddTicks(4383));
        }
    }
}
