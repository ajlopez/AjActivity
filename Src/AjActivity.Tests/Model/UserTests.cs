using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AjActivity.Model;

namespace AjActivity.Tests.Model
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void CreateUser()
        {
            User user = new User(1, "foo");

            Assert.AreEqual(1u, user.Id);
            Assert.AreEqual("foo", user.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RaiseWhenIdIsZero()
        {
            User user = new User(0, "foo");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RaiseWhenNameIsNull()
        {
            User user = new User(1, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RaiseWhenNameIsEmpty()
        {
            User user = new User(1, "");
        }
    }
}
