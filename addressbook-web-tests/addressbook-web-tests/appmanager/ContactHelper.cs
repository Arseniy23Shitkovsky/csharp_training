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
            manager.Auth.Logout();
            return this;
        }

        public ContactHelper ModifyContact(int v, ContactData newData)
        {
            manager.Navigator.OpenContactPage();
            InitContactModification();
            FillContactData(newData);
            PressUpdateContact();
            manager.Auth.Logout();

            return this;
        }

        
        public ContactHelper CreateContact(ContactData contact)
        {
            manager.Navigator.GoToAddContactInterface();
            FillContactData(contact);
            PressTheButtonEnter();
            manager.Auth.Logout();
            return this;
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
