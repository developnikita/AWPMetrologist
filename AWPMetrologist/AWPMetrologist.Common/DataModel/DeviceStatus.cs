using System;
using System.Runtime.Serialization;

namespace AWPMetrologist.Common.DataModel
{
    [DataContract]
    public class DeviceStatus
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public MeasuringSystem MS { get; set; }

        [DataMember]
        public TechnicalCondition Condition { get; set; }

        [DataMember]
        public DateTime FromTime { get; set; }

        [DataMember]
        public DateTime ToTime { get; set; }
    }
}
