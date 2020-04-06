using System.Runtime.Serialization;

namespace AWPMetrologist.Common.DataModel
{
    [DataContract]
    public class TechnicalCondition
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Condition { get; set; }
    }
}
