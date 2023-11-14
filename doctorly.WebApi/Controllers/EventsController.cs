using doctorly.Core.ServiceInterfaces;
using doctorly.WebApi.Contracts.Event;
using Microsoft.AspNetCore.Mvc;

namespace doctorly.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public EventsController(IEventRepository eventRepository,
                                IWebHostEnvironment hostingEnvironment)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
            _hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(hostingEnvironment));
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Core.Models.Event>>> GetEvents()
        {
            var imageList = await _eventRepository.GetAllAsync();

            return Ok(imageList);
        }

        [HttpGet("{id}", Name = "GetEvent")]
        public async Task<ActionResult<Core.Models.Event>> GetImage(int id)
        {
            var eventModel = await _eventRepository.GetAsync(id);

            if (eventModel == null)
            {
                return NotFound();
            }

            return Ok(eventModel);
        }

        [HttpPost()]
        public async Task<ActionResult<Core.Models.Event>> CreateImage([FromBody] CreateEventRequest eventForCreation)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] UpdateEventRequest eventForUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
