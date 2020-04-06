using System;
using System.Runtime.Serialization;

namespace AWPMetrologist.Common.DataModel
{
    [DataContract]
    public class Verification
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public VerificationMethod VerificationMethod { get; set; }

        [DataMember]
        public VerificationPlace VerificationPlace { get; set; }

        [DataMember]
        public DateTime LastDate { get; set; }

        [DataMember]
        public int Period { get; set; }

        [DataMember]
        public DateTime NextDate { get; set; }

        [DataMember]
        public string CertificateNumber { get; set; }

        [DataMember]
        public bool VerificationResult { get; set; }

        [DataMember]
        public bool Replaced { get; set; }
    }
}
