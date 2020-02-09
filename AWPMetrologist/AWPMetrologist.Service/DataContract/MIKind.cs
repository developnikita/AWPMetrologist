using System.Runtime.Serialization;

namespace AWPMetrologistService.DataContract
{
    [DataContract]
    public class MIKind
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Kind { get; set; }
    }
}