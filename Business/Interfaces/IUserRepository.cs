using Business.Entities;

namespace Business.Interfaces
{
    public interface IUserRepository
    {
        List<UserEntity> LoadUsers();
        bool SaveUsers(List<UserEntity> users);
    }
}