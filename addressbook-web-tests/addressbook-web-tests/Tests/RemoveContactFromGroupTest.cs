using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemoveContactFromGroupTest : AuthTestBase        
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {
            GroupData group = GroupData.GetAll().First();

            List<ContactData> oldContactList = group.GetContacts();
            ContactData contact = oldContactList.First();

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();

            oldContactList.Remove(contact);

            newList.Sort();
            oldContactList.Sort();

            Assert.AreEqual(oldContactList, newList);
        }
    }
}
