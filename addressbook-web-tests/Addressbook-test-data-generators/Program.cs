using System;
using System.Collections.Generic;
using System.IO;
using WebAddressbookTests;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Addressbook_test_data_generators
{
    public class Program
    {
        private static void SaveGroupsDataForCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach(GroupData group in groups)
            {
                writer.WriteLine(String.Format("{0},{1},{2}", group.Name, group.Header, group.Footer));
            }

            writer.Close();
        }

        private static void SaveContactDataForCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("{0},{1}", contact.Firstname, contact.Lastname));
            }

            writer.Close();
        }

        private static void SaveGroupsDataForXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        private static void SaveGroupsDataForJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups,Newtonsoft.Json.Formatting.Indented)); 
        }

        private static void SaveContactDataForXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        private static void SaveContactDataForJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        public static void Main(string[] args)
        {
            string dataType = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string fileType = args[3];

            if (dataType == "group")
            {
                List<GroupData> groups = CreateGroups(count);
                
                switch (fileType)
                {
                    case "csv":
                        SaveGroupsDataForCsvFile(groups, writer);
                        break;
                    case "xml":
                        SaveGroupsDataForXmlFile(groups, writer);
                        break;
                    case "json":
                        SaveGroupsDataForJsonFile(groups, writer);
                        break;
                    default:
                        Console.Out.Write("Unrecognized format " + fileType);
                        break;
                }                
            }

            if (dataType == "contact")
            {
                List<ContactData> contacts = CreateContact(count);
                switch (fileType)
                {
                    case "csv":
                        SaveContactDataForCsvFile(contacts, writer);
                        break;
                    case "xml":
                        SaveContactDataForXmlFile(contacts, writer);
                        break;
                    case "json":
                        SaveContactDataForJsonFile(contacts, writer);
                        break;
                    default:
                        Console.Out.Write("Unrecognized format " + fileType);
                        break;
                }
            }
        }

        private static List<GroupData> CreateGroups(int count)
        {
            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }

            return groups;
        }

        private static List<ContactData> CreateContact(int count)
        {
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(10))
                {
                    Lastname = TestBase.GenerateRandomString(10)                    
                });
            }

            return contacts;
        }
    }
}