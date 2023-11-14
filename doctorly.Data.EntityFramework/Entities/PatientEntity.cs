using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doctorly.Data.EntityFramework.Entities
{
    [Table("Patient")]
    public partial class PatientEntity : DbTrackableEntity
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Email { get; set; } = string.Empty;

        #region Mapping Methods

        public Core.Models.Patient ToModel()
        {
            return new Core.Models.Patient
            {
                Id = this.Id,
                Name = this.Name,
                Email = this.Email
            };
        }

        public static PatientEntity FromModel(Core.Models.Patient model)
        {
            return new PatientEntity
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email
            };
        }

        #endregion Mapping Methods
    }
}
