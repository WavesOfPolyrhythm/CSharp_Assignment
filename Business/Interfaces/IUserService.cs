using Business.Entities;

namespace Business.Interfaces
{
    public interface IUserService
    {
        bool CreateContact(UserEntity user);
        IEnumerable<UserEntity> ViewContacts();
    }
}