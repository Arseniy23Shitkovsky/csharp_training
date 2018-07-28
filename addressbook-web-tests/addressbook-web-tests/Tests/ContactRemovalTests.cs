using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
        

        public class ContactRemovalTests : AuthTestBase
    {

            [Test]
            public void ContactRemovalTest()
        {
            if (!app.Contacts.IsContactPresent())
            {
                ContactData contact = new ContactData("Arseniy");
                contact.Lastname = "Shitkovskiy";
                app.Contacts.CreateContact(contact);
            }

              List<ContactData> oldContacts = app.Contacts.GetContactList();
              app.Contacts.RemovalContact(1);
              List<ContactData> newContacts = app.Contacts.GetContactList();
              oldContacts.RemoveAt(1);
              oldContacts.Sort();
              newContacts.Sort();

              Assert.AreEqual(oldContacts, newContacts);
            }
        }
    
}
