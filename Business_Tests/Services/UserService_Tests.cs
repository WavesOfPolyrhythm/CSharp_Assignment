using Business.Entities;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Moq;

namespace Business_Tests.Services;

public class UserService_Tests
{
    private readonly Mock<IFileService> _fileServiceMock;
    private IUserService _userService;

    public UserService_Tests()
    {
        _fileServiceMock = new Mock<IFileService>();
        _userService = new UserService(_fileServiceMock.Object);
    }

    [Fact]
    public void CreateContact_ShouldAddUserToListAndSaveToFile()
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

        _fileServiceMock.Setup(x => x.SaveListToFile(It.IsAny<List<UserEntity>>())).Returns(true);

        // Act
        var result = _userService.CreateContact(userEntity);

        //Assert
        Assert.True(result); // Check if the method returned true

        // Verify that SaveListToFile was called exactly once with any list of UserEntity
        _fileServiceMock.Verify(x => x.SaveListToFile(It.IsAny<List<UserEntity>>()), Times.Once);
    }

}
