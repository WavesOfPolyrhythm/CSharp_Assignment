using Business.Factories;
using Business.Models;

namespace Business_Tests.Factories;

public class UserFactory_Tests
{
    [Fact]
    public void Create_ShouldReturnUserEntity()
    {

        //ARRANGE

        //Creates a simulated user registration form as input for the test
        var userRegistrationForm = new UserRegistrationForm
        {
            FirstName = "Test",
            LastName = "User",
            Email = "test.user@example.com",
            PhoneNumber = "1234567890",
            Address = "Test Street 123",
            City = "Test City"
        };


        //ACT

        //Calls the Create method in UserFactory with the registration form
        var result = UserFactory.Create(userRegistrationForm);

        // ASSERT

        // Verifies that the result is not null, that the user's properties match the input,
        Assert.NotNull(result);
        Assert.Equal(userRegistrationForm.FirstName, result.FirstName);
        Assert.Equal(userRegistrationForm.LastName, result.LastName);
        Assert.Equal(userRegistrationForm.Email, result.Email);
        Assert.Equal(userRegistrationForm.PhoneNumber, result.PhoneNumber);
        Assert.Equal(userRegistrationForm.Address, result.Address);
        Assert.Equal(userRegistrationForm.City, result.City);
        Assert.False(string.IsNullOrEmpty(result.Id));
    }
}
