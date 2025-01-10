using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using System;
using System.Security.Cryptography.X509Certificates;

namespace MainApp.Dialogs;

public class MenuDialogs(IUserService userService)
{

    private readonly IUserService _userService = userService;
    public void ShowMenu()
    {
       bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("----Contact List----");
            Console.WriteLine("1. Add New Contact");
            Console.WriteLine("2. View All Contacts");
            Console.WriteLine("3. Quit Program");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateContact();
                    break;

                case "2":
                    ViewContacts();
                    break;

                case "3":
                    isRunning = false;
                    Console.Clear();
                    OutputDialog("Exiting...");
                    break;

                default:
                    Console.Clear();
                    OutputDialog("Invalid option. Try again!");
                    break;
            }
        }
    }

    public void CreateContact()
    {
        var user = new UserRegistrationForm();
        bool validInput = false;

        while (!validInput)
        {
            Console.Clear();
            Console.Write("Enter your first name: ");
            user.FirstName = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(user.FirstName))
                {
                    OutputDialog("\nFirst name cannot be empty. Please try again...");
                    continue;
                }

            Console.Write("Enter your last name: ");
            user.LastName = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(user.LastName))
                {
                    OutputDialog("\nLast name cannot be empty. Please try again...");
                    continue;
                }
  
            Console.Write("Enter your email: ");
            user.Email = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(user.Email) || !user.Email.Contains("@"))
                {
                    OutputDialog("\nInvalid email. Please try again...");
                    continue;
                }

            Console.Write("Enter your phone number: ");
            user.PhoneNumber = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(user.PhoneNumber) || !user.PhoneNumber.All(char.IsDigit))
                {
                    OutputDialog("\nInvalid phone number. Please try again...");
                    continue;
                }

            Console.Write("Enter your address: ");
            user.Address = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(user.Address))
                {
                    OutputDialog("\nAddress cannot be empty. Please try again...");
                    continue;
                }

            Console.Write("Enter your city: ");
            user.City = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(user.City))
                {
                    OutputDialog("\nCity cannot be empty. Please try again...");
                    continue;
                }

            validInput = true;

            //Creating a UserEntity with UserFactory
            var userEntity = UserFactory.Create(user);

            // Sends the created UserEntity to the UserService for further processing
            _userService.CreateContact(userEntity);

            Console.WriteLine("Contact was added!");
            Console.ReadKey();
        }
    
    }

    public void ViewContacts()
    {
        Console.Clear();

        // Retrieves a list of all stored user contacts from the UserService
        var users = _userService.ViewContacts();

        if (!users.Any())
        {
            Console.WriteLine("No users found!");
        }
        else
        {
            //Iterates through each UserEntity and writes it out to the user
            foreach (var user in users)
            {
                Console.WriteLine("-----------------");
                Console.WriteLine($"Id: {user.Id}");
                Console.WriteLine($"Name: {user.FirstName} {user.LastName}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Phone: {user.PhoneNumber}");
                Console.WriteLine($"Address: {user.Address} {user.City}");
            }
        }

        Console.ReadKey();
    }

    public void OutputDialog(string message)
    {
        Console.WriteLine(message);
        Console.ReadKey();
    }
}
