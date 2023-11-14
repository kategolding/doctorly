using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace doctorly.WebApi.Contracts.V1.Event
{
    public class UpdateEventRequest
    {
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
                StartTime = this.StartDate,
                EndTime = this.EndDate
            };
        }
    }
}
