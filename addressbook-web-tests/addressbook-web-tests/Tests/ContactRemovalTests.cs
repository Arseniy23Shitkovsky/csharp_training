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
           
            
            app.Contacts.RemovalContact();
        }
        }
    
}
