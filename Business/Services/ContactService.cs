using Business.Models;
namespace Business.Services;

public class ContactService
{
    private readonly List<UserRegistrationForm> _user = [];

    public void AddContact(UserRegistrationForm user)
    {
        _user.Add(user);
    }

    public IEnumerable<UserRegistrationForm> ViewContacts()
    {
        return _user;
    }
}
