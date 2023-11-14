using doctorly.Core.Models;
using doctorly.Core.ServiceInterfaces;
using doctorly.Data.EntityFramework.Context;
using doctorly.Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace doctorly.Data.EntityFramework.Repositories
{
    public class EventRepository : BaseRepository, IEventRepository
    {
        public EventRepository(DoctorlyDbContext context)
        {
            _context = context;
        }

        public Event? Get(int id)
        {
            var entity = GetInternal(id);
            return (entity == null)
                ? null 
                : entity.ToModel();
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

        public Event Add(Event eventModel)
        {
            var entity = EventEntity.FromModel(eventModel);
            var result = _context.Events.Add(entity);
            _context.SaveChanges();
            return result.Entity.ToModel();
        }

        public Event Update(int id, Event eventModel)
        {
            var entity = GetInternal(id);
            if (entity == null)
            {
                //TODO Create Cusom Exception;
                throw new Exception("Event Not Found");
            }
                entity.Update(EventEntity.FromModel(eventModel));
                var result = _context.Events.Update(entity);
                _context.SaveChanges();
                return result.Entity.ToModel();
        }

        private EventEntity? GetInternal(int id)
        {
            return _context.Events
                        .Where(x => x.Id == id)
                        .SingleOrDefault();
        }
    }
}
