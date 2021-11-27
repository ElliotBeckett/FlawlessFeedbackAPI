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
    public class SurveyController : ControllerBase
    {
        #region Setup

        private readonly FFDBContext _context;

        public SurveyController(FFDBContext context)
        {
            _context = context;
        }

        #endregion Setup

        #region Get

        // GET: api/<SurveyController>
        /// <summary>
        /// Get a list of all Surveys
        /// </summary>
        /// <returns>List of Surveys</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Survey>> Get()
        {
            var survey = _context.Surveys.ToList();

            if (survey == null)
            {
                return BadRequest();
            }

            return Ok(survey);
        }

        // GET api/<SurveyController>/5
        /// <summary>
        /// Get a single survey by ID
        /// </summary>
        /// <param name="id"> ID of the survey to retrieve</param>
        /// <returns>Single survey entry</returns>
        [HttpGet("{id}")]
        public ActionResult<Survey> Get(int id)
        {
            var survey = _context.Surveys.Where(s => s.SurveyID == id).FirstOrDefault();

            if (survey == null)
            {
                return BadRequest();
            }

            return Ok(survey);
        }

        /// <summary>
        /// Returns the count of all surveys
        /// </summary>
        /// <returns>Integer count of all surveys</returns>
        [HttpGet("GetCount")]
        public int GetCount()
        {
            IQueryable<Survey> surveys = _context.Surveys.AsQueryable();
            int count = 0;

            count = surveys.Count();
            return count;
        }

        #endregion Get

        // POST api/<SurveyController>
        /// <summary>
        /// Creates a new survey
        /// </summary>
        /// <param name="survey">Survey to create</param>
        /// <returns>Created survey</returns>
        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public ActionResult Post([FromBody] Survey survey)
        {
            if (ModelState.IsValid)
            {
                _context.Surveys.Add(survey);
                _context.SaveChanges();
                return CreatedAtAction("Post", survey);
            }

            return BadRequest();
        }

        // PUT api/<SurveyController>/5
        /// <summary>
        /// Updates a selected survey by ID
        /// </summary>
        /// <param name="id">ID of the survey to update</param>
        /// <param name="survey">Updated details of the survey</param>
        /// <returns>Updated survey</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Put(int id, Survey survey)
        {
            if (survey != null)
            {
                _context.Entry(survey).State = EntityState.Modified;

                try
                {
                    _context.SaveChanges();
                    return Ok(survey);

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
        /// Deletes a survey by ID
        /// </summary>
        /// <param name="id">ID of the survey to delete</param>
        /// <returns>Deleted survey</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var survey = _context.Surveys.Find(id);

            if (survey != null)
            {
                _context.Remove(survey);

                try
                {
                    _context.SaveChanges();
                    return Ok(survey);
                }
                catch (DbUpdateException)
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }

        #region Custom Methods

        /// <summary>
        /// Returns a Survey with its attached Questions.
        /// </summary>
        /// <param name="id">ID of the survey</param>
        /// <returns>Survey object with attached questions</returns>
        // GET api/<SurveyController>/5
        [HttpGet("GetSurveyWithQuestions/{id}")]
        public ActionResult<Survey> GetSurveyWithQuestions(int id)
        {
            var survey = _context.Surveys.Where(s => s.SurveyID == id).Include(q => q.Questions).FirstOrDefault();

            if (survey == null)
            {
                return BadRequest();
            }

            return Ok(survey);
        }

        #endregion
    }
}