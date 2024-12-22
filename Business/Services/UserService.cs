using Business.Models;
namespace Business.Services;

public class UserService
{
    private readonly List<UserRegistrationForm> _user = [];

    public void CreateContact(UserRegistrationForm user)
    {
        _user.Add(user);
    }

    public IEnumerable<UserRegistrationForm> ViewContacts()
    {
        return _user;
    }
}
