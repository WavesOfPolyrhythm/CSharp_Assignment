using Business.Entities;

namespace Business.Interfaces
{
    public interface IFileService
    {
        List<UserEntity> LoadListFromFile();
        bool SaveListToFile(List<UserEntity> list);
    }
}