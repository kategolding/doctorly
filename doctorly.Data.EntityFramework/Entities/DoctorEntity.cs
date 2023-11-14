using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doctorly.Data.EntityFramework.Entities
{
    [Table("Doctor")]
    public partial class DoctorEntity : DbTrackableEntity
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Email { get; set; } = string.Empty;

        #region Mapping Methods

        public Core.Models.Doctor ToModel()
        {
            return new Core.Models.Doctor
            {
                Id = this.Id,
                Name = this.Name,
                Email = this.Email
            };
        }

        public static DoctorEntity FromModel(Core.Models.Doctor model)
        {
            return new DoctorEntity
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email
            };
        }

        #endregion Mapping Methods
    }
}
