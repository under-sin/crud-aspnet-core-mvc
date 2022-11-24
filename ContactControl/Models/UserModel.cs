using ContactControl.Enums;

namespace ContactControl.Models;
public class UserModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public PerfilEnum Perfil { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
