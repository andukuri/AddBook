using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Repository
{
    public interface IRepository
    {
            IEnumerable<Contact> AllContacts();
            bool AddContact(Contact contact);
        bool UpdateContact(Contact contact);
        bool DeleteContact(Contact contact);
    }
}
