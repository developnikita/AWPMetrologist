using System.Runtime.Serialization;

namespace AWPMetrologist.Common.DataModel
{
    [DataContract]
    public class MICategory
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Category { get; set; }
    }
}