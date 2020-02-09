using System.Runtime.Serialization;

namespace AWPMetrologistService.DataContract
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