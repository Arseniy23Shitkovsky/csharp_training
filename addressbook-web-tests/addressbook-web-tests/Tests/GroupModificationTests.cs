using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : AuthTestBase
    {

        [Test]
        public void GroupModificationTest()
        {
            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsGroupPresent())

            {
                GroupData group = new GroupData("aaa");
                group.Header = "sss";
                group.Footer = "ddd";
                app.Groups.Create(group);

            }            

            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(newData,0);
            oldGroups[0].Name = newData.Name;
            List<GroupData> newGroups = app.Groups.GetGroupList();
            
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
