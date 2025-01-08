using Business.Entities;
using Business.Interfaces;
using Business.Models;
using System.Diagnostics;
namespace Business.Services;

public class UserService(IFileService fileService) : IUserService
{
    // Dependency for saving and loading user data to/from a file
    private readonly IFileService _fileService = fileService;

    // In-memory list to temporarily store UserEntity objects
    private List<UserEntity> _users = new();


    // Adds the new UserEntity to the in-memory list and saves the updated list to the file.
    public bool CreateContact(UserEntity user)
    {
        try
        {
            //Add user to the list
            _users.Add(user);

            //Save the updated list to file
            _fileService.SaveListToFile(_users);
            return true;
        }
        catch (Exception ex)
        {
            //Handls exception
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public IEnumerable<UserEntity> ViewContacts()
    {
        try
        {
            //Load list from file
            _users = _fileService.LoadListFromFile();
        }
        catch (Exception ex)
        {
            //Handls exception
            Debug.WriteLine(ex.Message);

            //Returns a empty list
            _users = [];
        }

        //Returns the list of users
        return _users;
    }
}
