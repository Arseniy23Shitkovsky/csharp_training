using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {   
        [Test]
        public void ContactCreationTest()
        {            
            ContactData contact = new ContactData("Arseniy", "Shitkovskiy");   
                      
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.CreateContact(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort(); 
           
            Assert.AreEqual(oldContacts, newContacts);
        }   
    }
}


