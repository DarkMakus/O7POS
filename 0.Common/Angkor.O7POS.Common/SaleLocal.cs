using System.Runtime.Serialization;

namespace Angkor.O7POS.Common.Entities
{
    [DataContract]
    public class SaleLocal
    {        
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Address { get; set; }
    }
}