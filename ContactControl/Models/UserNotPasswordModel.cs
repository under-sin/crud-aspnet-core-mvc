using ContactControl.Enums;
using System.ComponentModel.DataAnnotations;

namespace ContactControl.Models;
public class UserNotPasswordModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Enter user name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Enter user email")]
    [EmailAddress(ErrorMessage = "Email is not valid")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Enter user login")]
    public string Login { get; set; }

    [Required(ErrorMessage = "Enter user perfil")]
    public PerfilEnum? Perfil { get; set; }

}
