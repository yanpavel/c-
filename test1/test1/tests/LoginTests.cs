using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebtestAddressbook
{
    [TestFixture]
    public class LoginTests:Testbase
    {
        [Test]
        public void LoginWithValidCredenials()
        {
            //prepare
            app.Auth.Logout();

            //action
            AccountData account = new AccountData ("admin","secret");
            app.Auth.Login(account);
            //verification
            Assert.IsTrue(app.Auth.IsLoggedIn());
        }

        [Test]
        public void LoginWithInvalidCredenials()
        {
            //prepare
            app.Auth.Logout();

            //action
            AccountData account = new AccountData("admin", "123456");
            app.Auth.Login(account);
            //verification
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }
    }
}
