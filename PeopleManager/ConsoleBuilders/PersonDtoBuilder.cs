using PeopleManager.Core.Common;
using PeopleManager.Core.Dtos;

namespace PeopleManager.ConsoleApp.ConsoleBuilders
{
    public class PersonDtoBuilder : ConsoleModelBuilder<PersonDto>
    {
        public override PersonDto Build()
        {
            var dto = new PersonDto();
            dto.FirstName = ReadString("First Name:");
            dto.LastName = ReadString("Last Name:");
            dto.DateOfBirth = ReadDate("Date of birdth (dd-MM-yyyy):");
            dto.MaritalStatus = ReadMaritalStatus();

            var age = CalculateAge(dto.DateOfBirth);
            if (age < 16)
                throw new InvalidOperationException("Minimum age - 16");
            if (age < 18)
                dto.AllowRegistration = ReadBoolean("Does parrents allow you to register? (yes/no)");


            if(dto.MaritalStatus == MaritalStatus.Married)
            {
                var spouseBuilder = new SpouseDtoBuilder();
                dto.Spouse = spouseBuilder.Build();
            }

            return dto;
        }

        private MaritalStatus ReadMaritalStatus()
        {
            string input = string.Empty;
            int status = 0;

            Console.WriteLine("Marital Status");
            Console.WriteLine("1 - Single");
            Console.WriteLine("2 - Married");
            while(!int.TryParse(input, out status) || status < 1 || status > 2)
                input = Console.ReadLine();

            return (MaritalStatus)status;
        }

        private int CalculateAge(DateTime birthday)
        {
            var today = DateTime.Today;
            var age = today.Year - birthday.Year;
            if (birthday.Date > today.AddYears(-age))
                age--;

            return age;
        }
    }
}
