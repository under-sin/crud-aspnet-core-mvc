using ContactControl.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ContactControl.Controllers;

[PageForLoggedUser]
public class RestrictedController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
