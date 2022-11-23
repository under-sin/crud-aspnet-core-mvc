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

    public ContactModel GetById(int id)
    {
        return _context.Contacts.FirstOrDefault(x => x.Id == id);
    }

    public ContactModel Insert(ContactModel contact)
    {
        _context.Contacts.Add(contact);
        _context.SaveChanges();
        return contact;
    }

    public ContactModel Update(ContactModel contact)
    {
        ContactModel contactDB = GetById(contact.Id);

        if (contactDB == null)
            throw new Exception("Houve um erro ao tentar atualizar o contato");

        contactDB.Name= contact.Name;
        contactDB.Email= contact.Email;
        contactDB.PhoneNumber= contact.PhoneNumber;

        _context.Contacts.Update(contactDB);
        _context.SaveChanges();

        return contactDB;
    }
    public bool Remove(int id)
    {
        ContactModel contactDB = GetById(id);

        if (contactDB == null)
            throw new Exception("Houve um erro ao tentar deletar o contato");

        _context.Contacts.Remove(contactDB);
        _context.SaveChanges();

        return true;
    }
}

