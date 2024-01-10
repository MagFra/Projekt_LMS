using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lexicon_LMS.Server.Data;
using Lexicon_LMS.Server.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Lexicon_LMS.Shared.Domain.CoursesDTOs;
using Lexicon_LMS.Shared.Domain.ModulesDTOs;
using Lexicon_LMS.Shared.Domain.UsersDTOs;

namespace Lexicon_LMS.Server.Controllers
{
    [Route("api/courses")]
    [ApiController]
    [Authorize]
    public class CoursesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<List<Courses>>> Getcourse()
        {
          if (_context.courses == null)
          {
              return NotFound();
          }
            return await _context.courses.ToListAsync();
        }

        // GET: api/Courses/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Courses>> GetCourse(int id)
        //{
        //  if (_context.courses == null)
        //  {
        //      return NotFound();
        //  }
        //    var course = await _context.courses.FindAsync(id);

        //    if (course == null)
        //    {
        //        return NotFound();
        //    }

        //    return course;
        //}


        // GET: api/Courses/5

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDTO>> GetCourse(int id)
        {
            var course = await _context.courses
                .Include(c => c.ModuleList)
                .Include(c => c.StudentList)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            var courseDTO = new CourseDTO
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                StartDate = course.StartDate,
                LengthDays = course.LengthDays,
                LastApplicationDay = course.LastApplicationDay,
                ModuleList = course.ModuleList!.Select(m => new ModuleDTO { Id = m.Id, Name = m.Name, Description = m.Description, StartDate = m.StartDate, LengthOfDays = m.LengthOfDays}).ToList(),
                StudentList = course.StudentList!.Select(s => new UserDTO { Id = s.Id, UserName = s.UserName!, FirstName = s.FirstName, LastName = s.LastName, EmailConfirmed = s.EmailConfirmed }).ToList()
            };

            return courseDTO;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> PutCourse(int id, Courses course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public async Task<ActionResult<Courses>> PostCourse(Courses course)
        {
          if (_context.courses == null)
          {
              return Problem("Entity set 'ApplicationDbContext.course'  is null.");
          }
            _context.courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            if (_context.courses == null)
            {
                return NotFound();
            }
            var course = await _context.courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return (_context.courses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
