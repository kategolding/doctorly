using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace doctorly.Data.EntityFramework.Entities
{
    public abstract class DbEntity
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int? Id { get; set; }

        [NotMapped]
        public bool IsNew
        {
            get
            {
                return Id == null;
            }

        }
    }
}
