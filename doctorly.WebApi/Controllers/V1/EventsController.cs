using doctorly.Core.ServiceInterfaces;
using doctorly.WebApi.Contracts;
using doctorly.WebApi.Contracts.V1;
using doctorly.WebApi.Contracts.V1.Event;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace doctorly.WebApi.Controllers.V1
{
    [Route("1.0/Events")]
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
        
        [SwaggerOperation("GetAllEvents")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Event>), description: "OK")]
        [SwaggerResponse(statusCode: 500, type: typeof(DoctorlyError), description: "Error")]
        public async Task<ActionResult<IEnumerable<Core.Models.Event>>> GetEvents()
        {
            var eventList = await _eventRepository.GetAllAsync();

            return Ok(eventList);
        }

        [HttpGet]
        [Route("{eventId}")]
        [SwaggerOperation("GetEvent")]
        [SwaggerResponse(statusCode: 200, type: typeof(Event), description: "OK")]
        [SwaggerResponse(statusCode: 400, type: typeof(ValidationResult), description: "Bad Request")]
        [SwaggerResponse(statusCode: 500, type: typeof(DoctorlyError), description: "Error")]
        public IActionResult GetEvent([FromRoute, Required] int eventId)
        {
            //Validate Input

            var dbEvent = _eventRepository.GetAsync(eventId).Result;

            return (dbEvent == null)
                    ? BadRequest(dbEvent)
                    : Ok(Contracts.V1.Event.Event.FromModel(dbEvent));
        }

        [HttpPost]
        [Route("Search")]
        [SwaggerOperation("SearchEvents")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Event>), description: "OK")]
        [SwaggerResponse(statusCode: 400, type: typeof(DoctorlyValidationResult), description: "Bad Request")]
        [SwaggerResponse(statusCode: 404, type: null, description: "Not Found")]
        [SwaggerResponse(statusCode: 500, type: typeof(DoctorlyError), description: "Error")]
        public IActionResult SearchEvents([FromBody] EventSearchFilters filters)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("Create")]
        [SwaggerOperation("CreateEvent")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Event>), description: "OK")]
        [SwaggerResponse(statusCode: 400, type: typeof(DoctorlyValidationResult), description: "Bad Request")]
        [SwaggerResponse(statusCode: 500, type: typeof(DoctorlyError), description: "Error")]
        public IActionResult CreateEvent([FromBody] CreateEventRequest eventToCreate)
        {
            if (eventToCreate == null)
                return BadRequest();

            //Validate?

            var dbEvent = _eventRepository.Add(eventToCreate.ToModel());

            return (dbEvent == null)
                    ? BadRequest(dbEvent)
                    : Ok(Contracts.V1.Event.Event.FromModel(dbEvent));
            
        }

        [HttpPut]
        [Route("{eventId}/Update")]
        [SwaggerOperation("UpdateEvent")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Event>), description: "OK")]
        [SwaggerResponse(statusCode: 400, type: typeof(DoctorlyValidationResult), description: "Bad Request")]
        [SwaggerResponse(statusCode: 500, type: typeof(DoctorlyError), description: "Error")]
        public IActionResult UpdateEvent([FromRoute, Required] int eventId, [FromBody] UpdateEventRequest eventToUpdate)
        {
            if (eventToUpdate == null)
                return BadRequest();

            //Validate?

            var dbEvent = _eventRepository.Update(eventId, eventToUpdate.ToModel());

            return (dbEvent == null)
                    ? BadRequest(dbEvent)
                    : Ok(Contracts.V1.Event.Event.FromModel(dbEvent));
        }
    }
}
