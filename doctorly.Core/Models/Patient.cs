using System.ComponentModel.DataAnnotations;

namespace doctorly.Core.Models
{
    public class Patient : Contact
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
    }
}
