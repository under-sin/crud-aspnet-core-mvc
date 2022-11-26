﻿using ContactControl.Enums;
using System.ComponentModel.DataAnnotations;

namespace ContactControl.Models;
public class UserModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Enter user name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Enter user email")]
    [EmailAddress(ErrorMessage = "Email is not valid")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Enter user login")]
    public string Login { get; set; }

    [Required(ErrorMessage = "Enter user password")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Enter user perfil")]
    public PerfilEnum? Perfil { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // verificando se a senha passado no login é igual a do usuário instanciado
    public bool PasswordValidation(string password)
    {
        return Password == password;
    }
}
