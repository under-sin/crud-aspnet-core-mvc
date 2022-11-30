using ContactControl.Models;
using System.Text.Json;

namespace ContactControl.Helpers;

public class Session : ISessionUser
{
    // inteface do aspnet. Essa interface vai permitir o armazenamento da sessão do usuário
    private readonly IHttpContextAccessor _httpContext;
    public Session(IHttpContextAccessor httpContext)
    {
        _httpContext = httpContext;
    }

    public UserModel GetUserSession()
    {
        string userSession = _httpContext.HttpContext.Session.GetString("UserSessionLogin");

        if (string.IsNullOrEmpty(userSession)) return null;

        return JsonSerializer.Deserialize<UserModel>(userSession);
    }

    public void CreateUserSession(UserModel user)
    {
        string value = JsonSerializer.Serialize(user);
        //HttpContext.Session.SetString RECEBE um objeto chave valor, sendo que os dois tem que ser do tipo string. Por isso é necessário serializar o user
        _httpContext.HttpContext.Session.SetString("UserSessionLogin", value);
    }

    public void RemoveUserSession()
    {
        _httpContext.HttpContext.Session.Remove("UserSessionLogin");
    }
}
