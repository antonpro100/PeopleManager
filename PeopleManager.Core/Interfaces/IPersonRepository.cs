using PeopleManager.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleManager.Core.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Task<Person> CreateAsync(Person person);
    }
}
