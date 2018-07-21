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
   public class GroupHelper : HelperBase
    {
        
        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();           
            return this;
        }

        public GroupHelper Modify(GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup();
            InitGroupModification();
            FillGroupForm(newData);            
            SubmitGroupModification();
            ReturnToGroupsPage();
            manager.Auth.Logout();


            return this;
        }

       

        public GroupHelper Removal()
        { 
        manager.Navigator.GoToGroupsPage();
            SelectGroup();
            RemoveGroup();
            ReturnToGroupsPage();
        manager.Auth.Logout();
            return this;
        }
        public GroupHelper SelectGroup()
        {
            if (IsGroupPresent())
            {
                
            }
            else
            {
                GroupData group = new GroupData("aaa");
                group.Header = "sss";
                group.Footer = "ddd";
                InitNewGroupCreation();
                FillGroupForm(group);
                SubmitGroupCreation();
                ReturnToGroupsPage();
                

            }
                                             
           
            driver.FindElement(By.XPath("(//input[@name='selected[]'])")).Click();
            return this;
        }

        

        public bool IsGroupPresent()
        {
            return IsElementPresent(By.Name("selected[]"));
        }
        
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper InitNewGroupCreation()
        {

            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
           
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        

        public GroupHelper SubmitGroupCreation()
        {

            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

    }
}
