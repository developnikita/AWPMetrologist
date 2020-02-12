using System.Runtime.Serialization;

namespace AWPMetrologist.Common.DataModel
{
    [DataContract]
    public class MIDevice
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Device { get; set; }
    }
}