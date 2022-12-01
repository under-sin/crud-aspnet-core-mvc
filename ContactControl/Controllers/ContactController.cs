using ContactControl.Filters;
using ContactControl.Models;
using ContactControl.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactControl.Controllers;

[PageForLoggedUser]
public class ContactController : Controller
{
    private readonly IContactRepository _contactRepository;

    public ContactController(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public IActionResult Index()
    {
        List<ContactModel> contacts = _contactRepository.GetAll();
        return View(contacts);
    }

    public IActionResult Insert()
    {
        return View();
    }

    public IActionResult Edit(int id)
    {
        ContactModel contact = _contactRepository.GetById(id);
        return View(contact);
    }

    public IActionResult ConfirmRemove(int id)
    {
        ContactModel contact = _contactRepository.GetById(id);
        return View(contact);
    }

    public IActionResult Remove(int id)
    {
        try
        {
            bool removed = _contactRepository.Remove(id);

            if(removed)
                TempData["SuccessMessage"] = "Contact removed successfully";
            else
                TempData["ErrorMessage"] = "Error when trying to remove contact";

            return RedirectToAction("Index");
        }
        catch (Exception error)
        {
            TempData["ErrorMessage"] = $"Error when trying to remove contact. More details: {error.Message}";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult Insert(ContactModel contact)
    {
        try
        {
            // validando o conteúdo do contact
            if (ModelState.IsValid)
            {
                _contactRepository.Insert(contact);
                TempData["SuccessMessage"] = "Contact successfully registered";
                return RedirectToAction("Index");
            }

            return View(contact);
        }
        catch (Exception error)
        {
            TempData["ErrorMessage"] = $"Error registering contact. More details: {error.Message}";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult Update(ContactModel contact)
    {
        try
        {
            // validando o conteúdo do contact
            if (ModelState.IsValid)
            {
                _contactRepository.Update(contact);
                TempData["SuccessMessage"] = "Contact successfully updated";
                return RedirectToAction("Index");
            }
            // Retornando para a View Edit
            return View("Edit", contact);
        }
        catch (Exception error)
        {
            TempData["ErrorMessage"] = $"Error updating contact. More details: {error.Message}";
            return RedirectToAction("Index");
        }
    }
}
