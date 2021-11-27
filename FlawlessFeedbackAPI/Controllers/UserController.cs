using FlawlessFeedbackAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using BCryptNet = BCrypt.Net.BCrypt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlawlessFeedbackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Setup + CTOR

        // Database connection
        private readonly FFDBContext _context;

        public UserController(FFDBContext context)
        {
            _context = context;
        }

        #endregion Setup + CTOR

        // GET: api/<UserController>
        /// <summary>
        /// Gets a list of all users
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet]
        public ActionResult<IEnumerable<UserInfo>> Get()
        {
            var users = _context.UserInfos.ToList();

            if (users == null)
            {
                return BadRequest();
            }

            return Ok(users);
        }

        /// <summary>
        /// Gets all users and attached role
        /// </summary>
        /// <returns>List of users with roles</returns>
        [HttpGet("GetAllWithUserRole")]
        public ActionResult<IEnumerable<UserInfo>> GetAllWithUserRole()
        {
            var users = _context.UserInfos.Include(u => u.UserRole).ToList();

            if (users == null)
            {
                return BadRequest();
            }

            return Ok(users);
        }

        // GET api/<UserController>/5
        /// <summary>
        /// Gets a single user by ID
        /// </summary>
        /// <param name="id">ID of the user</param>
        /// <returns>Single user</returns>

        [HttpGet("{id}")]
        public ActionResult<UserInfo> Get(int id)
        {
            // Added FirstOrDefault() to prevent JSON serialization issues
            var user = _context.UserInfos.Where(u => u.UserInfoID == id).FirstOrDefault();

            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }

        /// <summary>
        /// Gets a single user by ID with attached role
        /// </summary>
        /// <param name="id">ID of the user</param>
        /// <returns>Single user with attached role</returns>

        [HttpGet("GetSingleUserWithRole/{id}")]
        public ActionResult<UserInfo> GetSingleUserWithRole(int id)
        {
            // Added FirstOrDefault() to prevent JSON serialization issues
            var user = _context.UserInfos.Where(u => u.UserInfoID == id).Include(u => u.UserRole).FirstOrDefault();

            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }

        /// <summary>
        /// Gets a count of all users in the database
        /// </summary>
        /// <returns>Integer count of all users</returns>
        [HttpGet("GetCount")]
        public int GetCount()
        {
            IQueryable<UserInfo> users = _context.UserInfos.AsQueryable();
            int count = 0;

            count = users.Count();
            return count;
        }

        // POST api/<UserController>
        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">User to create</param>
        /// <returns>Created user</returns>
        [HttpPost]
        public ActionResult Post([FromBody] UserInfo user)
        {
            // Ensures that the created user starts with User permissions and
            // not admin permissions etc
            user.UserRoleID = 2;
            // Hashing the user's password for security
            user.UserPass = BCryptNet.HashPassword(user.UserPass);

            if (ModelState.IsValid)
            {
                _context.UserInfos.Add(user);
                _context.SaveChanges();
                return CreatedAtAction("Post", user);
            }

            return BadRequest();
        }

        // PUT api/<UserController>/5
        /// <summary>
        /// Updates a selected user
        /// </summary>
        /// <param name="id">ID of the user</param>
        /// <param name="user">Updated details of the user</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,User")]
        public ActionResult Put(int id, UserInfo user)
        {
            if (user != null)
            {
                // Hashing the user's password for security
                user.UserPass = BCryptNet.HashPassword(user.UserPass);

                _context.Entry(user).State = EntityState.Modified;

                try
                {
                    _context.SaveChanges();
                    return Ok(user);
                }
                catch (DbUpdateException)
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }

        // DELETE api/<UserController>/5
        /// <summary>
        /// Deletes a user by ID
        /// </summary>
        /// <param name="id">ID of the user to remove</param>
        /// <returns>Deleted user</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var user = _context.UserInfos.Find(id);

            if (user != null)
            {
                _context.Remove(user);

                try
                {
                    _context.SaveChanges();
                    return Ok(user);
                }
                catch (DbUpdateException)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}