using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeopleManager.ConsoleApp.ConsoleBuilders;
using PeopleManager.ConsoleApp.Models;
using PeopleManager.Core.Interfaces;
using PeopleManager.Core.Services;
using PeopleManager.Infrastructure.FileStarage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleManager.ConsoleApp
{
    class Program
    {
        private static ServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();

            _serviceProvider = new ServiceCollection()
                .AddSingleton<IPersonService, PersonService>()
                .AddSingleton<IPersonValidator, PersonDtoValidator>()
                .AddSingleton<IPersonRepository>(p => new PersonRepository(config.GetSection("dataDirectory").Value))
                .BuildServiceProvider();

            MainMenu();
        }

        static void MainMenu()
        {
            var menuOptions = new List<MenuItem>
            {
                new MenuItem{ Key = "1", Text = "Display a list of people", Action = GetAllView },
                new MenuItem{ Key = "2", Text = "Add a new person", Action = CreatePersonView },
            };

            Console.Clear();
            Console.WriteLine("Enter:");
            foreach (var option in menuOptions)
            {
                Console.WriteLine($"{option.Key} - {option.Text}");
            }       
            var selectedKey = Console.ReadLine();
            var selected = menuOptions.FirstOrDefault(x => x.Key == selectedKey);

            if(selected == null)
                MainMenu();
            else
                selected.Action();
        }

        public static void CreatePersonView()
        {
            Console.Clear();
            var service = _serviceProvider.GetService<IPersonService>();
            var validator = _serviceProvider.GetService<IPersonValidator>();

            var builder = new PersonDtoBuilder();
            var personDto = builder.Build();
            try
            {
                var vr = validator.IsValid(personDto);
                if (vr.IsValid)
                {
                    service.CreateAsync(personDto);

                    Console.WriteLine("Complelte!");
                }
                else
                {
                    vr.Errors.ForEach(x => Console.WriteLine(x));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key...");
                Console.ReadKey();
                MainMenu();
            }
        }

        public static void GetAllView()
        {
            Console.Clear();
            var service = _serviceProvider.GetService<IPersonService>();

            var data = service.GetAllAsync().Result;
            foreach (var item in data)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} {item.DateOfBirth.ToShortDateString()} {item.MaritalStatus.ToString()}");
            }

            Console.WriteLine("Press any key...");
            Console.ReadKey();
            MainMenu();
        }
    }
}