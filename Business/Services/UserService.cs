using Business.Entities;
using Business.Models;
namespace Business.Services;

public class UserService
{
    private readonly List<UserEntity> _users = new List<UserEntity>();

    public void CreateContact(UserEntity user)
    {
        _users.Add(user);
    }

    public IEnumerable<UserEntity> ViewContacts()
    {
        return _users;
    }
}
