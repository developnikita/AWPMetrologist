using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AWPMetrologist.Common.DataModel
{
    [DataContract]
    public class MSType
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Type { get; set; }
    }
}
