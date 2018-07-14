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
        
        public ContactHelper(IWebDriver driver) : base(driver)
        {

        }

        public void GoToAddContactInterface()
        {

            driver.FindElement(By.LinkText("add new")).Click();
        }


        public void Logout()
        {

            driver.FindElement(By.LinkText("Logout")).Click();
        }

        public void FillContactData(ContactData contact)
        {

            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Lastname);
        }


        public void PressTheButtonEnter()
        {

            driver.FindElement(By.Name("submit")).Click();
        }
    }
}
