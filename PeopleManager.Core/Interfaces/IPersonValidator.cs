using PeopleManager.Core.Common;
using PeopleManager.Core.Dtos;

namespace PeopleManager.Core.Interfaces
{
    public interface IPersonValidator
    {
        ValidationResult IsValid(PersonDto dto);
    }
}
