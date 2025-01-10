using Business.Entities;
using Business.Interfaces;
using Business.Models;
using Business.Repositories;
using System.Diagnostics;
namespace Business.Services;

public class UserService : IUserService

/// <summary>
/// This class handles the main logic for managing users, 
/// creating and viewing user contacts.
/// It interacts with the <see cref="IUserRepository"/> to save and load user data.
/// </summary>
{
    private readonly IUserRepository _userRepository;
    private List<UserEntity> _users;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserService"/> class.
    /// Loads the current list of users from the repository.
    /// </summary>
    /// <param name="userRepository">The repository used to save and load user data.</param>
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _users = new List<UserEntity>();
    }

    /// <summary>
    /// Adds new user to the user list and saves the updated list to the repository.
    /// </summary>
    /// <param name="user">User that will be added.</param>
    /// <returns>
    /// If the user was successfully added and saved, returns true; otherwise false if an error occurs.
    /// </returns>

    public bool CreateContact(UserEntity user)
    {
        try
        {
            _users.Add(user);
            _userRepository.SaveUsers(_users);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Retrieves the list of all users from the repository.
    /// </summary>
    /// <returns>
    /// A list of users if data is available; otherwise, an empty list.
    /// </returns>
    public IEnumerable<UserEntity> ViewContacts()
    {
        try
        {
            _users = _userRepository.LoadUsers();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            _users = [];
        }

        return _users;
    }
}
