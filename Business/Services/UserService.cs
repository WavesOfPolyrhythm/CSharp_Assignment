using Business.Entities;
using Business.Models;
using System.Diagnostics;
namespace Business.Services;

public class UserService
{
    private List<UserEntity> _users = new();
    private readonly FileService _fileService = new FileService();


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

            _users = [];
        }
        return _users;
    }
}
