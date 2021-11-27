using Microsoft.EntityFrameworkCore;
using System;

namespace FlawlessFeedbackAPI.Models
{
    public class FFDBContext : DbContext
    {
        public FFDBContext()
        {
        }

        public FFDBContext(DbContextOptions<FFDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>().HasData(
                new Survey
                {
                    SurveyID = 1,
                    SurveyTitle = "Survey 1",
                    SurveyTopic = "Testing Topic",
                    SurveyAuthor = "Elliot Beckett",
                    SurveyDateCreated = DateTime.Now.AddDays(-10),
                    SurveyComments = "",
                    SurveyImageURL = "",
                },
                new Survey
                {
                    SurveyID = 2,
                    SurveyTitle = "Survey 2",
                    SurveyTopic = "Default",
                    SurveyAuthor = "Joe Bloggs",
                    SurveyDateCreated = DateTime.Now,
                    SurveyComments = "This is a sample survey",
                    SurveyImageURL = ""
                },
                new Survey
                {
                    SurveyID = 3,
                    SurveyTitle = "My super survey",
                    SurveyTopic = "Survey to survey friends",
                    SurveyAuthor = "Mary Sue",
                    SurveyDateCreated = DateTime.Now.AddDays(-100),
                    SurveyComments = "This is my super awesome survey!",
                    SurveyImageURL = ""
                }

                );
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    QuestionID = 1,
                    QuestionText = "Test Question 1",
                    SurveyID = 1
                },
                new Question
                {
                    QuestionID = 2,
                    QuestionText = "Test Question 2",
                    SurveyID = 1
                },
                new Question
                {
                    QuestionID = 3,
                    QuestionText = "Test Question 3",
                    SurveyID = 3
                }
                );
            modelBuilder.Entity<Option>().HasData(
                new Option
                {
                    OptionID = 1,
                    OptionOrder = 1,
                    OptionText = "True",
                    QuestionID = 1
                },
                new Option
                {
                    OptionID = 2,
                    OptionOrder = 2,
                    OptionText = "False",
                    QuestionID = 1
                },
                new Option
                {
                    OptionID = 3,
                    OptionOrder = 1,
                    OptionText = "A",
                    QuestionID = 2
                },
                new Option
                {
                    OptionID = 4,
                    OptionOrder = 2,
                    OptionText = "B",
                    QuestionID = 2
                },
                new Option
                {
                    OptionID = 5,
                    OptionOrder = 3,
                    OptionText = "C",
                    QuestionID = 2
                });

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    UserRoleID = 1,
                    UserRoleTitle = "Admin"
                });
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    UserRoleID = 2,
                    UserRoleTitle = "User"
                });

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    UserRoleID = 3,
                    UserRoleTitle = "ViewOnly"
                });



            // Hashing passwords when added to the DB - 
            // Provided by Shaun O'Sullivan - Class tracker API - Week 13 with Auth, Hashing and user roles
            // Using BCrypt.Net
            modelBuilder.Entity<UserInfo>().HasData(
             new UserInfo
             {
                 UserInfoID = 1,
                 UserName = "Steve",
                 UserEmail = "Steve@mail.com",
                 UserPass = BCrypt.Net.BCrypt.HashPassword("abc_123"),
                 UserRoleID = 1
             }); ;

            modelBuilder.Entity<UserInfo>().HasData(
             new UserInfo
             {
                 UserInfoID = 2,
                 UserName = "Admin",
                 UserEmail = "Admin@FlawlessFeedback.com",
                 UserPass = BCrypt.Net.BCrypt.HashPassword("FlawlessFeedback!21"),
                 UserRoleID = 1
             });

            modelBuilder.Entity<UserInfo>().HasData(
             new UserInfo
             {
                 UserInfoID = 3,
                 UserName = "Lyam",
                 UserEmail = "lyam@email.com",
                 UserPass = BCrypt.Net.BCrypt.HashPassword("lyam"),
                 UserRoleID = 2
             });
        }
    }
}