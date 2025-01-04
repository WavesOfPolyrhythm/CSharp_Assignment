
using Business.Entities;
using System.Diagnostics;
using System.Text.Json;

namespace Business.Services;

public class FileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;

    //Refactored JsonSerializerOptions into a private field for reusability and consistency
    private readonly JsonSerializerOptions _jsonSerializerOptions;


    // Initializes the FileService with a directory path, file name, and JSON serialization options
    public FileService(string directoryPath ="Data", string fileName = "list.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
        _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
    }

    public void SaveListToFile(List<UserEntity> list)
    {
        try
        {
            //Creates directory if it does not exist
            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);

            //Serializes the list of UserEntity objects to JSON and writes it to the specified file
            var json = JsonSerializer.Serialize(list, _jsonSerializerOptions);
            File.WriteAllText(_filePath, json);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    public List<UserEntity> LoadListFromFile()
    {
        try
        {

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
