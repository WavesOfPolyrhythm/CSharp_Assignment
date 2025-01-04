using Business.Entities;
using Business.Models;
namespace Business.Services;

public class UserService
{
    private List<UserEntity> _users = new();
    private readonly FileService _fileService = new FileService();

    public void CreateContact(UserEntity user)
    {
        _users.Add(user);
        _fileService.SaveListToFile(_users);
    }

    public IEnumerable<UserEntity> ViewContacts()
    {
        _users = _fileService.LoadListFromFile();
        return _users;
    }
}
