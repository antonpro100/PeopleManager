using System;

namespace PeopleManager.ConsoleApp.Models
{
    public class MenuItem
    {
        public string Key { get; set; }
        public string Text { get; set; }
        public Action Action { get; set; }
    }
}