using System.Runtime.Serialization;

namespace AWPMetrologistService.DataContract
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