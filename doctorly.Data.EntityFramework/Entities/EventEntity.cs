using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doctorly.Data.EntityFramework.Entities
{
    [Table("Event")]
    public partial class EventEntity : DbTrackableEntity
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        #region Mapping Methods

        public Core.Models.Event ToModel()
        {
            return new Core.Models.Event
            {
                Id = this.Id,
                Title = this.Title,
                Description = this.Description,
                StartTime = this.StartTime,
                EndTime = this.EndTime
            };
        }

        public static EventEntity FromModel(Core.Models.Event model)
        {
            return new EventEntity
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                StartTime = model.StartTime,
                EndTime = model.EndTime
            };
        }

        #endregion Mapping Methods
    }
}
