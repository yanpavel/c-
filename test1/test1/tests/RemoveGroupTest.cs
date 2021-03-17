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
    public class RemoveGroupTest : AuthTestBase
    {
       
        [Test]
        public void RemoveGroupTests()
        {

            GroupData group = new GroupData("qq");
            group.Header = null;
            group.Footer = null;

            List<GroupData> oldGroups = app.Groups.GetGroupList();
                        

            app.Groups.RemoveGroup(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);
           


        }
      
    }
}
