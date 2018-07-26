using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public ContactHelper RemovalContact()
        {
            manager.Navigator.OpenContactPage();
            SelectContact(1);
            RemoveContact();
            CloseAlertWindow();
            
            return this;
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

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.OpenContactPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("entry.td"));
            foreach (IWebElement element in elements)
            {

                contacts.Add(new ContactData(element.Text));
                
            }
            return contacts;
        }


        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("(//input[@value='Delete'])")).Click();
            return this;
        }

        public ContactHelper CloseAlertWindow()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
                       
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public bool IsContactPresent()
        {         
            
                return IsElementPresent(By.Name("entry"));
            
        }

        public ContactHelper FillContactData(ContactData contact)
        {
            
            Type(By.Name("lastname"), contact.Firstname);
            Type(By.Name("firstname"), contact.Lastname);           
            return this;
        }

        public ContactHelper PressTheButtonEnter()
        {

            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper PressUpdateContact()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitContactModification()
        {            
            driver.FindElement(By.XPath("(.//*[@id='maintable']/tbody/tr[2]/td[8]/a/img)")).Click();
            return this;
        }
    }
}
