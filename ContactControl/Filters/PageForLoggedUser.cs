using ContactControl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace ContactControl.Filters;

// criando filtro para só deixar entrar na aplicação quem estiver logado
// para usar esse filtro basta coloca nas controller [PageForLoggedUser]
public class PageForLoggedUser : ActionFilterAttribute
{
    // o OnActionExecuted executa antes de qualquer coisa, então vamos fazer um override para fazer a verificação
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        string userSession = context.HttpContext.Session.GetString("UserSessionLogin");

        if(string.IsNullOrEmpty(userSession))
        {
            // Se a sessão do usuário for vázia o RedirectToRouteResult vai redirecionar para a página de login
            context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
        }
        else
        {
            UserModel user = JsonSerializer.Deserialize<UserModel>(userSession);

            // mesma coisa aqui, se o usuário for nulo o RedirectToRouteResult vai redirecionar para o login
            if (user == null)
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
        }

        base.OnActionExecuted(context);
    }
}
