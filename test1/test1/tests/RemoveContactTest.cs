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
            ContactData contact = new ContactData("Don"); 
            contact.Lastname = "Digidon";

            List<ContactData> oldContacts = app.Contacts.GetContactList(0);

          
            app.Contacts.RemoveContact();

            List<ContactData> newContacts = app.Contacts.GetContactList(0);

            oldContacts.RemoveAt(1);

            Assert.AreEqual(oldContacts, newContacts);
            
        }

        
    }
}
