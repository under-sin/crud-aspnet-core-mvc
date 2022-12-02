using ContactControl.Data;
using ContactControl.Models;

namespace ContactControl.Repository;
public class UserRepository : IUserRepository
{
    private readonly EFContext _context;

    public UserRepository(EFContext context)
    {
        _context = context;
    }

    public UserModel GetByLogin(string login)
    {
        // pegando o login do usuário
        return _context.Users.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
    }

    public List<UserModel> GetAll()
    {
        return _context.Users.ToList();
    }

    public UserModel GetById(int id)
    {
        return _context.Users.FirstOrDefault(x => x.Id == id);
    }

    public UserModel Insert(UserModel user)
    {
        user.CreatedAt = DateTime.Now;
        user.SetHashPassword(); // transformando a senha em hash
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public UserModel Update(UserModel user)
    {
        UserModel userDB = GetById(user.Id);

        if (userDB == null)
            throw new Exception("Houve um erro ao tentar atualizar o usuário");

        userDB.Name = user.Name;
        userDB.Email = user.Email;
        userDB.Login = user.Login;
        userDB.Perfil = user.Perfil;
        userDB.UpdatedAt = DateTime.Now;

        _context.Users.Update(userDB);
        _context.SaveChanges();

        return userDB;
    }
    public bool Remove(int id)
    {
        UserModel userDB = GetById(id);

        if (userDB == null)
            throw new Exception("Houve um erro ao tentar deletar o usuário");

        _context.Users.Remove(userDB);
        _context.SaveChanges();

        return true;
    }
}

