using doctorly.Core.Models;
using doctorly.Core.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace doctorly.Data.EntityFramework.Repositories
{
    public class EventRepository : BaseRepository, IEventRepository
    {
        public Event? Get(int id)
        {
            return _context.Events
                            .Where(x => x.Id == id)
                            .Select(e => e.ToModel())
                            .SingleOrDefault();
        }

        public async Task<Event?> GetAsync(int id)
        {
            return await _context.Events
                 .Where(x => x.Id == id)
                 .Select(x => x.ToModel())
                 .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Event?>> GetAllAsync()
        {
            var models = await _context.Events
                 .OrderBy(i => i.Title)
                 .Select(x => x.ToModel())
                 .ToListAsync();

            return models;
        }

        public IEnumerable<Event> GetAll()
        {
            return _context.Events
                 .OrderBy(i => i.Title)
                 .Select(x => x.ToModel());
        }

        
    }
}
