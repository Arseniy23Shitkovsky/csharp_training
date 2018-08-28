using System.IO;
using System.Collections.Generic;
using NUnit.Framework;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30))
                {
                    Lastname = GenerateRandomString(100)
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> GetContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines("contacts.csv");
            foreach (string line in lines)
            {
                string[] elements = line.Split(',');
                contacts.Add(new ContactData(elements[0])
                {
                    Lastname = elements[1]                     
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> GetContactDataFromXmlFile()
        {
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader("contacts.xml"));
        }

        public static IEnumerable<ContactData> GetContactDataFromJsonFile()
        {            
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText("contacts.json"));
        }

        [Test, TestCaseSource("GetContactDataFromFile")]
        public void ContactCreationTest(ContactData contact)
        {                       
                      
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