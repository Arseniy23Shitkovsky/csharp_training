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

            app.Contacts.ModifyContact(1,newData);


        }

        
    }
}
