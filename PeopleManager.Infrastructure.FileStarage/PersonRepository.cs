using PeopleManager.Core.Common;
using PeopleManager.Core.Entities;
using PeopleManager.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManager.Infrastructure.FileStarage
{
    public class PersonRepository : IPersonRepository
    {
        private readonly string _directory;
        private readonly string _mainFilePath;

        public PersonRepository(string directoryPath)
        {
            _directory = directoryPath;
            if(!Directory.Exists(_directory))
                Directory.CreateDirectory(_directory);

            _mainFilePath = Path.Combine(_directory, "main.txt");
            if(!File.Exists(_mainFilePath))
                File.Create(_mainFilePath);
        }

        public async Task<Person> CreateAsync(Person person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            var personLine = Stringify(person);
            await File.AppendAllTextAsync(_mainFilePath, personLine + Environment.NewLine);

            if (person.Spouse != null)
            {
                var spouseLine = Stringify(person.Spouse);
                var spouseFilePath = Path.Combine(_directory, person.Spouse.Id.ToString() + ".txt");
                File.Create(spouseFilePath);
                await File.AppendAllTextAsync(spouseFilePath, spouseLine + Environment.NewLine);
            }

            return person;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return (await File.ReadAllLinesAsync(_mainFilePath))
                .Select(Parse)
                .ToList();
        }

        private Person Parse(string personString)
        {
            var parameters = personString.Split('|');

            return new Person
            {
                FirstName = parameters[1],
                LastName = parameters[2],
                DateOfBirth = DateTime.Parse(parameters[3]),
                MaritalStatus = (MaritalStatus)Enum.Parse(typeof(MaritalStatus), parameters[4])
            };
        }

        private string Stringify(Person person)
        {
            var builder = new StringBuilder();
            builder.Append(person.Id);
            builder.Append('|');
            builder.Append(person.FirstName?.Replace("|", string.Empty));
            builder.Append('|');
            builder.Append(person.LastName?.Replace("|", string.Empty));
            builder.Append('|');
            builder.Append(person.DateOfBirth.ToString("dd-MM-yyyy"));
            builder.Append('|');
            builder.Append(person.MaritalStatus.ToString());
            builder.Append('|');

            if (person.Spouse != null)
                builder.Append(person.Spouse.Id + ".txt");

            return builder.ToString();
        }

        private string Stringify(Spouse person)
        {
            var builder = new StringBuilder();
            builder.Append(person.Id);
            builder.Append('|');
            builder.Append(person.FirstName?.Replace("|", string.Empty));
            builder.Append('|');
            builder.Append(person.LastName?.Replace("|", string.Empty));
            builder.Append('|');
            builder.Append(person.DateOfBirth.ToString("dd-MM-yyyy"));
            builder.Append('|');

            return builder.ToString();
        }
    }
}