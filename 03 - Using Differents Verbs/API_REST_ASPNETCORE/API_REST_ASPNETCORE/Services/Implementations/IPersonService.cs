using API_REST_ASPNETCORE.Model;
using System.Collections.Generic;

namespace API_REST_ASPNETCORE.Services.Implementations
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindByID(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
