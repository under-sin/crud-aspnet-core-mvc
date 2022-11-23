using System.ComponentModel.DataAnnotations;

namespace ContactControl.Models;
public class ContactModel
{
    public int Id { get; set; }

    [Display(Name = "Nome")]
    public string Name { get; set; }

    [Display(Name = "Email")]
    public string Email { get; set; }

    [Display(Name = "Telefone")]
    public string PhoneNumber { get; set; }
}

