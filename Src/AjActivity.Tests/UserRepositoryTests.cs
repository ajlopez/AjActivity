using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AjActivity.Model;
using AjActivity.Collections;

namespace AjActivity.Tests
{
    [TestClass]
    public class UserRepositoryTests
    {
        [TestMethod]
        public void AddUserOne()
        {
            UserRepository repository = new UserRepository();
            User user = new User(1, "one");
            repository.SetUser(user);
            User result = repository.GetUser(user.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(user, result);
        }

        [TestMethod]
        public void AddOneHundredUsers()
        {
            UserRepository repository = new UserRepository();

            for (ushort k = 1; k <= 100; k++)
            {
                User user = new User(k, "user"+k);
                repository.SetUser(user);
            }

            for (ushort k = 1; k <= 100; k++)
            {
                User result = repository.GetUser(k);
                Assert.IsNotNull(result);
                Assert.AreEqual((ulong) k, result.Id);
                Assert.AreEqual("user" + k, result.Name);
            }
        }

        [TestMethod]
        public void AddOneThousandUsers()
        {
            UserRepository repository = new UserRepository();

            for (ushort k = 1; k <= 1000; k++)
            {
                User user = new User(k, "user" + k);
                repository.SetUser(user);
            }

            for (ushort k = 1; k <= 1000; k++)
            {
                User result = repository.GetUser(k);
                Assert.IsNotNull(result);
                Assert.AreEqual((ulong)k, result.Id);
                Assert.AreEqual("user" + k, result.Name);
            }
        }
    }
}
