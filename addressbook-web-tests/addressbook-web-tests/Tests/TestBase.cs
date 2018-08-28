using System;
using System.Text;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]

        public void SetupApplicationManager()
        {
          app = ApplicationManager.GetInstance();
          app.Auth.Login(new AccountData("admin", "secret"));
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {            
            int currentLenght = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < currentLenght; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }

            return builder.ToString();
        }
    }
}
