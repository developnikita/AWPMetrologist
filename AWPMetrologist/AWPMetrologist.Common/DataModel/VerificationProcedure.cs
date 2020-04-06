using System.Runtime.Serialization;

namespace AWPMetrologist.Common.DataModel
{
    [DataContract]
    public class VerificationProcedure
    {
        [DataMember]
        public int Id { get; }

        [DataMember]
        public string Procedure { get; set; }
    }
}
