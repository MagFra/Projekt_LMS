using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Lexicon_LMS.Server.Data;
using Lexicon_LMS.Server.Models.Entities;
using Lexicon_LMS.Server.Services;
using Lexicon_LMS.Shared.Domain.ModulesDTOs;

namespace Lexicon_LMS.Server.Controllers
{
    [Route("api/modules")]
    [ApiController]
	[Authorize]
	public class ModulesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IModuleService _moduleService;

        public ModulesController(ApplicationDbContext context, IModuleService moduleService)
        {
            _context = context;
            _moduleService = moduleService;
        }

        // GET: api/Modules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Module>>> Getmodule()
        {
            if (_context.module == null)
            {
                return NotFound("No modules in database!");
            }

            var result = await _moduleService.GetModuleListAsync();

            return Ok(result);
        }
       


        // GET: api/Modules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModuleDTO>> GetModule(int id)
        {
          if (_context.module == null)
          {
              return NotFound("No modules in database!");
          }

            var @module = await _moduleService.GetModuleAsync(id);

            if (@module == null)
            {
                return NotFound($"Could not find module with ID={id}!");
            }
            
            return Ok(@module);
        }

        // PUT: api/Modules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
		[Authorize(Roles = "Teacher")]
		public async Task<IActionResult> PutModule(int id, ModuleForUpdateDTO @module)
        {
            if (id != @module.Id)
            {
                return BadRequest("IDs don't match!");
            }

            var resul = await _moduleService.UpdateModuleAssync(id, @module);
            return resul ? Ok("Update ok!") : NotFound("Could not update!");
        }

        //POST: api/Modules
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //      [HttpPost]
        //[Authorize(Roles = "Teacher")]
        //public async Task<ActionResult<Module>> PostModule(ModuleForCreationDTO @module)
        //      {
        //          if (_context.module == null)
        //          {
        //              return Problem("Entity set 'ApplicationDbContext.module'  is null.");
        //          }
        //          //var result = _mapper.Map<Module>(@module);
        //          var result = await _moduleService.AddModuleAsync(@module);
        //          //_context.module.Add(result);
        //          //await _context.SaveChangesAsync();
        //          //var result2 = _mapper.Map<ModuleDTO>(result);

        //          return CreatedAtAction("GetModule", new { id = result.Id }, result);
        //      }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public async Task<ActionResult<Module>> PostModule(Module module)
        {
            if (_context.module == null)
            {
                return Problem("Entity set 'ApplicationDbContext.module'  is null.");
            }
            _context.module.Add(module);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModule", new { id = module.Id }, module);
        }


        // DELETE: api/Modules/5
        [HttpDelete("{id}")]
		[Authorize(Roles = "Teacher")]
		public async Task<IActionResult> DeleteModule(int id)
        {
            return (await _moduleService.DeleteModuleAssync(id)) ? Ok("Delete ok!") : NotFound("Could not delete!");
        }

        private bool ModuleExists(int id)
        {
            return (_context.module?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
