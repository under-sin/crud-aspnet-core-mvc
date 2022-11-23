using ContactControl.Data;
using ContactControl.Models;

namespace ContactControl.Repository;
public class ContactRepository : IContactRepository
{
    private readonly EFContext _context;

    public ContactRepository(EFContext context)
    {
        _context = context;
    }

    public List<ContactModel> GetAll()
    {
        return _context.Contacts.ToList();
    }

    public ContactModel Insert(ContactModel contact)
    {
        _context.Contacts.Add(contact);
        _context.SaveChanges();
        return contact;
    }
}

