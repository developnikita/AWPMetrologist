using System.Runtime.Serialization;

namespace AWPMetrologist.Common.DataModel
{
    [DataContract]
    public class Storage
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string StorageValue { get; set; }
    }
}
