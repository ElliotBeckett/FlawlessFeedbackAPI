using FlawlessFeedbackAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    public class OptionController : ControllerBase
    {
        #region Setup

        private readonly FFDBContext _context;

        public OptionController(FFDBContext context)
        {
            _context = context;
        }

        #endregion

        #region Get Methods
        // GET: api/<OptionController>
        /// <summary>
        /// Gets a list of all options
        /// </summary>
        /// <returns>List of all options</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Option>> Get()
        {
            var option = _context.Options.ToList();

            if(option == null) 
            {
                return BadRequest();
            }

            return Ok(option);
        }

        // GET api/<OptionController>/5
        /// <summary>
        /// Gets a single option by ID
        /// </summary>
        /// <param name="id">ID of option to return</param>
        /// <returns>Single option</returns>
        [HttpGet("{id}")]
        public ActionResult<Option> Get(int id)
        {
            var option = _context.Options.Where(q => q.OptionID == id).FirstOrDefault();

            if(option == null) 
            {
                return NotFound();
            }

            return Ok(option);
        }

        /// <summary>
        /// Gets all options linked to a single question
        /// </summary>
        /// <param name="id">ID of the question to retrieve</param>
        /// <returns>Option(s) that are linked to a quesiton</returns>
        [HttpGet("ByQuestionID/{id}")]
        public ActionResult<IEnumerable<Option>> GetByQuestionID(int id) 
        {
            
            var option = _context.Questions.Where(q => q.QuestionID == id).Include(q => q.Options).FirstOrDefault();

            if (option == null)
            {
                return NotFound();
            }

            return Ok(option);
        }

        /// <summary>
        /// Gets the count of all options
        /// </summary>
        /// <returns>Integer of all options</returns>
        [HttpGet("GetCount")]
        public int GetCount() 
        {
            IQueryable<Option> options = _context.Options.AsQueryable();
            int count = 0;

            count = options.Count();
            return count;
        }
        #endregion

        // POST api/<OptionController>

        /// <summary>
        /// Creates a new option based upon values supplied
        /// </summary>
        /// <param name="option">new option to create</param>
        /// <returns>Created option</returns>
        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public ActionResult Post([FromBody] Option option)
        {
            if (ModelState.IsValid)
            {
                _context.Options.Add(option);
                _context.SaveChanges();
                return CreatedAtAction("Post", option);
            }

            return BadRequest();
        }

        // PUT api/<SurveyController>/5
        /// <summary>
        /// Updates a single option with values supplied
        /// </summary>
        /// <param name="id">ID of the option to Update</param>
        /// <param name="option">Values to update</param>
        /// <returns>Updated option</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Put(int id, Option option)
        {
            if (option != null)
            {
                _context.Entry(option).State = EntityState.Modified;

                try
                {
                    _context.SaveChanges();
                    return Ok(option);

                }
                catch (DbUpdateException)
                {
                    return BadRequest();
                }

            }

            return BadRequest();

        }

        // DELETE api/<QuestionController>/5
        /// <summary>
        /// Deletes a single option by ID
        /// </summary>
        /// <param name="id">ID of the option to delete</param>
        /// <returns>Deleted option</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var option = _context.Options.Find(id);

            if (option != null)
            {
                _context.Remove(option);

                try
                {
                    _context.SaveChanges();
                    return Ok(option);
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