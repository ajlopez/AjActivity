using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AjActivity.Services;
using AjActivity.Model;

namespace AjActivity.Tests.Services
{
    [TestClass]
    public class UserServiceTests
    {
        private Repository repository;
        private UserService service;

        [TestInitialize]
        public void Setup()
        {
            this.repository = new Repository();
            this.service = new UserService(this.repository);
        }

        [TestMethod]
        public void NewUser()
        {
            User user = this.service.NewUser("foo");

            Assert.IsNotNull(user);
            Assert.IsTrue(user.Id > 0);
            Assert.AreEqual("foo", user.Name);
        }

        [TestMethod]
        public void AddFollower()
        {
            User user = this.service.NewUser("foo");
            User follower = this.service.NewUser("bar");

            this.service.AddFollower(user.Id, follower.Id);

            Assert.IsNotNull(user);
            Assert.IsNotNull(follower);

            Assert.IsTrue(user.FollowerIds.Contains(follower.Id));
            Assert.IsTrue(follower.FollowingIds.Contains(user.Id));
        }
    }
}
