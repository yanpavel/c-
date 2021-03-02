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
    public class GroupModification:Testbase
    {
        [Test]
        public void GroupModifications()
        {
            GroupData group = new GroupData("qq");
            group.Header = "www";
            group.Footer = "ee";

            app.Groups.Modify(group);
        }
    }
}
