using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lexicon_LMS.Server.Data;
using Lexicon_LMS.Server.Models.Entities;
using Lexicon_LMS.Server.Services;
using Lexicon_LMS.Server.Models.Profiles;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Lexicon_LMS.Shared.Domain.ModulesDTOs;

namespace Lexicon_LMS.Server.Controllers
{
    [Route("api/modules")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IModuleService _moduleService;
        private readonly IMapper _mapper;

        public ModulesController(ApplicationDbContext context, IModuleService moduleService, IMapper mapper)
        {
            _context = context;
            _moduleService = moduleService;
            _mapper = mapper;
        }

        // GET: api/Modules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Module>>> Getmodule()
        {
            if (_context.module == null)
            {
                return NotFound();
            }

            //var result = await _context.module.Select(m => new ModuleDTO
            //{
            //    Id = m.Id,
            //    CourseId = m.CourseId,
            //    Name = m.Name!,
            //    Description = m.Description!,
            //    StartDate = m.StartDate,
            //    LengthOfDays = m.LengthOfDays
            //}).ToListAsync();

            //var result = await _moduleService.GetModuleListAsync();

            var result = await _context.module.ToListAsync();

            return Ok(result);
        }
       


        // GET: api/Modules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Module>> GetModule(int id)
        {
          if (_context.module == null)
          {
              return NotFound();
          }
            var @module = await _context.module.FindAsync(id);

            //var @module = await _moduleService.GetModuleAsync(id);

            if (@module == null)
            {
                return NotFound();
            }
            
            return Ok(@module);
        }

        // PUT: api/Modules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModule(int id, ModuleForUpdateDTO @module)
        {
            if (id != @module.Id)
            {
                return BadRequest();
            }

            var resul = await _moduleService.UpdateModuleAssync(id, @module);
            return resul ? Ok() : NotFound();
            //var result = _mapper.Map<Module>(@module);

            //_context.Entry(result).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ModuleExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

        //POST: api/Modules
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Module>> PostModule(ModuleForCreationDTO @module)
        {
            if (_context.module == null)
            {
                return Problem("Entity set 'ApplicationDbContext.module'  is null.");
            }
            //var result = _mapper.Map<Module>(@module);
            var result = await _moduleService.AddModuleAsync(@module);
            //_context.module.Add(result);
            //await _context.SaveChangesAsync();
            //var result2 = _mapper.Map<ModuleDTO>(result);

            return CreatedAtAction("GetModule", new { id = result.Id }, result);
        }

        // DELETE: api/Modules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            if (_context.module == null)
            {
                return NotFound();
            }
            var @module = await _context.module.FindAsync(id);
            if (@module == null)
            {
                return NotFound();
            }

            _context.module.Remove(@module);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModuleExists(int id)
        {
            return (_context.module?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
