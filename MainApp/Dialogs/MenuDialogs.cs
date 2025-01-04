using Business.Factories;
using Business.Models;
using Business.Services;
using System;
using System.Security.Cryptography.X509Certificates;

namespace MainApp.Dialogs;

public class MenuDialogs
{

    private readonly UserService _userService = new();
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
        Console.Clear();
        var user = new UserRegistrationForm();

        Console.Write("Enter your first name: ");
        user.FirstName = Console.ReadLine()!;

        Console.Write("Enter your last name: ");
        user.LastName = Console.ReadLine()!;

        //Creating a UserEntity with UserFactory
        var userEntity = UserFactory.Create(user);

        // Sends the created UserEntity to the UserService for further processing
        _userService.CreateContact(userEntity);

        Console.WriteLine("Contact was added!");
        Console.ReadKey();
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
            //Looping through each user object
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
