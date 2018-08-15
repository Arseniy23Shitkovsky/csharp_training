using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactInformationTest : AuthTestBase
    {
        [Test]

        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(11);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(11);

            //verification

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]

        public void TestContactDetailsInformation()
        {
            ContactData editForm = app.Contacts.GetContactInformationFromEditForm(11);

            string editFromText = app.Contacts.CreateTextByEditForm(editForm);
            string detailText = app.Contacts.GetTextContactDetail(11);

            Assert.AreEqual(editFromText, detailText);
        }
    }
}