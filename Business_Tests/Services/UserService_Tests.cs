using Business.Entities;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Moq;
using System.Diagnostics;

namespace Business_Tests.Services;

public class UserService_Tests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private UserService _userService;

    public UserService_Tests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _userService = new UserService(_userRepositoryMock.Object);
    }

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
        Assert.True(result); // Check if the method returned true
        _userRepositoryMock.Verify(x => x.SaveUsers(It.IsAny<List<UserEntity>>()), Times.Once);
    }


}
