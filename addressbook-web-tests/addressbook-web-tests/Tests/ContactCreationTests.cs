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
            
            ContactData contact = new ContactData("Arseniy");
            contact.Lastname = "Shitkovskiy";

            app.Contacts.CreateContact(contact);
        }

        
               
    }
}


