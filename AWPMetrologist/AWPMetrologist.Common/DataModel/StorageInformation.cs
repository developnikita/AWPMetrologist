using System;
using System.Runtime.Serialization;

namespace AWPMetrologist.Common.DataModel
{
    [DataContract]
    public class StorageInformation
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Storage Storage { get; set; }

        [DataMember]
        public DateTime StorageDate { get; set; }
    }
}
