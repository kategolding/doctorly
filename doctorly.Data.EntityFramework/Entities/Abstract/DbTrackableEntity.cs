using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doctorly.Data.EntityFramework.Entities
{
    public abstract class DbTrackableEntity : DbEntity
    {
        [MaxLength(50)]
        public virtual string? CreatedBy { get; internal set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual DateTime CreatedOnUtc { get; internal set; }

        [MaxLength(50)]
        public virtual string? UpdatedBy { get; internal set; }

        public virtual DateTime? UpdatedOnUtc { get; internal set; }
    }
}
