using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Models;

namespace AddressBook.Repository
{
    public class ContactsRepository 
    {
        private readonly ContactContext _context;
        public ContactsRepository(ContactContext context)
        {
            _context = context;

           
        }
        public IEnumerable<Contact> AllContacts()
        {
            return  _context.Contacts;
        }


        public bool AddContact(Contact contact)
        {
            
           return _context.AddContact(contact);

        }

        public bool UpdateContact(Contact contact)
        {

            return _context.UpdateContact(contact);

        }

        public bool DeleteContact(Contact contact)
        {

            return _context.DeleteContact(contact);

        }
    }
}
