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
    }
}
