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
    public class ContactModification : AuthTestBase
    {
        [Test]
        public void ContactModifications()
        {
            ContactData contact = new ContactData("Don");
            contact.Lastname = "Digidon";

            List<ContactData> oldContacts = app.Contacts.GetContactList(0);

            
            app.Contacts.ModifyContact(contact);
            

            List<ContactData> newContacts = app.Contacts.GetContactList(0);

            oldContacts[0].Firstname = contact.Firstname;
            oldContacts[0].Lastname = contact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            
        }


    }
}