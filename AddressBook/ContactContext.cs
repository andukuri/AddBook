using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace AddressBook
{
    public class ContactContext : DbContext
    {
        public List<Contact> Contacts { get; set; }
        private string filename = "Contacts.json";

        public ContactContext()
        {           
                Contacts = new List<Contact>();
        }

        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
            if (Contacts == null && File.Exists(filename))
            {
                Contacts = JsonConvert.DeserializeObject<List<Contact>>(File.ReadAllText(filename));
            }
            else
                Contacts = new List<Contact>();
        }

        public bool AddContact(Contact contact)
        {
            try
            {
                    Contacts.Add(contact);

                File.WriteAllText(filename, JsonConvert.SerializeObject(Contacts));
              return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool UpdateContact(Contact contact)
        {
            try
            {
                int c = Contacts.FindIndex(con => con.Id == contact.Id);

                if (c>-1)
                {
                    Contacts.ElementAt(c).FirstName = contact.FirstName;
                    Contacts.ElementAt(c).LastName = contact.LastName;
                    Contacts.ElementAt(c).Address = contact.Address;
                    Contacts.ElementAt(c).City = contact.City;
                    Contacts.ElementAt(c).State = contact.State;
                    Contacts.ElementAt(c).Country = contact.Country;
                    Contacts.ElementAt(c).Zip = contact.Zip;
                }
                

                File.WriteAllText(filename, JsonConvert.SerializeObject(Contacts));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool DeleteContact(Contact contact)
        {
            try
            {
                int c = Contacts.FindIndex(con => con.Id == contact.Id);

                if (c>-1)
                    Contacts.RemoveAt(c);

                File.WriteAllText(filename, JsonConvert.SerializeObject(Contacts));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
