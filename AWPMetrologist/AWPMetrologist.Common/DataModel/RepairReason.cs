using System.Runtime.Serialization;

namespace AWPMetrologist.Common.DataModel
{
    [DataContract]
    public class RepairReason
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Reason { get; set; }
    }
}
