using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RestWithASPNETUdemy.Model.Base
{
    //Contrato entre atributos e a estrutura da tabela
    [DataContract]
    public class BaseEntity
    {
        [Key]
        public long? Id { get; }

    }
}
