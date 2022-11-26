using System.ComponentModel.DataAnnotations;

namespace ContactControl.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Login required")]
    public string Login { get; set; }

    [Required(ErrorMessage = "Password required")]
    public string Password { get; set; }
}
