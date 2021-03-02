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
    public class NewGroup : Testbase
    {
       
        [Test]
        public void NewGroups()
        {
            GroupData group = new GroupData("aa");
            group.Header = "bb";
            group.Footer = "cc";
                       
            app.Groups.CreateGroup(group);
        }
        [Test]
        public void EmptyNewGroups()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.CreateGroup(group);
        }

    }
}
