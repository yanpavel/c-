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
    public class NewContact : Testbase
    {
        [Test]
        public void NewContacts()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login (new AccountData("admin", "secret"));
            app.Contacts.GoToAddNew();
            ContactData contact = new ContactData("John1");
            contact.Lastname = "Doe1";
            app.Contacts.FillContactForm(contact);
            app.Contacts.SubmitContact();
            app.Navigator.GoToHomePage();
        }      
       
    }
}