using System.Runtime.Serialization;

namespace AWPMetrologist.Common.DataModel
{
    [DataContract]
    public class MSKind
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Kind { get; set; }
    }
}
