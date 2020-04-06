using System.Runtime.Serialization;

namespace AWPMetrologist.Common.DataModel
{
    [DataContract]
    public class MSCategory
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Category { get; set; }
    }
}
