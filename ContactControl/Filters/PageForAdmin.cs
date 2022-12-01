using ContactControl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace ContactControl.Filters;

// filtro para usuários admin (vai seguir a lógica do usuário logado e adicionar o admin)
public class PageForAdmin : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        string userSession = context.HttpContext.Session.GetString("UserSessionLogin");

        if(string.IsNullOrEmpty(userSession))
        {
            context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
        }
        else
        {
            UserModel user = JsonSerializer.Deserialize<UserModel>(userSession);

            if (user == null)
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            // válidando se o usuário é do tipo admin, se não for, vai redirecionar para a tela de restrito
            if (user.Perfil != Enums.PerfilEnum.Admin)
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Restricted" }, { "action", "Index" } });
        }

        base.OnActionExecuted(context);
    }
}
