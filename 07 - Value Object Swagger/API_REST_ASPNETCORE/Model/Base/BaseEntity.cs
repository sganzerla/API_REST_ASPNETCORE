using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RestWithASPNETUdemy.Model.Base
{
    //Contrato entre atributos e a estrutura da tabela
    
    public class BaseEntity
    {      
        public long? Id { get; set; }

    }
}
