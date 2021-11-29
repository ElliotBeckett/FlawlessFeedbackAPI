using FlawlessFeedbackAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace FlawlessFeedbackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        #region Setup + Ctor

        public IConfiguration _configuration;
        private readonly FFDBContext _context;

        public TokenController(IConfiguration config, FFDBContext context)
        {
            _configuration = config;
            _context = context;
        }

        #endregion Setup + Ctor

        #region End Points

        /// <summary>
        /// Generate an authentication Token for an existing user
        /// </summary>
        /// <param name="_userData">Details of the user</param>
        /// <returns>JSON web token</returns>

        [HttpPost] // - Post request, so data must be sent with the request
        // Creates a custom route for the method
        [Route("GenerateToken")]
        public IActionResult GenerateToken(UserInfo _userData)
        {
            // All of the null checks
            if (_userData != null && _userData.UserEmail != null && _userData.UserPass != null)
            {
                // retrieve the user for these credentials
                var user = CheckUser(_userData.UserEmail, _userData.UserPass);
                // If we have a user that matches the credentials
                if (user != null)
                {
                    // create claims details based on the user information -
                    // Adds the claims into a list of claims (Items that relate to the user)
                    var claims = new List<Claim> {
                    // JWT Subject
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    // JWT ID
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    // JWT Date/Time
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                    // JWT User ID
                    new Claim("Id", user.UserInfoID.ToString()),
                    // JWT UserName
                    new Claim("UserName", user.UserName)
                   };

                    var userRole = GetUserRole(user.UserName, user.UserRoleID);

                    // TODO Adding the Roles to the token
                    if (userRole != null)
                    {
                        foreach (var role in user.UserRole.UserRoleTitle.Split(','))
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role));
                        }
                    }
                    // Generate a new key based on the Key we created and stored in appsettings.json
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    // use the generated key to generate new Signing Credentials
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    // Generate a new token based on all of the details generated so far
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        // How long the JWT will be valid for
                        expires: DateTime.Now.AddHours(5),
                        signingCredentials: signIn);
                    // Return the Token via JSON
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        #endregion End Points

        #region Custom Methods

        // Hashed password check -
        // Provided by Shaun O'Sullivan - Class tracker API - Week 13 with Auth, Hashing and user roles
        private UserInfo CheckUser(string userEmail, string password)
        {
            var user = _context.UserInfos.FirstOrDefault(u => u.UserEmail == userEmail);

            // Using BCrypt to check hashed password against provided password
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.UserPass))
            {
                return user;
            }
            return null;
        }

        [HttpPost] // - Post request, so data must be sent with the request
        // Creates a custom route for the method
        [Route("GetUserName")]
        public string GetUserName(UserInfo user)
        {
            var userName = _context.UserInfos.FirstOrDefault(u => u.UserEmail == user.UserEmail).UserName;

            if (!String.IsNullOrWhiteSpace(userName))
            {
                return userName;
            }

            return null;
        }

        private string GetUserRole(string userName, int roleID)
        {
            var user = _context.UserInfos.FirstOrDefault(u => u.UserName == userName);
            var userRoleID = user.UserRoleID;
            var userRoleTitle = _context.UserRoles.FirstOrDefault(r => r.UserRoleID == userRoleID).UserRoleTitle;

            if (user.UserRoleID == roleID && userRoleID == roleID)
            {
                return userRoleTitle.ToString();
            }

            return null;
        }

        #endregion Custom Methods
    }
}