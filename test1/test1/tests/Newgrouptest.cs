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
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin","secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.InitGroupPage();
            GroupData group = new GroupData("aa");
            group.Header = "bb";
            group.Footer = "cc";
            app.Groups.FillGroupForm(group);
            app.Groups.SubmitGroupCreation();
            app.Navigator.ReturnToGroupPage();
        } 
       
    }
}
