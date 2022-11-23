using ContactControl.Models;

namespace ContactControl.Repository;
public interface IContactRepository
{
    List<ContactModel> GetAll();
    ContactModel Insert(ContactModel contact);
}
