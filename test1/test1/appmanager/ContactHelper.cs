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
            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workHome,
                Email1 = email1,
                Email2 = email2,
                Email3= email3
                

            };
           
        }

        public string GetAllFieldsContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value") ;
            if (firstName == "")
            { firstName = "";
                return firstName;
            }
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            if (middleName == "")
            {
                middleName = "";
                return middleName;
            }
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            if (lastName == "")
            {
                lastName = "";
                return lastName;
            }
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value") + "\r\n";
            if (nickname == "")
            {
                nickname = "";
                return nickname;
            }
            string company = driver.FindElement(By.Name("company")).GetAttribute("value") + "\r\n";
            if (company == "")
            {
                company = "";
                return company;
            }
            string title = driver.FindElement(By.Name("title")).GetAttribute("value") + "\r\n";
            if (title == "")
            {
                title = "";
                return title;
            }
            string address = driver.FindElement(By.Name("address")).Text + "\r\n";
            if (address == "")
            {
                address = "";
                return address;
            }

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value") + "\r\n";
            if (homePhone == "")
            {
                homePhone = "";
                return homePhone;
            }
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value") + "\r\n";
            if (mobilePhone == "")
            {
                mobilePhone = "";
                return mobilePhone;
            }
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value") + "\r\n";
            if (workPhone == "")
            {
                workPhone = "";
                return workPhone;
            }
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value") + "\r\n";
            if (fax == "")
            {
                fax = "";
                return fax;
            }

            string email = driver.FindElement(By.Name("email")).GetAttribute("value") + "\r\n";
            if (email == "")
            {
                email = "";
                return email;
            }
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value") + "\r\n";
            if (email2 == "")
            {
                email2 = "";
                return email2;
            }
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value") + "\r\n";
            if (email3 == "")
            {
                email3 = "";
                return email3;
            }
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            if (homepage == "")
            {
                homepage = "";
                return homepage;
            }

            string fullname = firstName + " " + middleName + " " + lastName;

            
           
            return fullname + "\r\n" + nickname  + title  + company  + address + "\r\n" + "H: " + homePhone
                + "M: " + mobilePhone  + "W: " + workPhone  + "F: " + fax
                + "\r\n" + email  + email2  + email3  + "Homepage:" + "\r\n" + homepage;
          
        }
        public string GetContactInformationFromViewForm(int v)
        {
            manager.Navigator.OpenHomePage();
            InitContactView(0);
            
            string AllInfosInProfile = driver.FindElement(By.Id("content")).Text;            
            return AllInfosInProfile;
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
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;


            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails

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
