using Business.Helpers;
using System.Dynamic;

namespace Business.Models;

public class UserRegistrationForm
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Id { get; set; } = IdentifierGenerator.GenerateUniqueId();
}
