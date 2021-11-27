﻿// <auto-generated />
using System;
using FlawlessFeedbackAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlawlessFeedbackAPI.Migrations
{
    [DbContext(typeof(FFDBContext))]
    [Migration("20211006083105_Fixes to Question Model")]
    partial class FixestoQuestionModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FlawlessFeedbackAPI.Models.Option", b =>
                {
                    b.Property<int>("OptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OptionOrder")
                        .HasColumnType("int");

                    b.Property<string>("OptionText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionID")
                        .HasColumnType("int");

                    b.HasKey("OptionID");

                    b.HasIndex("QuestionID");

                    b.ToTable("Options");

                    b.HasData(
                        new
                        {
                            OptionID = 1,
                            OptionOrder = 1,
                            OptionText = "True",
                            QuestionID = 1
                        },
                        new
                        {
                            OptionID = 2,
                            OptionOrder = 2,
                            OptionText = "False",
                            QuestionID = 1
                        },
                        new
                        {
                            OptionID = 3,
                            OptionOrder = 1,
                            OptionText = "A",
                            QuestionID = 2
                        },
                        new
                        {
                            OptionID = 4,
                            OptionOrder = 2,
                            OptionText = "B",
                            QuestionID = 2
                        },
                        new
                        {
                            OptionID = 5,
                            OptionOrder = 3,
                            OptionText = "C",
                            QuestionID = 2
                        });
                });

            modelBuilder.Entity("FlawlessFeedbackAPI.Models.Question", b =>
                {
                    b.Property<int>("QuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("QuestionText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SurveyID")
                        .HasColumnType("int");

                    b.HasKey("QuestionID");

                    b.HasIndex("SurveyID");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            QuestionID = 1,
                            QuestionText = "Test Question 1",
                            SurveyID = 1
                        },
                        new
                        {
                            QuestionID = 2,
                            QuestionText = "Test Question 2",
                            SurveyID = 1
                        },
                        new
                        {
                            QuestionID = 3,
                            QuestionText = "Test Question 3",
                            SurveyID = 3
                        });
                });

            modelBuilder.Entity("FlawlessFeedbackAPI.Models.Survey", b =>
                {
                    b.Property<int>("SurveyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SurveyAuthor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurveyComments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SurveyDateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("SurveyImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurveyTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurveyTopic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SurveyID");

                    b.ToTable("Surveys");

                    b.HasData(
                        new
                        {
                            SurveyID = 1,
                            SurveyAuthor = "Elliot Beckett",
                            SurveyComments = "",
                            SurveyDateCreated = new DateTime(2021, 9, 26, 18, 31, 4, 260, DateTimeKind.Local).AddTicks(5087),
                            SurveyImageURL = "",
                            SurveyTitle = "Survey 1",
                            SurveyTopic = "Testing Topic"
                        },
                        new
                        {
                            SurveyID = 2,
                            SurveyAuthor = "Joe Bloggs",
                            SurveyComments = "This is a sample survey",
                            SurveyDateCreated = new DateTime(2021, 10, 6, 18, 31, 4, 263, DateTimeKind.Local).AddTicks(4281),
                            SurveyImageURL = "",
                            SurveyTitle = "Survey 2",
                            SurveyTopic = "Default"
                        },
                        new
                        {
                            SurveyID = 3,
                            SurveyAuthor = "Mary Sue",
                            SurveyComments = "This is my super awesome survey!",
                            SurveyDateCreated = new DateTime(2021, 6, 28, 18, 31, 4, 263, DateTimeKind.Local).AddTicks(4383),
                            SurveyImageURL = "",
                            SurveyTitle = "My super survey",
                            SurveyTopic = "Survey to survey friends"
                        });
                });

            modelBuilder.Entity("FlawlessFeedbackAPI.Models.Option", b =>
                {
                    b.HasOne("FlawlessFeedbackAPI.Models.Question", null)
                        .WithMany("Options")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlawlessFeedbackAPI.Models.Question", b =>
                {
                    b.HasOne("FlawlessFeedbackAPI.Models.Survey", null)
                        .WithMany("Questions")
                        .HasForeignKey("SurveyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
