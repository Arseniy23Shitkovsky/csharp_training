﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL ) : base(manager)
        {
           this.baseURL = baseURL;
        }
        public void GoToHomePage()
        {
            if(driver.Url == baseURL + "addressbook/")
            {
                return;
            }

            driver.Navigate().GoToUrl(baseURL + "addressbook/");
            
        }

        public void GoToGroupsPage()
        {
            if(driver.Url == baseURL + "addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
            
        }

        public NavigationHelper GoToAddContactInterface()
        {

            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public NavigationHelper OpenContactPage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
            return this;
        }

        public void OpenDetailsPage(int index)
        {
            manager.Navigator.OpenContactPage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
               .FindElements(By.TagName("td"));
            cells[6].Click();            
        }
    }
}
