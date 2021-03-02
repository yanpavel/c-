using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebtestAddressbook
{
   public class NavigationHelper : HelperBase
    {
     
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
          this.baseURL = baseURL;
        }

     

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
            public void ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }
            public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

            public void GoToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
           
    }
}
