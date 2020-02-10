using System.Runtime.Serialization;

namespace AWPMetrologistService.DataContract
{
    [DataContract]
    public class MeasuringInstrument
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string MSType { get; set; }

        [DataMember]
        public MIDevice Device { get; set; }

        [DataMember]
        public int? Cost { get; set; }

        [DataMember]
        public int Period { get; set; }

        [DataMember]
        public MICategory Category { get; set; }

        [DataMember]
        public MIKind Kind { get; set; }

        [DataMember]
        public VerificationPlace Place { get; set; }

        [DataMember]
        public int? Gold { get; set; }

        [DataMember]
        public int? Silver { get; set; }

        [DataMember]
        public int? Platinum { get; set; }

        [DataMember]
        public int? Paladium { get; set; }

        [DataMember]
        public int? Mercury { get; set; }
    }
}