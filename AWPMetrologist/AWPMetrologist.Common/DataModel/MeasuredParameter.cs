﻿using System.Runtime.Serialization;

namespace AWPMetrologist.Common.DataModel
{
    [DataContract]
    public class MeasuredParameter
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Parameter { get; set; }
    }
}
