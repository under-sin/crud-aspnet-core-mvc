using ContactControl.Helpers;
using ContactControl.Models;
using ContactControl.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactControl.Controllers;

public class LoginController : Controller
{
    private readonly IUserRepository _userRepository;
    private readonly ISessionUser _session;

    public LoginController(IUserRepository userRepository, ISessionUser session)
    {
        _userRepository = userRepository;
        _session = session;
    }

    public IActionResult Index()
    {
        // se já exister uma sessão do usuário, direcionar para o home index
        if (_session.GetUserSession() != null) return RedirectToAction("Index", "Home");

        return View();
    }

    public IActionResult SignIn(LoginModel loginModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                // buscando o usuário com base no login
                UserModel user = _userRepository.GetByLogin(loginModel.Login);

                if (user != null)
                {
                    if(user.PasswordValidation(loginModel.Password))
                    {
                        // se o usuário for valido, criar sessão do usuário
                        _session.CreateUserSession(user);
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["ErrorMessage"] = $"Password is invalid";
                    return RedirectToAction("Index");
                }

                TempData["ErrorMessage"] = $"Username or password is invalid";
            }

            return View("Index");
        }
        catch (Exception error)
        {
            TempData["ErrorMessage"] = $"Error when trying to login. More details: {error.Message}";
            return RedirectToAction("Index");
        }
    }

    public IActionResult SignOut()
    {
        _session.RemoveUserSession(); 
        return RedirectToAction("Index", "Login");
    }

}
