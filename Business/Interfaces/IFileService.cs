using Business.Entities;

namespace Business.Interfaces
{
    public interface IFileService
    {
        List<UserEntity> LoadListFromFile();
        void SaveListToFile(List<UserEntity> list);
    }
}