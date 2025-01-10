
using Business.Entities;
using Business.Interfaces;
using System.Diagnostics;
using System.Text.Json;

namespace Business.Services;

/// <summary>
/// This class manages reading from and writing to a file. 
/// It handles saving data as JSON and loading it back when needed.
/// </summary>

public class FileService : IFileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;

    /// <summary>
    /// Initializes a new instance of <see cref="FileService"/>.
    /// Sets the directory and file path where data will be saved and loaded.
    /// </summary>
    /// <param name="directoryPath">The folder where the file will be stored (default: "Data").</param>
    /// <param name="fileName">The name of the file (default: "list.json").</param>

    public FileService(string directoryPath = "Data", string fileName = "list.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
    }

    /// <summary>
    /// Saves a JSON string to a file.
    /// </summary>
    /// <param name="users">The JSON string to save.</param>
    /// <returns>
    /// True if the save operation is successful; otherwise, false if an error occurs.
    /// </returns>
    public bool SaveListToFile(string users)
    {
        try
        {
            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);
            
            File.WriteAllText(_filePath, users);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Loads a JSON string from a file.
    /// </summary>
    /// <returns>
    /// The JSON string from the file, or "[]" (an empty JSON array) if the file doesn't exist or an error occurs.
    /// </returns>
    public string LoadListFromFile()
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                return "[]";
            }
            return File.ReadAllText(_filePath);
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return "[]";
        }
    }
}
