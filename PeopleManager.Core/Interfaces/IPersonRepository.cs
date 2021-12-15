using PeopleManager.Core.Dtos;
using PeopleManager.Core.Entities;

namespace PeopleManager.Core.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Task<Person> CreateAsync(Person person);
    }
}
