using System.Runtime.Serialization;

namespace doctorly.WebApi.Contracts.V1
{
    [DataContract]
    public partial class DoctorlyError
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string Detail { get; set; }
        
        [DataMember]
        public string Code { get; set; }
        
        [DataMember]
        public decimal? Status { get; set; }
    }
}
