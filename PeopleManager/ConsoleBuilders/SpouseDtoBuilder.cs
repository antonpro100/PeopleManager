using PeopleManager.Core.Dtos;
using System;

namespace PeopleManager.ConsoleApp.ConsoleBuilders
{
    public class SpouseDtoBuilder : ConsoleModelBuilder<SpouseDto>
    {
        public override SpouseDto Build()
        {
            Console.WriteLine("Spouse data");
            var dto = new SpouseDto();
            dto.FirstName = ReadString("First Name:");
            dto.LastName = ReadString("Last Name:");
            dto.DateOfBirth = ReadDate("Date of birdth (dd-MM-yyyy):");

            return dto;
        }
    }
}
