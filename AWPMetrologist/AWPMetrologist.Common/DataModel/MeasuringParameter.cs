using System.Runtime.Serialization;

namespace AWPMetrologist.Common.DataModel
{
    [DataContract]
    public class MeasuringParameter
    {
        [DataMember]
        public int Id { get; }

        [DataMember]
        public string Parameter { get; set; }
    }
}
