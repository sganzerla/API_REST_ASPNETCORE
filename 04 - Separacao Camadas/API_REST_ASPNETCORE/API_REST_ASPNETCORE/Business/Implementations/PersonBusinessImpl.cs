using API_REST_ASPNETCORE.Model;
using API_REST_ASPNETCORE.Repository;
using System.Collections.Generic;

namespace API_REST_ASPNETCORE.Business.Implementations
{
    public class PersonBusinessImpl : IPersonBusiness

    {
        private IPersonRepository _repository;

        public PersonBusinessImpl(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            //validações regras de negocio ficam aqui
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
    }
}
