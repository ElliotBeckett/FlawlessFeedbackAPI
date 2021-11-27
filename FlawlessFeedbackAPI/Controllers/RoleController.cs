using FlawlessFeedbackAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlawlessFeedbackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Lock down the entire controller to Admins only
    [Authorize(Roles = ("Admin"))]
    public class RoleController : ControllerBase
    {
        #region Setup + CTOR

        private readonly FFDBContext _context;

        public RoleController(FFDBContext context)
        {
            _context = context;
        }


        #endregion

        // GET: api/<RoleController>
        /// <summary>
        /// Get a list of all user roles
        /// </summary>
        /// <returns>List of user roles</returns>
        [HttpGet]
        public ActionResult<IEnumerable<UserRole>> Get()
        {
            var roles = _context.UserRoles.ToList();

            if(roles == null) 
            {
                return BadRequest();
            }

            return Ok(roles); 

        }

        /// <summary>
        /// Gets all the users with the specific role
        /// </summary>
        /// <param name="id">ID of the role to search by</param>
        /// <returns>List of users</returns>
        [HttpGet("GetRoleWithUsers/{id}")]
        public ActionResult<IEnumerable<UserRole>> GetRoleWithUsers(int id) 
        {
            // TODO - Clean this up
            var role = _context.UserInfos.Where(u => u.UserRoleID == id).Include(r => r.UserRole).OrderBy(r => r.UserRole.UserRoleTitle).ToList();

            if(role == null) 
            {
                return BadRequest();
            }

            return Ok(role);
        }

        // GET api/<RoleController>/5
        /// <summary>
        /// Gets a single role by ID
        /// </summary>
        /// <param name="id">ID of the role to get</param>
        /// <returns>Single role details</returns>
        [HttpGet("{id}")]
        public ActionResult<UserRole> Get(int id)
        {
            var role = _context.UserRoles.Where(r => r.UserRoleID == id).FirstOrDefault();

            if (role == null)
            {
                return BadRequest();
            }

            return Ok(role);
        }

        // POST api/<RoleController>
        /// <summary>
        /// Creates a new user role
        /// </summary>
        /// <param name="role">Role to create</param>
        /// <returns>Created role</returns>
        [HttpPost]
        public ActionResult Post([FromBody] UserRole role)
        {
            if (ModelState.IsValid) 
            {
                _context.UserRoles.Add(role);
                // TODO - Add Try catch for every Post Method
                _context.SaveChanges();
                return CreatedAtAction("Post", role);

            }

            return BadRequest();
        }

        // PUT api/<RoleController>/5
        /// <summary>
        /// Updates a selected role 
        /// </summary>
        /// <param name="id">ID of the Role to update</param>
        /// <param name="role">Updated details of the role</param>
        /// <returns>Updated role</returns>
        [HttpPut("{id}")]
        public ActionResult Put(int id, UserRole role)
        {
            if(role != null) 
            {
                _context.Entry(role).State = EntityState.Modified;

                try
                {
                    _context.SaveChanges();
                    return Ok(role);
                }
                catch (DbUpdateException)
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var role = _context.UserRoles.Find(id);

            if (role != null)
            {
                _context.Remove(role);

                try
                {
                    _context.SaveChanges();
                    return Ok(role);
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
