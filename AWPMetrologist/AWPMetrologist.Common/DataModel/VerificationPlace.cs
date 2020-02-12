using System.Runtime.Serialization;

namespace AWPMetrologist.Common.DataModel
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