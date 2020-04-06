using System.Runtime.Serialization;

namespace AWPMetrologist.Common.DataModel
{
    [DataContract]
    public class FactoryManufacturer
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Factory { get; set; }
    }
}
