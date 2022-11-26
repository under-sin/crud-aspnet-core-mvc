using ContactControl.Models;
using ContactControl.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactControl.Controllers;

public class LoginController : Controller
{
    private readonly IUserRepository _userRepository;
    public LoginController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IActionResult Index()
    {
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

}
