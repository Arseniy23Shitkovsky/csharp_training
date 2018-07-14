using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
       

        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.GoToAddContactInterface();
            ContactData contact = new ContactData("Arseniy");
            contact.Lastname = "Shitkovskiy";
            app.Contacts.FillContactData(contact);
            app.Contacts.PressTheButtonEnter();
            app.Auth.Logout();
        }

        
               
    }
}


