using doctorly.Data.EntityFramework.Context;

namespace doctorly.Data.EntityFramework.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly DoctorlyDbContext _context;
    }
}
