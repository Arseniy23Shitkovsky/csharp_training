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

        public ContactHelper RemovalContact(int v)
        {
            manager.Navigator.OpenContactPage();
            SelectContact(v);
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
            ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));

            foreach (IWebElement row in elements)
            {
                var tdCollection = row.FindElements(By.TagName("td"));

                var lastName = tdCollection[1].Text;
                var firstName = tdCollection[2].Text;                

                contacts.Add(new ContactData(firstName, lastName));
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
