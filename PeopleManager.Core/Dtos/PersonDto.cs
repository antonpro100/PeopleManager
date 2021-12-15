using PeopleManager.Core.Common;
using System;

namespace PeopleManager.Core.Dtos
{
    public class PersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public SpouseDto Spouse { get; set; }
        public bool AllowRegistration { get; set; }
    }
}
