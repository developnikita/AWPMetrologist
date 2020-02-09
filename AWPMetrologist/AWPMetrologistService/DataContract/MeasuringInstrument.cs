using System.Runtime.Serialization;

namespace AWPMetrologistService.DataContract
{
    [DataContract]
    public class MeasuringInstrument
    {
        // NOTE: Нужные ли FK_ID подумать!!!
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string MSType { get; set; }

        [DataMember]
        public int DeviceId { get; set; }

        [DataMember]
        public string Device { get; set; }

        [DataMember]
        public int Cost { get; set; }

        [DataMember]
        public int Period { get; set; }

        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public string MSCategory { get; set; }

        [DataMember]
        public int KindId { get; set; }

        [DataMember]
        public string KindOfMS { get; set; }

        [DataMember]
        public int VerificationPlaceId { get; set; }

        [DataMember]
        public string VerificationPlace { get; set; }

        [DataMember]
        public int Gold { get; set; }

        [DataMember]
        public int Silver { get; set; }

        [DataMember]
        public int Platinum { get; set; }

        [DataMember]
        public int Paladium { get; set; }

        [DataMember]
        public int Mercury { get; set; }
    }
}