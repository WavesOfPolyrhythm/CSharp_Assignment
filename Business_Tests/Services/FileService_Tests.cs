using Xunit;
using Moq;
using Business.Interfaces;
using Business.Services;


public class FileService_Tests


/// <summary>
/// Inspiration from Hans test with mock video combined with help from Chat GPT to restructure my tests for fileservice,
/// after I rearranged code to use repositories.
/// </summary>
/// 

{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly FileService _fileService;

    public FileService_Tests()
    {
        _fileServiceMock = new Mock<IFileService>();
        _fileService = new FileService();
    }

    /// <summary>
    /// Tests that <see cref="IFileService.SaveListToFile"/> is called once and returns true.
    /// </summary>
    [Fact]
    public void SaveListToFile_ShouldCallSaveMethodOnce()
    {
        // Arrange
        var content = "[{\"Id\":\"1\",\"FirstName\":\"Test\",\"LastName\":\"User\"}]";

        _fileServiceMock.Setup(fs => fs.SaveListToFile(It.IsAny<string>()))
                        .Returns(true);

        // Act
        var result = _fileServiceMock.Object.SaveListToFile(content);

        // Assert
        Assert.True(result);
        _fileServiceMock.Verify(fs => fs.SaveListToFile(It.IsAny<string>()), Times.Once);
    }


    /// <summary>
    /// Tests that the <see cref="IFileService.LoadListFromFile"/> method returns the correct mocked content.
    /// </summary>

    [Fact]
    public void LoadListFromFile_ShouldReturnMockedContent()
    {
        // Arrange
        var content = "[{\"Id\":\"1\",\"FirstName\":\"Test\",\"LastName\":\"User\"}]";

        _fileServiceMock.Setup(fs => fs.LoadListFromFile())
                        .Returns(content);

        // Act
        var result = _fileServiceMock.Object.LoadListFromFile();

        // Assert
        Assert.Equal(content, result); 
        _fileServiceMock.Verify(fs => fs.LoadListFromFile(), Times.Once); 
    }
}


