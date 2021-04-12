﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebtestAddressbook
{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);

        }

        [Test]
        public void TestContactViewInformation()
        {

            string AllFieldsfromForm = app.Contacts.GetAllFieldsContactInformationFromEditForm(0);
            //ContactDate fromProfile = app.Contacts.GetContactInformationFromProfile(0);
            System.Console.Out.Write(app.Contacts.GetContactInformationFromViewForm(0));
            Assert.AreEqual(AllFieldsfromForm.ToString(), app.Contacts.GetContactInformationFromViewForm(0));

        }
    }
}
