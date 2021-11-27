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
    [Migration("20211006232842_Added user info and roles")]
    partial class Addeduserinfoandroles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.19")
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
                            SurveyDateCreated = new DateTime(2021, 9, 27, 9, 28, 41, 959, DateTimeKind.Local).AddTicks(531),
                            SurveyImageURL = "",
                            SurveyTitle = "Survey 1",
                            SurveyTopic = "Testing Topic"
                        },
                        new
                        {
                            SurveyID = 2,
                            SurveyAuthor = "Joe Bloggs",
                            SurveyComments = "This is a sample survey",
                            SurveyDateCreated = new DateTime(2021, 10, 7, 9, 28, 41, 961, DateTimeKind.Local).AddTicks(4516),
                            SurveyImageURL = "",
                            SurveyTitle = "Survey 2",
                            SurveyTopic = "Default"
                        },
                        new
                        {
                            SurveyID = 3,
                            SurveyAuthor = "Mary Sue",
                            SurveyComments = "This is my super awesome survey!",
                            SurveyDateCreated = new DateTime(2021, 6, 29, 9, 28, 41, 961, DateTimeKind.Local).AddTicks(4581),
                            SurveyImageURL = "",
                            SurveyTitle = "My super survey",
                            SurveyTopic = "Survey to survey friends"
                        });
                });

            modelBuilder.Entity("FlawlessFeedbackAPI.Models.UserInfo", b =>
                {
                    b.Property<int>("UserInfoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRoleID")
                        .HasColumnType("int");

                    b.HasKey("UserInfoID");

                    b.HasIndex("UserRoleID");

                    b.ToTable("UserInfo");

                    b.HasData(
                        new
                        {
                            UserInfoID = 1,
                            UserName = "Admin@FlawlessFeedback.com",
                            UserPass = "FlawlessFeedback!21",
                            UserRoleID = 1
                        });
                });

            modelBuilder.Entity("FlawlessFeedbackAPI.Models.UserRole", b =>
                {
                    b.Property<int>("UserRoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserRoleTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserRoleID");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            UserRoleID = 1,
                            UserRoleTitle = "Admin"
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

            modelBuilder.Entity("FlawlessFeedbackAPI.Models.UserInfo", b =>
                {
                    b.HasOne("FlawlessFeedbackAPI.Models.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
