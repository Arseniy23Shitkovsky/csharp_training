using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        
        public ContactHelper(ApplicationManager manager) : base(manager)
        {

        }

        public ContactHelper RemovalContact(int v)
        {
            manager.Navigator.OpenContactPage();
            SelectContact(v);
            RemoveContact();
            CloseAlertWindow();
            
            return this;
        }

        public int GetContactCount()
        {
            Thread.Sleep(4000);
            return driver.FindElements(By.Name("entry")).Count;
        }

        public ContactHelper ModifyContact(int v, ContactData newData)
        {
            manager.Navigator.OpenContactPage();            
            InitContactModification();
            FillContactData(newData);
            PressUpdateContact();           

            return this;
        }
                
        public ContactHelper CreateContact(ContactData contact)
        {
            manager.Navigator.GoToAddContactInterface();
            FillContactData(contact);
            PressTheButtonEnter();   
            
            return this;
        }

        private List<ContactData> contactCache = null;
        
        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {    
                contactCache = new List<ContactData>();
                manager.Navigator.OpenContactPage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));                
                foreach (IWebElement row in elements)
                {
                    var tdCollection = row.FindElements(By.TagName("td"));

                    var lastName = tdCollection[1].Text;
                    var firstName = tdCollection[2].Text;

                    contactCache.Add(new ContactData(row.Text)
                    {
                        Id = row.FindElement(By.TagName("td")).GetAttribute("id")
                    });
                }
            }
            
            return new List<ContactData>(contactCache);
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("(//input[@value='Delete'])")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper CloseAlertWindow()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {                       
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" +(index + 1)+ "]")).Click();
            return this;
        }

        public bool IsContactPresent()
        {            
            return IsElementPresent(By.Name("entry"));            
        }

        public ContactHelper FillContactData(ContactData contact)
        {            
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);           
            return this;
        }

        public ContactHelper PressTheButtonEnter()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper PressUpdateContact()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification()
        {            
            driver.FindElement(By.XPath("(.//*[@id='maintable']/tbody/tr[2]/td[8]/a/img)")).Click();
            return this;
        }
    }
}
