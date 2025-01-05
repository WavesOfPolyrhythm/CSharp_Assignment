using Business.Factories;
using Business.Models;
using Business.Services;
using System;
using System.Security.Cryptography.X509Certificates;

namespace MainApp.Dialogs;

public class MenuDialogs
{

    private readonly UserService _userService = new();

    //ShowMenu Handles the user's menu selection
    public void ShowMenu()
    {
       bool isRunning = true;

        // Loops until the user chooses to quit the program.
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
                    Console.WriteLine("Exiting...");
                    Console.ReadKey();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid option. Try again!");
                    Console.ReadKey();
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

            //Validates user input and check if it is not empty or whitespace
            if (string.IsNullOrWhiteSpace(user.FirstName))
            {
                Console.Write("\nFirst name cannot be empty. Please try again...");
                Console.ReadKey();
                continue;
            }

            Console.Write("Enter your last name: ");
            user.LastName = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(user.LastName))
            {
                Console.Write("\nLast name cannot be empty. Please try again...");
                Console.ReadKey();
                continue;
            }

            //If both inputs passes the loop ends
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
                Console.WriteLine($"Id: {user.Id}");
                Console.WriteLine($"First name: {user.FirstName}");
                Console.WriteLine($"Last name: {user.LastName}");
                Console.WriteLine("-----------------");
            }
        }

        Console.ReadKey();
    }
}
