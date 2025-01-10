using Business.Entities;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Moq;
using System.Diagnostics;

namespace Business_Tests.Services;

/// <summary>
/// These tests ensure that user data is correctly saved to the repository
/// and that the repository's methods are called as expected.
/// </summary>
public class UserService_Tests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private UserService _userService;

    public UserService_Tests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _userService = new UserService(_userRepositoryMock.Object);
    }

    /// <summary>
    /// Verifies that the <see cref="UserService.CreateContact"/> method
    /// successfully saves a new user to the repository and calls
    /// the repository's save method exactly once.
    /// </summary>
    [Fact]
    public void CreateContact_ShouldSaveUserToRepository()
    {
        // Arrange
        var userEntity = new UserEntity
        {
            FirstName = "Test",
            LastName = "User",
            Email = "test.user@example.com",
            PhoneNumber = "1234567890",
            Address = "Test Street 123",
            City = "Test City"
        };

        _userRepositoryMock
        .Setup(x => x.SaveUsers(It.Is<List<UserEntity>>(list => list.Count == 1 && list[0].FirstName == "Test")))
        .Returns(true);


        // Act
        var result = _userService.CreateContact(userEntity);

        // Assert
        Assert.True(result);
        _userRepositoryMock.Verify(x => x.SaveUsers(It.IsAny<List<UserEntity>>()), Times.Once);
    }


    /// <summary>
    /// Checks that the ViewContacts method in UserService correctly retrieves a list of users 
    /// from the repository and matches the expected test user.
    /// </summary>
    [Fact]

    public void ViewContacts_ShouldReturnListOfUsers()
    {
        //arrange
        var expected = new List<UserEntity>
        {
            new UserEntity { Id = "1", FirstName = "Test", LastName = "User", Email = "test.user@example.com" }
        };

        _userRepositoryMock.Setup(x => x.LoadUsers()).Returns(expected);

        //act
        var result = _userService.ViewContacts();

        //assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(expected[0].Id, result.First().Id);
        Assert.Equal(expected[0].FirstName, result.First().FirstName);
        Assert.Equal(expected[0].LastName, result.First().LastName);
        Assert.Equal(expected[0].Email, result.First().Email);

        _userRepositoryMock.Verify(x => x.LoadUsers(), Times.Once);
    }

}
