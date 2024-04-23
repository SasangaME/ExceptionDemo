using ExceptionDemo.Models;

namespace ExceptionDemo.Repositories
{
    public interface IPersonRepository
    {
        IEnumerable<Person> FindAll();
        Person? FindById(int id);
        void Insert(Person person);
        void Update(Person existingPerson, Person data);
    }

    public class PersonRepository : IPersonRepository
    {
        private readonly List<Person> _people;

        public PersonRepository()
        {
            _people = Initialize();
        }

        public IEnumerable<Person> FindAll()
        {
            return _people;
        }

        public Person? FindById(int id)
        {
            return _people.FirstOrDefault(p => p.Id == id);
        }

        public void Insert(Person person)
        {
            _people.Add(person);
        }

        public void Update(Person existingPerson, Person data)
        {
            existingPerson.FirstName = data.FirstName;
            existingPerson.LastName = data.LastName;
        }

        private static List<Person> Initialize()
        {
            return new List<Person>()
            {
                new Person { Id = 1, FirstName = "Tony", LastName = "Stark" },
                new Person { Id = 2, FirstName = "Pepper", LastName = "Potts" },
                new Person { Id = 3, FirstName = "Bruce", LastName = "Banner" },
                new Person { Id = 4, FirstName = "Mary", LastName = "Watson" },
            };
        }
    }
}
