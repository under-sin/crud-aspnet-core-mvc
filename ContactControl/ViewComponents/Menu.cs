using ContactControl.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ContactControl.ViewComponents;

public class Menu : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        // o viewcomponent já tem o httpContext então fica mais fácil de pegar a sessão so usuário
        string userSession = HttpContext.Session.GetString("UserSessionLogin");

        if (string.IsNullOrEmpty(userSession)) return null;

        // deserializando o userSession
        UserModel user = JsonSerializer.Deserialize<UserModel>(userSession);

        // por padrão o viewComponent vai retornar para a view "Default"
        return View(user);
    }

}
