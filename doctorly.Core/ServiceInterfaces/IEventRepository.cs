using doctorly.Core.Models;

namespace doctorly.Core.ServiceInterfaces
{
    public interface IEventRepository : IRepository<Models.Event>
    {
        Event Add(Event eventModel);
        Event Update(int id, Event eventModel);
    }
}
