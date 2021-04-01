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
   public class ContactHelper : HelperBase
    {
        protected ContactData firstname;

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper CreateContact(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            GoToAddNew();
            FillContactForm(contact);
            SubmitContact();
            manager.Navigator.OpenHomePage();
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = driver.FindElements(By.TagName("td"));
                    string lastname = cells[1].Text;
                    string firstname = cells[2].Text;
                    contactCache.Add(new ContactData(lastname, firstname));
                }
            }              
            return new List<ContactData>(contactCache);
        }

   

        public ContactHelper ModifyContact(ContactData contact)
        {
            SelectContact(0);
            EditContact(0);
            FillContactForm(contact);
            UpdateContact();
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            contactCache = null;
            return this;
        }


        public ContactHelper RemoveContact()
        {
            manager.Navigator.OpenHomePage();

            SelectContact(1);
            DeleteContact();
          
            return this;
        }

      

        public ContactHelper SubmitContact()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            return this;
        }
        public ContactHelper GoToAddNew()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
           driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index+1 + "]")).Click();
           return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;

            return this;
        }
        private void EditContact(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index+1 + "]")).Click();
            
        }
        
        public bool SelectContact()
        {
            return IsElementPresent(By.XPath("//input[@role='checkbox']"));
        }


        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(0);
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workHome = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workHome

            };
        }

        public ContactData GetContactInformationFromViewForm(int v)
        {
            manager.Navigator.OpenHomePage();
            InitContactView(0);
            IList<IWebElement> names = driver.FindElements(By.Id("content"))[v].FindElements(By.TagName("b"));
            IList<IWebElement> content = driver.FindElements(By.Id("content"))[v].FindElements(By.TagName("b"));
            string name = names[0].Text;
            string address = content[0].Text;
            string h = content[1].Text;
            string m = content[2].Text;
            string w = content[3].Text;
            string email = content[4].Text;

            return new ContactData(name)
            {
                Address = address,
                HomePhone = h,
                MobilePhone = m,
                WorkPhone = w,
                Email = email

            };
        }

        private void InitContactView(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string firstName = cells[1].Text;
            string lastName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones

            };
        }

        public void InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
        }

    }
}
