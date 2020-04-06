using System;
using System.Runtime.Serialization;

namespace AWPMetrologist.Common.DataModel
{
    [DataContract]
    public class MeasuringSystem
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public MSCategory MSCategory { get; set; }

        [DataMember]
        public Measuring Measuring { get; set; }

        [DataMember]
        public FactoryManufacturer FactoryManufacturer { get; set; }

        [DataMember]
        public string SerialNumber { get; set; }

        [DataMember]
        public DateTime ProductionDate { get; set; }

        [DataMember]
        public int LifeTime { get; set; }

        [DataMember]
        public float Cost { get; set; }

        [DataMember]
        public Exploitation Exploitation { get; set; }
    }
}
