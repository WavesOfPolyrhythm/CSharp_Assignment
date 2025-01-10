using Business.Entities;
using Business.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

namespace Business.Repositories;

/// <summary>
/// This class manages saving and loading users to and from a file.
/// It also converts the user list to and from JSON format.
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly IFileService _fileService;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    /// <summary>
    /// Creates a new UserRepository and sets up file handling and JSON settings.
    /// </summary>
    /// <param name="fileService">Used for reading and writing files.</param>
    public UserRepository(IFileService fileService)
    {
        _fileService = fileService;
        _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
    }

    /// <summary>
    /// Saves a list of users to a file in JSON format.
    /// </summary>
    /// <param name="users">The list of users to save.</param>
    /// <returns>
    /// True if the save operation is successful; otherwise, false if an error occurs.
    /// </returns>

    public bool SaveUsers(List<UserEntity> users)
    {
        try
        {
            var json = JsonSerializer.Serialize(users, _jsonSerializerOptions);
            _fileService.SaveListToFile(json);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Loads a list of users from a file that is stored in JSON format.
    /// </summary>
    /// <returns>The list of users, or an empty list if something went wrong.</returns>
    public List<UserEntity> LoadUsers()
    {
        try
        {
            var json = _fileService.LoadListFromFile();
            return JsonSerializer.Deserialize<List<UserEntity>>(json, _jsonSerializerOptions) ?? [];
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error in LoadUsers: {ex.Message}");
            return[];
        }
    }
}
