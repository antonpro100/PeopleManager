using PeopleManager.Core.Dtos;

namespace PeopleManager.Core.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDto>> GetAllAsync();
        Task<PersonDto> CreateAsync(PersonDto dto);
    }
}
