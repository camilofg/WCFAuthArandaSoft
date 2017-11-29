using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommonEntities
{
    [DataContract]
    public class RequestUser
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string PasswordHash { get; set; }

        [DataMember]
        public string SecuritySalt { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Telephone { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public int TypeRoleID { get; set; }
    }
}
