using API_REST_ASPNETCORE.db.Context;
using API_REST_ASPNETCORE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace API_REST_ASPNETCORE.Services.Implementations
{
    public class PersonServiceImpl : IPersonService

    {
        private MySQLContext _context;
        public PersonServiceImpl(MySQLContext context)
        {
            _context = context; 
        }
        private volatile int count;

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            try
            {
                if (result != null) _context.Persons.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }            

        public Person FindByID(long id)
        {
            return _context.Persons.SingleOrDefault(p=> p.Id.Equals(id));
        }             

        public Person Update(Person person)
        {
            if (!Exist(person.Id)) return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        private bool Exist(long? id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
