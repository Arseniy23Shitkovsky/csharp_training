using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactModificationTests : GroupTestBase
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
            
            ContactData newData = new ContactData();
            newData.Lastname = "Antonov";

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldDataContact = oldContacts[0];

            app.Contacts.ModifyContact(oldDataContact.Id, newData);

            oldDataContact.Lastname = newData.Lastname;

            List<ContactData> newContacts = ContactData.GetAll();            

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