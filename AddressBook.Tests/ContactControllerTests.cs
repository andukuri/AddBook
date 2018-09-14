using System;
using Xunit;
using AddressBook.Controllers;
using AddressBook.Models;
using System.Collections.Generic;
using AddressBook.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Tests
{
    public class ContactControllerTests
    {
        public Contact contact;
        [Fact]
        public void TestAddContactController()
        {
            var mockrepo = new ContactsRepository(new ContactContext());
            var controller = new ContactsController(mockrepo);

            var result = controller.AddContact(GetContactsTest());

            var viewresult = Assert.IsType<Task<ActionResult<Contact>>>(result);
            var model = Assert.IsAssignableFrom<ActionResult<Contact>>(viewresult.Result.Result);
            Assert.Equal(contact, model.Value);
        }

        [Fact]
        public void TestUpdateContactController()
        {
            var mockrepo = new ContactsRepository(new ContactContext());
            var controller = new ContactsController(mockrepo);
            

            var result=controller.UpdateContact(GetUpdatesContactsTest());

            var viewresult = Assert.IsType<Task<ActionResult<bool>>>(result);
            var model = Assert.IsAssignableFrom<ActionResult<bool>>(viewresult.Result);
            Assert.Equal(true, viewresult.Result.Value);

        }

        [Fact]
        public void TestDeleteContactController()
        {
            var mockrepo = new ContactsRepository(new ContactContext());
            var controller = new ContactsController(mockrepo);

            var result = controller.DeleteContact(GetDeleteContactsTest());

            var viewresult = Assert.IsType<Task<ActionResult<bool>>>(result);
            var model = Assert.IsAssignableFrom<ActionResult<bool>>(viewresult.Result);
            Assert.Equal(true, viewresult.Result.Value);

        }


        private Contact GetContactsTest()
        {
             contact=new Contact() {
                FirstName="Test Firstname",
                LastName="Test Lastname",
                Address="123 main street",
                City="test state",
                State="test state",
                Zip="65652"
            };
          

            return contact;
        }

        private Contact GetUpdatesContactsTest()
        {
            Contact contacts = new Contact(){
                FirstName = "Test Firstname",
                LastName = "Test2 Lastname",
                Address = "123 main street",
                City = "test state",
                State = "test state",
                Zip = "65652"
            };

            return contacts;
        }

        private Contact GetDeleteContactsTest()
        {
            Contact contacts = new Contact()
            {
                FirstName = "Test1 Firstname",
                LastName = "Test1 Lastname",
                Address = "123 main street",
                City = "test state",
                State = "test state",
                Zip = "65652"
            };

            return contacts;
        }
    }
}
