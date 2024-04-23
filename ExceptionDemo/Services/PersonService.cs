using ExceptionDemo.Exceptions;
using ExceptionDemo.Models;
using ExceptionDemo.Repositories;

namespace ExceptionDemo.Services
{
    public interface IPersonService
    {
        IEnumerable<Person> FindAll();
        Person FindById(int id);
        void Insert(Person person);
        void Update(int id, Person person);
    }

    public class PersonService(IPersonRepository personRepository) : IPersonService
    {
        public void Insert(Person person)
        {
            person.Id = personRepository.FindAll().Count() + 1;    
            personRepository.Insert(person);
        }

        public IEnumerable<Person> FindAll()
        {
            return personRepository.FindAll();
        }

        public Person FindById(int id)
        {
            return personRepository.FindById(id) ?? throw new NotFoundException($"person not found for id: {id}");
        }

        public void Update(int id, Person person)
        {
            var existingPerson = FindById(id);
            personRepository.Update(existingPerson, person);
        }
    }
}
