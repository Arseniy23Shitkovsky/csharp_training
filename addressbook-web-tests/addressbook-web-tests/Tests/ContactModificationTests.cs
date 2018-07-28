using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactModificationTests : AuthTestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            if (!app.Contacts.IsContactPresent())
            {
                ContactData contact = new ContactData("Arseniy");
                contact.Lastname = "Shitkovskiy";
                app.Contacts.CreateContact(contact);

            }
            
            ContactData newData = new ContactData(null);
            newData.Lastname = "Antonov";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.ModifyContact(0,newData);
            oldContacts[0].Lastname = newData.Lastname;

            List<ContactData> newContacts = app.Contacts.GetContactList();            
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }

        
    }
}
