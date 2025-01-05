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
        };


        //ACT

        //Calls the Create method in UserFactory with the registration form
        var result = UserFactory.Create(userRegistrationForm);

        // ASSERT

        // Verifies that the result is not null, that the user's properties match the input,
        // and that the ID string is not null or empty
        Assert.NotNull(result);
        Assert.Equal(userRegistrationForm.FirstName, result.FirstName);
        Assert.Equal(userRegistrationForm.LastName, result.LastName);
        Assert.False(string.IsNullOrEmpty(result.Id));
    }
}
