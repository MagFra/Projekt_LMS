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

namespace Lexicon_LMS.Server.Controllers
{
    [Route("api/activities")]
    [ApiController]
	[Authorize]
	public class ActivitiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Activities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activities>>> Getactivity()
        {
          if (_context.activity == null)
          {
              return NotFound();
          }
            return await _context.activity.ToListAsync();
        }

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Activities>> GetActivities(int id)
        {
           var activity = await _context.activity
                  .Include(a => a.AssignmentsLista)
                  .FirstOrDefaultAsync(a => a.Id == id);

            if (activity == null)
            {
                return NotFound();
            }

            return activity;
        }

        // PUT: api/Activities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
		[Authorize(Roles = "Teacher")]
		public async Task<IActionResult> PutActivities(int id, Activities activities)
        {
            if (id != activities.Id)
            {
                return BadRequest();
            }

            _context.Entry(activities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivitiesExists(id))
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

        // POST: api/Activities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
		[Authorize(Roles = "Teacher")]
		public async Task<ActionResult<Activities>> PostActivities(Activities activities)
        {
          if (_context.activity == null)
          {
              return Problem("Entity set 'ApplicationDbContext.activity'  is null.");
          }
            _context.activity.Add(activities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivities", new { id = activities.Id }, activities);
        }

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
		[Authorize(Roles = "Teacher")]
		public async Task<IActionResult> DeleteActivities(int id)
        {
            if (_context.activity == null)
            {
                return NotFound();
            }
            var activities = await _context.activity.FindAsync(id);
            if (activities == null)
            {
                return NotFound();
            }

            _context.activity.Remove(activities);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActivitiesExists(int id)
        {
            return (_context.activity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
