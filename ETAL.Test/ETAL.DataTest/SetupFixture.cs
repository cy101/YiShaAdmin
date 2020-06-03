using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ETAL.Util;
using ETAL.Util.Model;

namespace ETAL.DataTest
{
    [SetUpFixture]
    public class SetupFixture
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            GlobalContext.SystemConfig = new SystemConfig
            {
                DBProvider = "MySql",
                DBConnectionString = "server=localhost;database=etal_admin;user=root;password=luoyong;port=3306;pooling=true;max pool size=20;persist security info=True;charset=utf8mb4;",
                DBCommandTimeout = 180,
                DBBackup = "DataBase"
            };
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

        }
    }
}
