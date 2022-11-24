using ContactControl.Models;

namespace ContactControl.Repository;
public interface IUserRepository
{
    List<UserModel> GetAll();

    UserModel GetById(int id);

    UserModel Insert(UserModel user);

    UserModel Update(UserModel user);

    bool Remove(int id);
}
