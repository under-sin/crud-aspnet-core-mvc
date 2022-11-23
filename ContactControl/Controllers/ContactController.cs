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
        _contactRepository.Remove(id);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Insert(ContactModel contact)
    {
        _contactRepository.Insert(contact);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Update(ContactModel contact)
    {
        _contactRepository.Update(contact);
        return RedirectToAction("Index");
    }

}
