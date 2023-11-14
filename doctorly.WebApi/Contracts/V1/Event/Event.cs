using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace doctorly.WebApi.Contracts.V1.Event
{
    [DataContract]
    public partial class Event
    {
        [Required]
        [DataMember(Name = "id")]
        public int? Id { get; set; }

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

        internal static Event FromModel(Core.Models.Event eventModel)
        {
            return new Event
            {
                Id = eventModel.Id,
                Description = eventModel.Description,
                Title = eventModel.Title,
                StartDate = eventModel.StartTime,
                EndDate = eventModel.EndTime
            };
        }
    }
}
