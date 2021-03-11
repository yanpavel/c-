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
    public class ContactModification : AuthTestBase
    {
        [Test]
        public void ContactModifications()
        {
            ContactData contact = new ContactData("Don");
            contact.Lastname = "Digidon";

            if ((app.Contacts.SelectContact() is false))
            {
                app.Contacts.CreateContact(contact);
            }            
            app.Contacts.ModifyContact(contact);
            Assert.IsFalse(app.Contacts.SelectContact());
        }


    }
}