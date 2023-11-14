using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace doctorly.WebApi.Contracts
{
    [DataContract]
    public partial class DoctorlyValidationResult
    {
        [Required]
        [DataMember(Name = "Valid")]
        public bool IsValid { get; set; }

        [Required]
        [DataMember(Name = "Message")]
        public string Message { get; set; }


        [DataMember(Name = "Details")]
        public List<string> Details { get; set; }
    }
}
