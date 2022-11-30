using ContactControl.Models;

namespace ContactControl.Helpers;

// interface para definir o contrado das sessões do usuário
public interface ISessionUser
{
    void CreateUserSession(UserModel user);
    void RemoveUserSession();
    UserModel GetUserSession();
}
