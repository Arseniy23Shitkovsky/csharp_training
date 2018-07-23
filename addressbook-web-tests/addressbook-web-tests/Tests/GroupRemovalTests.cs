using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
       

        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToGroupsPage();

            if (!app.Groups.IsGroupPresent())

            {
                GroupData group = new GroupData("aaa");
                group.Header = "sss";
                group.Footer = "ddd";
                app.Groups.Create(group);
            }
            
            app.Groups.Removal();
        }

                          
                
                       
    }
}

