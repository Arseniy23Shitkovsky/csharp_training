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
                ContactData contact = new ContactData("Arseniy", "Shitkovskiy");
                app.Contacts.CreateContact(contact);
            }
            
            ContactData newData = new ContactData();
            newData.Lastname = "Antonov";

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldDataContact = oldContacts[0];

            app.Contacts.ModifyContact(0,newData);
            oldContacts[0].Lastname = newData.Lastname;

            List<ContactData> newContacts = app.Contacts.GetContactList();            
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldDataContact.Id)
                {
                    Assert.AreEqual(newData.Lastname, contact.Lastname);
                }
            }
        }        
    }
}
