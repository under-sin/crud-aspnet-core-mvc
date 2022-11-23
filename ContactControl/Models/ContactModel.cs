using System.ComponentModel.DataAnnotations;

namespace ContactControl.Models;
public class ContactModel
{
    public int Id { get; set; }

    [Display(Name = "Nome")]
    [Required(ErrorMessage = "Enter contact name")]
    public string Name { get; set; }

    [Display(Name = "Email")]
    [Required(ErrorMessage = "Enter contact email")]
    [EmailAddress(ErrorMessage = "Email is not valid")] // validando o email
    public string Email { get; set; }

    [Display(Name = "Telefone")]
    [Required(ErrorMessage = "Enter contact phone number")]
    [Phone(ErrorMessage = "Phone not valid")] // validando o número de telefone
    public string PhoneNumber { get; set; }
}

