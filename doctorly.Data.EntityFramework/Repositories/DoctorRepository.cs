using doctorly.Core.Models;
using doctorly.Core.ServiceInterfaces;
using doctorly.Data.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace doctorly.Data.EntityFramework.Repositories
{
    public class DoctorRepository : BaseRepository, IDoctorRepository
    {
        public DoctorRepository(DoctorlyDbContext context)
        {
            _context = context;
        }
        public Doctor? Get(int id)
        {
            return _context.Doctors
                            .Where(x => x.Id == id)
                            .Select(e => e.ToModel())
                            .SingleOrDefault();
        }

        public async Task<Doctor?> GetAsync(int id)
        {
            return await _context.Doctors
                 .Where(x => x.Id == id)
                 .Select(x => x.ToModel())
                 .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Doctor?>> GetAllAsync()
        {
            var models = await _context.Doctors
                 .OrderBy(i => i.Name)
                 .Select(x => x.ToModel())
                 .ToListAsync();

            return models;
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _context.Doctors
                 .OrderBy(i => i.Name)
                 .Select(x => x.ToModel());
        }
    }
}
