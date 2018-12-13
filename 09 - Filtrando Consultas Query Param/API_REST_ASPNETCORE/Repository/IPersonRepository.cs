using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        List<Person> FindByName(string firstName, string lastName);
    }
   
}
