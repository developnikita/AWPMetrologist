using System.Runtime.Serialization;

namespace AWPMetrologist.Common.DataModel
{
    [DataContract]
    public class VerificationMethod
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Method { get; set; }
    }
}
