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
    public class RemoveGroupTest : Testbase
    {
       
        [Test]
        public void RemoveGroupTests()
        {
            app.Groups.RemoveGroup();
        }
                

       

      
    }
}
