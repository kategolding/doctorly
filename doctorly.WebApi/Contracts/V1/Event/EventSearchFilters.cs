using System.Runtime.Serialization;

namespace doctorly.WebApi.Contracts.V1.Event
{
    [DataContract]
    public partial class EventSearchFilters
    {
        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }


        internal static Core.Filters.EventFilters ToModel(EventSearchFilters requestFilters)
        {
            return new Core.Filters.EventFilters
            {
                Text = requestFilters.Text,
                StartDate = requestFilters.StartDate,
                EndDate = requestFilters.EndDate
            };
        }
    }
}
