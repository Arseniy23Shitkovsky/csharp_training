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

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenContactPage();
            InitContactModification(11);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            return new ContactData(firstname)
            {
                Lastname = lastname,
                Address = address,                
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };          
        }

        public string CreateTextByEditForm(ContactData editForm)
        {
            string name = editForm.Firstname + " " + editForm.Lastname;

            string homePhone = editForm.HomePhone != "" ? "H: " + editForm.HomePhone : "";
            string mobilePhone = editForm.MobilePhone != "" ? "M: " + editForm.MobilePhone : "";
            string workPhone = editForm.WorkPhone != "" ? "W: " + editForm.WorkPhone : "";

            return name + editForm.Address + homePhone + mobilePhone + workPhone + editForm.Email + editForm.Email2 + editForm.Email3;
        }

        public string GetTextContactDetail(int usernameIndex)
        {
            manager.Navigator.OpenDetailsPage(usernameIndex);
            string text = driver.FindElement(By.Id("content")).Text;

            IList<string> listElements = text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            string finallyText = "";

            foreach(string element in listElements)
            {
                finallyText += element;
            }

            return finallyText;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenContactPage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
               .FindElements(By.TagName("td"));
            string firstname = cells[2].Text;
            string lastname = cells[1].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;
            return new ContactData(firstname)
            {
                Lastname = lastname,
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        public ContactHelper RemovalContact(int v)
        {
            manager.Navigator.OpenContactPage();
            SelectContact(v);
            RemoveContact();
            CloseAlertWindow();
            
            return this;
        }

        public ContactHelper RemovalContact(string id)
        {
            manager.Navigator.OpenContactPage();
            SelectContact(id);
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
            InitContactModification(0);
            FillContactData(newData);
            PressUpdateContact();           

            return this;
        }

        public ContactHelper ModifyContact(string contactId, ContactData newData)
        {
            manager.Navigator.OpenContactPage();
            InitContactModification(contactId);
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

                    contactCache.Add(new ContactData(firstName)
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

        public ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
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

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
                
            return this;
        }

        public ContactHelper InitContactModification(string contactId)
        {
            driver.FindElement(By.Id(contactId)).FindElement(By.XPath("(//img[@alt='Edit'])")).Click();

            return this;
        }
    }
}