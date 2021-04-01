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
    public class RemoveContactTest : AuthTestBase
    {
        [Test]
        public void RemoveContactTests()
        {
            ContactData contact = new ContactData("John1"); 
            contact.LastName = "Doe1";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

          
            app.Contacts.RemoveContact();

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.RemoveAt(1);

            Assert.AreEqual(oldContacts, newContacts);
            
        }

        
    }
}
