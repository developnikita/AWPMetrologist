﻿using System.Runtime.Serialization;

namespace AWPMetrologist.Common.DataModel
{
    [DataContract]
    public class InstallationLocation
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Location { get; set; }
    }
}
