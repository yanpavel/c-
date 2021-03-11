using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

            app.Contacts.CreateContact(contact);

        }      
       
    }
}