using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Xunit;
using Business.Services;
using Business.Entities;

public class FileServiceTests
{
    [Fact]
    public void SaveListToFile_ShouldCreateFileWithCorrectContent()
    {

        //Code from ChatGPT. Verifies that a user can be saved to a file


        // ARRANGE

        //Creates a folder and filename, instantiating FileService for the test
        var directoryPath = "TestOutput";
        var fileName = "users.json";
        var fileService = new FileService(directoryPath, fileName);

        //Creates a list of two test users
        var testUsers = new List<UserEntity>
        {
            new UserEntity { Id = "1", FirstName = "User1", LastName = "Test1" },
            new UserEntity { Id = "2", FirstName = "User2", LastName = "Test2" }
        };


        // ACT

        //Calling the method SaveListToFile with the test object
        fileService.SaveListToFile(testUsers);

        // ASSERT

        //Checks if the file was created successfully
        var filePath = Path.Combine(directoryPath, fileName);
        Assert.True(File.Exists(filePath), "File should be created.");

        //Reads content as a JSON string
        var fileContent = File.ReadAllText(filePath);

        //Deserializes the JSON content into a list of UserEntity objects
        var deserializedUsers = JsonSerializer.Deserialize<List<UserEntity>>(fileContent);

        //Checks if the deseriliazation was successfull and the list is not null
        Assert.NotNull(deserializedUsers);
        Assert.Equal(testUsers.Count, deserializedUsers.Count);

        //Checks that testUsers match with the deserialized users
        Assert.Equal(testUsers[0].FirstName, deserializedUsers[0].FirstName);
        Assert.Equal(testUsers[1].LastName, deserializedUsers[1].LastName);

        // Cleanup
        //Removes the created folder and file
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        if (Directory.Exists(directoryPath))
        {
            Directory.Delete(directoryPath, true);
        }
    }
}


