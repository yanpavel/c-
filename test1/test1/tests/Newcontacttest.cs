using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebtestAddressbook
{
    [TestFixture]
    public class NewContact : AuthTestBase
    {
        [Test]
        public void NewContacts()
        {
            ContactData contact = new ContactData("John1");
            contact.Lastname = "Doe1";

            List<ContactData> oldContacts = app.Contacts.GetContactList(0);
            app.Contacts.CreateContact(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList(0);
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }      
       
    }
}