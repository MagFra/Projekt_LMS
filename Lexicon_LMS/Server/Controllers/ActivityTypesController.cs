﻿using System;
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
    [Route("api/[controller]")]
    [ApiController]
	[Authorize]
	public class ActivityTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ActivityTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ActivityTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityType>>> GetActivityType()
        {
          if (_context.activityType == null)
          {
              return NotFound();
          }
            return await _context.activityType.ToListAsync();
        }

        // GET: api/ActivityTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityType>> GetActivityType(int id)
        {
          if (_context.activityType == null)
          {
              return NotFound();
          }
            var activityType = await _context.activityType.FindAsync(id);

            if (activityType == null)
            {
                return NotFound();
            }

            return activityType;
        }

        // PUT: api/ActivityTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
		[Authorize(Roles = "Teacher")]
		public async Task<IActionResult> PutActivityType(int id, ActivityType activityType)
        {
            if (id != activityType.Id)
            {
                return BadRequest();
            }

            _context.Entry(activityType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityTypeExists(id))
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

        // POST: api/ActivityTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
		[Authorize(Roles = "Teacher")]
		public async Task<ActionResult<ActivityType>> PostActivityType(ActivityType activityType)
        {
          if (_context.activityType == null)
          {
              return Problem("Entity set 'ApplicationDbContext.ActivityType'  is null.");
          }
            _context.activityType.Add(activityType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivityType", new { id = activityType.Id }, activityType);
        }

        // DELETE: api/ActivityTypes/5
        [HttpDelete("{id}")]
		[Authorize(Roles = "Teacher")]
		public async Task<IActionResult> DeleteActivityType(int id)
        {
            if (_context.activityType == null)
            {
                return NotFound();
            }
            var activityType = await _context.activityType.FindAsync(id);
            if (activityType == null)
            {
                return NotFound();
            }

            _context.activityType.Remove(activityType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActivityTypeExists(int id)
        {
            return (_context.activityType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
