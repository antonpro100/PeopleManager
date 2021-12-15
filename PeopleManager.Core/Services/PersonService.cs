using PeopleManager.Core.Dtos;
using PeopleManager.Core.Entities;
using PeopleManager.Core.Interfaces;

namespace PeopleManager.Core.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository repository) => _personRepository = repository;

        public async Task<PersonDto> CreateAsync(PersonDto dto)
        {
            var person = new Person
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                MaritalStatus = dto.MaritalStatus
            };
            if(dto.Spouse != null)
            {
                person.Spouse = new Spouse
                {
                    Id = Guid.NewGuid(),
                    FirstName = dto.Spouse.FirstName,
                    LastName = dto.Spouse.LastName,
                    DateOfBirth = dto.Spouse.DateOfBirth
                };
            }

            await _personRepository.CreateAsync(person);

            return dto;
        }

        public async Task<IEnumerable<PersonDto>> GetAllAsync()
        {
            return (await _personRepository.GetAllAsync())
                .Select(x => new PersonDto 
                { 
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateOfBirth = x.DateOfBirth, 
                    MaritalStatus = x.MaritalStatus 
                })
                .ToList();
        }
    }
}
