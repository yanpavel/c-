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
    public class RemoveGroupTest : AuthTestBase
    {
       
        [Test]
        public void RemoveGroupTests()
        {
            GroupData group = new GroupData("qq");
            group.Header = null;
            group.Footer = null;

            if ((app.Groups.SelectGroup() is false))
            {
                app.Groups.CreateGroup(group);
            }
            app.Groups.RemoveGroup();
            Assert.IsFalse(app.Groups.SelectGroup());
        }
      
    }
}
