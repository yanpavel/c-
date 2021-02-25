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
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToAddNew();
            ContactData contact = new ContactData("John1");
            contact.Lastname = "Doe1";
            FillContactForm(contact);
            SubmitContact();
            GoToHomePage();
        }      
       
    }
}