using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommonEntities
{
    [DataContract]
    public class RequestAccessXRole
    {
        [DataMember]
        public string Access { get; set; }

        [DataMember]
        public string Rol { get; set; }
    }
}
