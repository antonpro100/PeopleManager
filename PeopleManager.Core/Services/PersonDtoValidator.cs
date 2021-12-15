using PeopleManager.Core.Common;
using PeopleManager.Core.Dtos;
using PeopleManager.Core.Interfaces;

namespace PeopleManager.Core.Services
{
    public class PersonDtoValidator : IPersonValidator
    {
        public ValidationResult IsValid(PersonDto dto)
        {
            var result = new ValidationResult();
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var age = CalculateAge(dto.DateOfBirth);
            if (age < 16)
            {
                result.AddError("Min age - 16 years");
                return result;
            }
            if (age < 18 && !dto.AllowRegistration)
                result.AddError("Parents permission required");
            if (dto.MaritalStatus == MaritalStatus.Married && dto.Spouse == null)
                result.AddError("Add spouse data");

            return result;
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
