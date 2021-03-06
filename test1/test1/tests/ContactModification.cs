﻿using System;
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
            ContactData contact = new ContactData("Doe1");
            contact.LastName = "John1";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            
            app.Contacts.ModifyContact(contact);
            

            List<ContactData> newContacts = app.Contacts.GetContactList();

            
            oldContacts[0].LastName = contact.LastName;
            oldContacts[0].FirstName = contact.FirstName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts); 
            
        }


    }
}