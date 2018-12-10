using System.Collections.Generic;
using System.Runtime.Serialization;
using Tapioca.HATEOAS;

namespace RestWithASPNETUdemy.VO
{
    [DataContract]
    public class PersonVO : ISupportsHyperMedia
    {
        //[DataMember(Order = 5, Name = "Código")]
        public long? Id { get; set; }
        //[DataMember(Name = "Primeiro Nome")]
        public string FirstName { get; set; }
        //[DataMember(Name = "Último Nome")]
        public string LastName { get; set; }
        //[DataMember(Name = "Endereço")]
        public string Address { get; set; }
        //[DataMember(Name = "Gênero")]
        public string Gender { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
