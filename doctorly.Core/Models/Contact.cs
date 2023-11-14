using System.ComponentModel.DataAnnotations;

namespace doctorly.Core.Models
{
    public class Contact
    {
        public int? Id { get; set; }

        [MaxLength(500)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
