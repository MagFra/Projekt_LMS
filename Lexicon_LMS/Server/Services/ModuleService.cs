using AutoMapper;
using Lexicon_LMS.Server.Data;
using Lexicon_LMS.Server.Models.Entities;
using Lexicon_LMS.Shared.Domain.ModulesDTOs;
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
        public async Task<IEnumerable<ModuleDTO>> GetModuleListAsync(int? corseId = null)
        {
            var modules = (corseId is null) ? await _db.module.Include(m => m.Activities).ToListAsync()
                : await _db.module.Where(m => m.CourseId == corseId).Include(m => m.Activities).ToListAsync();

            List<ModuleDTO> modulesDTO = new List<ModuleDTO>();
            foreach (var module in modules) { modulesDTO.Add(_mapper.Map<ModuleDTO>(module)); }

            return modulesDTO; //new ModuleListDTO { ListOfModules = modulesDTO};
        }

        public async Task<ModuleDTO> GetModuleAsync(int moduleId)
        {
            var module = await _db.module.Where(m => m.Id == moduleId).Include(m => m.Activities).FirstOrDefaultAsync();
            return _mapper.Map<ModuleDTO>(module);
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
            // Testa att dto innehåller "valid" data!

            var module = _mapper.Map<Module>(dto);

            _db.Entry(module).State = EntityState.Modified;

            
                await _db.SaveChangesAsync();   // Bör omges av try/catch(Exception)!
            return true;

            // Bör förses med else{} och varning att modulen som försöker uppdateras inte kan hittas!

            // Bör förses med else{} och varning att inget skickades!            
        }


        public async void DeleteModuleAssync(int moduleId)
        {
            var module = await _db.module.FirstOrDefaultAsync(m => m.Id == moduleId);
            if (module != null)
            {
                _db.module.Remove(module);
                await _db.SaveChangesAsync();
            }
        }
    }
}
