using doctorly.Data.EntityFramework.Context;

namespace doctorly.Data.EntityFramework.Repositories
{
    public abstract class BaseRepository
    {
        protected DoctorlyDbContext _context { get; set; }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
