using ContactControl.Models;
using ContactControl.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactControl.Controllers;
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

    // assinando o método como post
    [HttpPost]
    public IActionResult Insert(ContactModel contact)
    {
        _contactRepository.Insert(contact);
        return RedirectToAction("Index");
    }

    public IActionResult Update()
    {
        return View();
    }

    public IActionResult ConfirmRemove()
    {
        return View();
    }

}
