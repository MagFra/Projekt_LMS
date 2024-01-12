using AutoMapper;
using Lexicon_LMS.Server.Data;
using Lexicon_LMS.Server.Models.Entities;
using Lexicon_LMS.Shared.Domain.ModulesDTOs;
using Lexicon_LMS.Shared.Domain.ActivitiesDTOs;
using Lexicon_LMS.Shared.Domain.CoursesDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lexicon_LMS.Server.Services
{
    public class ModuleService : IModuleService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ModuleService(IMapper mapper, ApplicationDbContext dbContext)
        {
            _db = dbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ModuleDTO>?> GetModuleListAsync(int? corseId = null)
        {
            var modules = (corseId is null) ? await _db.module.Include(m => m.Activities).Include(m => m.Course).ToListAsync()
                : await _db.module.Where(m => m.CourseId == corseId).Include(m => m.Activities).Include(m => m.Course).ToListAsync();

            if (modules == null || modules.Count == 0) { return null; }

            var dto = modules.Select(m => new ModuleDTO
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                StartDate = m.StartDate,
                LengthOfDays = m.LengthOfDays,
                CourseId = m.CourseId,
                Activities = m.Activities!.Select(a => new ActivityLimitedDTO { Id = a.Id, Name = a.Name, StartDate = a.StartDate, LenthDays = a.LenthDays }).ToList(),
                Course = new CourseLimitedDTO { Id = m.Course!.Id, Name = m.Course.Name, StartDate = m.Course.StartDate, LengthDays = m.Course.LengthDays, }
            }).ToList();

            return dto;
        }

        public async Task<ModuleDTO?> GetModuleAsync(int moduleId)
        {
            var module = await _db.module
                .Where(m => m.Id == moduleId)
                .Include(m => m.Activities)
                .Include(m => m.Course)
                .FirstOrDefaultAsync();

            if (module == null) { return null; }

            var c = module.Course;
            var result = new ModuleDTO
            {
                Id = module.Id,
                Name = module.Name,
                Description = module.Description,
                StartDate = module.StartDate,
                LengthOfDays = module.LengthOfDays,
                CourseId = module.CourseId,
                Activities = module.Activities!.Select(a => new ActivityLimitedDTO { Id = a.Id, Name = a.Name, StartDate = a.StartDate, LenthDays = a.LenthDays }).ToList(),
                Course = new CourseLimitedDTO { Id = c!.Id, Name = c.Name, StartDate = c.StartDate, LengthDays = c.LengthDays, }
            };

            return result;
        }

        public async Task<ModuleDTO> AddModuleAsync(ModuleForCreationDTO dto)
        {
            var module = _mapper.Map<Module>(dto);
            await _db.module.AddAsync(module);
            await _db.SaveChangesAsync();
            return _mapper.Map<ModuleDTO>(module);
        }

        public async Task<bool> UpdateModuleAssync(int id, ModuleForUpdateDTO dto)
        {
            if (dto != null && id == dto.Id)
            {
                // Testa att dto innehåller "valid" data!
                var module = _mapper.Map<Module>(dto);
                try
                {
                    _db.Entry(module).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
            return false;
        }


        public async Task<bool> DeleteModuleAssync(int moduleId)
        {
            var module = await _db.module.FindAsync(moduleId);

            if (module != null)
            {
                try
                {
                    _db.module.Remove(module);
                    await _db.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        private bool ModuleExists(int id)
        {
            return (_db.module?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
