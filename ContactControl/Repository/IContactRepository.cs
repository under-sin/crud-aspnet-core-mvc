using ContactControl.Models;

namespace ContactControl.Repository;
public interface IContactRepository
{
    List<ContactModel> GetAll();

    ContactModel GetById(int id);

    ContactModel Insert(ContactModel contact);

    ContactModel Update(ContactModel contact);

    bool Remove(int id);
}
