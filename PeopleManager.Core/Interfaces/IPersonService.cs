using PeopleManager.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleManager.Core.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDto>> GetAllAsync();
        Task<PersonDto> CreateAsync(PersonDto dto);
    }
}
