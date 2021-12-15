using PeopleManager.Core.Common;

namespace PeopleManager.Core.Entities
{
    public class Spouse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}