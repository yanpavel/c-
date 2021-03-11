using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebtestAddressbook
{
    public class AuthTestBase : Testbase
    {
        [SetUp]
        public void SetupLogin()
        {
           app.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
