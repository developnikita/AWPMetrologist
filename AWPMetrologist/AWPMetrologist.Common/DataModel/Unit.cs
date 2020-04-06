using System.Runtime.Serialization;

namespace AWPMetrologist.Common.DataModel
{
    [DataContract]
    public class Unit
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string UnitValue { get; set; }
    }
}
