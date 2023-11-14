using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace doctorly.WebApi.Contracts.V1.Event
{
    [DataContract]
    public class CreateEventRequest
    {
        [Required]
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [Required]
        [DataMember(Name = "description")]
        public string Description { get; set; }

        [Required]
        [DataMember(Name = "startDate")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataMember(Name = "endDate")]
        public DateTime EndDate { get; set; }

        internal Core.Models.Event ToModel()
        {
            return new Core.Models.Event
            {
                Description = this.Description,
                Title = this.Title,
                StartTime = this.StartDate,
                EndTime = this.EndDate
            };
        }
    }
}
