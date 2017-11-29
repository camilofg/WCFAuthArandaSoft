using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommonEntities
{
    [DataContract]
    public class RequestData
    {
        [DataMember]
        public string Description { get; set; }
    }
}
