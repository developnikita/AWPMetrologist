using System.Runtime.Serialization;

namespace AWPMetrologist.Common.DataModel
{
    [DataContract]
    public class Measuring
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Unit Unit { get; set; }

        [DataMember]
        public float Accuracy { get; set; }

        [DataMember]
        public int LowerLimit { get; set; }

        [DataMember]
        public int UpperLimit { get; set; }

        [DataMember]
        public float Error { get; set; }

        [DataMember]
        public MSKind MSKind { get; set; }

        [DataMember]
        public MeasuredParameter MeasuredParameter { get; set; }
    }
}
