using AutoMapper;
using Lexicon_LMS.Server.Data;
using Lexicon_LMS.Server.Models.Entities;
using Lexicon_LMS.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lexicon_LMS.Server.Services
{
    public class ModuleService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ModuleService(IMapper mapper, ApplicationDbContext dbContext)
        {
            _db = dbContext;
            _mapper = mapper;
        }
        public async Task<ModuleListDTO> GetModuleListAsync(int? corseId = null)
        {
            var modules = (corseId is null) ? await _db.module.Include(m => m.Activities).ToListAsync()
                : await _db.module.Where(m => m.CourseId == corseId).Include(m => m.Activities).ToListAsync();
            return _mapper.Map<ModuleListDTO>(modules);
        }

        public async Task<ModuleDTO> GetModuleAsync(int moduleId)
        {
            var module = await _db.module.Where(m => m.Id == moduleId).Include(m => m.Activities).FirstOrDefaultAsync();
            return _mapper.Map<ModuleDTO>(module);
        }

        public async void AddModuleAsync(ModuleForCreationDTO dto)
        {
            var module = _mapper.Map<Module>(dto);
            await _db.module.AddAsync(module);
            await _db.SaveChangesAsync();
        }

        public async void UpdateModuleAssync(ModuleForUpdateDTO dto)
        {
            var module = _mapper.Map<Module>(dto);
            var dest = await _db.module.FirstOrDefaultAsync(m => m.Id == module.Id);
        }
    }
}
