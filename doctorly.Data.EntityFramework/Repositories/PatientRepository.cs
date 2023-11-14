using doctorly.Core.Models;
using doctorly.Core.ServiceInterfaces;
using doctorly.Data.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace doctorly.Data.EntityFramework.Repositories
{
    public class PatientRepository : BaseRepository, IPatientRepository
    {
        public PatientRepository(DoctorlyDbContext context)
        {
            _context = context;
        }
        public Patient? Get(int id)
        {
            return _context.Patients
                            .Where(x => x.Id == id)
                            .Select(e => e.ToModel())
                            .SingleOrDefault();
        }

        public async Task<Patient?> GetAsync(int id)
        {
            return await _context.Patients
                 .Where(x => x.Id == id)
                 .Select(x => x.ToModel())
                 .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Patient?>> GetAllAsync()
        {
            var models = await _context.Patients
                 .OrderBy(i => i.Name)
                 .Select(x => x.ToModel())
                 .ToListAsync();

            return models;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients
                 .OrderBy(i => i.Name)
                 .Select(x => x.ToModel());
        }
    }
}
