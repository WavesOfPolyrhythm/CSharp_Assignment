using Business.Entities;

namespace Business.Interfaces
{
    public interface IFileService
    {
        public string LoadListFromFile();
        bool SaveListToFile(string users);
    }
}