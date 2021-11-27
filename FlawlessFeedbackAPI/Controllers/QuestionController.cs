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
    public class QuestionController : ControllerBase
    {
        #region Setup

        private readonly FFDBContext _context;

        public QuestionController(FFDBContext context)
        {
            _context = context;
        }

        #endregion Setup

        #region Get Methods

        /// <summary>
        /// Get method to return a list of all Questions
        /// </summary>
        /// <returns>List of all questions</returns>

        // GET: api/<QuestionController>
        [HttpGet]
        public ActionResult<IEnumerable<Question>> Get()
        {
            var question = _context.Questions.ToList();

            if (question == null)
            {
                return BadRequest();
            }

            return Ok(question);
        }

        /// <summary>
        /// Get method to return a single Question
        /// </summary>
        /// <param name="id">ID of the question to retrieve</param>
        /// <returns>A single question</returns>

        // GET api/<QuestionController>/5
        [HttpGet("{id}")]
        public ActionResult<Question> Get(int id)
        {
            var question = _context.Questions.Where(q => q.QuestionID == id).FirstOrDefault();

            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        /// <summary>
        /// Get method to return Questions linked to a particular survey
        /// </summary>
        /// <param name="id">ID of the survey</param>
        /// <returns>List of questions attached to a survey</returns>
        [HttpGet("BySurveyID/{id}")]
        public ActionResult<IEnumerable<Question>> GetBySurveyID(int id)
        {
            var question = _context.Surveys.Find(id).Questions;

            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        /// <summary>
        /// Get method to get a count of all questions
        /// </summary>
        /// <returns>Integer count of all questions</returns>
        [HttpGet("GetCount")]
        public int GetCount()
        {
            IQueryable<Question> questions = _context.Questions.AsQueryable();
            int count = 0;

            count = questions.Count();
            return count;
        }

        #endregion Get Methods

        /// <summary>
        /// Post method to create a new question
        /// </summary>
        /// <param name="question">Question object to create</param>
        /// <returns>Created question</returns>

        // POST api/<QuestionController>
        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public ActionResult Post([FromBody] Question question)
        {
            if (ModelState.IsValid)
            {
                _context.Questions.Add(question);
                _context.SaveChanges();
                return CreatedAtAction("Post", question);
            }

            return BadRequest();
        }

        /// <summary>
        /// Put method to update a question
        /// </summary>
        /// <param name="id">ID of the question to update</param>
        /// <param name="question">Updated question</param>
        /// <returns>Updated question</returns>

        // PUT api/<QuestionController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Put(int id, Question question)
        {
            if (question != null)
            {
                _context.Entry(question).State = EntityState.Modified;

                try
                {
                    _context.SaveChanges();
                    return Ok(question);
                }
                catch (DbUpdateException)
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }

        /// <summary>
        /// Delete method to delete a question
        /// </summary>
        /// <param name="id">Question to delete</param>
        /// <returns></returns>

        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var question = _context.Questions.Find(id);

            if (question != null)
            {
                _context.Remove(question);

                try
                {
                    _context.SaveChanges();
                    return Ok(question);
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
        /// Returns a Question and its attached options
        /// </summary>
        /// <param name="id">Id of the question to get</param>
        /// <returns>Question object and attached Options</returns>
        // GET api/<QuestionController>/5
        [HttpGet("GetQuestionsWithOptions/{id}")]
        public ActionResult<Question> GetQuestionsWithOptions(int id)
        {
            var question = _context.Questions.Where(q => q.QuestionID == id).Include(o => o.Options).FirstOrDefault();

            if (question == null)
            {
                return BadRequest();
            }

            return Ok(question);
        }

        #endregion Custom Methods
    }
}