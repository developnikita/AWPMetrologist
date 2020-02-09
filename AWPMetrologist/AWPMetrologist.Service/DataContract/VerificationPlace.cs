using System.Runtime.Serialization;

namespace AWPMetrologistService.DataContract
{
    [DataContract]
    public class VerificationPlace
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Place { get; set; }
    }
}