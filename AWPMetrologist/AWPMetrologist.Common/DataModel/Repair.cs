using System;
using System.Runtime.Serialization;

namespace AWPMetrologist.Common.DataModel
{
    [DataContract]
    public class Repair
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public RepairReason RepairReason { get; set; }

        [DataMember]
        public RepairOrganization RepairOrganization { get; set; }

        [DataMember]
        public DateTime RepairDate { get; set; }
    }
}
