using RestWithASPNETUdemy.Data.VO;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;

namespace RestWithASPNETUdemy.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindByName(string firstName, string lastName);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
        PagedSearchDTO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
    }
}
