using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlawlessFeedbackAPI.Migrations
{
    public partial class Databaserebuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    SurveyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyTitle = table.Column<string>(nullable: true),
                    SurveyTopic = table.Column<string>(nullable: true),
                    SurveyAuthor = table.Column<string>(nullable: true),
                    SurveyDateCreated = table.Column<DateTime>(nullable: false),
                    SurveyComments = table.Column<string>(nullable: true),
                    SurveyImageURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.SurveyID);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(nullable: true),
                    SurveyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionID);
                    table.ForeignKey(
                        name: "FK_Questions_Surveys_SurveyID",
                        column: x => x.SurveyID,
                        principalTable: "Surveys",
                        principalColumn: "SurveyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    OptionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionText = table.Column<string>(nullable: true),
                    OptionOrder = table.Column<string>(nullable: true),
                    QuestionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.OptionID);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "QuestionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "SurveyID", "SurveyAuthor", "SurveyComments", "SurveyDateCreated", "SurveyImageURL", "SurveyTitle", "SurveyTopic" },
                values: new object[] { 1, "Elliot Beckett", "", new DateTime(2021, 9, 26, 10, 52, 44, 664, DateTimeKind.Local).AddTicks(4995), "", "Survey 1", "Testing Topic" });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "SurveyID", "SurveyAuthor", "SurveyComments", "SurveyDateCreated", "SurveyImageURL", "SurveyTitle", "SurveyTopic" },
                values: new object[] { 2, "Joe Bloggs", "This is a sample survey", new DateTime(2021, 10, 6, 10, 52, 44, 666, DateTimeKind.Local).AddTicks(6542), "", "Survey 2", "Default" });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "SurveyID", "SurveyAuthor", "SurveyComments", "SurveyDateCreated", "SurveyImageURL", "SurveyTitle", "SurveyTopic" },
                values: new object[] { 3, "Mary Sue", "This is my super awesome survey!", new DateTime(2021, 6, 28, 10, 52, 44, 666, DateTimeKind.Local).AddTicks(6624), "", "My super survey", "Survey to survey friends" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionID", "QuestionText", "SurveyID" },
                values: new object[] { 1, "Test Question 1", 1 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionID", "QuestionText", "SurveyID" },
                values: new object[] { 2, "Test Question 2", 1 });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionID", "QuestionText", "SurveyID" },
                values: new object[] { 3, "Test Question 3", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionID",
                table: "Options",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SurveyID",
                table: "Questions",
                column: "SurveyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Surveys");
        }
    }
}
