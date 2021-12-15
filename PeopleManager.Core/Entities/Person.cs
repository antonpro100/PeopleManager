using PeopleManager.Core.Common;

namespace PeopleManager.Core.Entities
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public Spouse Spouse { get; set; }

        public int Age { 
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;
                if (DateOfBirth.Date > today.AddYears(-age)) 
                    age--;

                return age;
            } 
        }
    }
}