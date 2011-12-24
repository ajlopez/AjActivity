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
            ulong id = this.service.NewUser("foo");

            Assert.IsTrue(id > 0);
        }

        [TestMethod]
        public void NewUserAndGetUser()
        {
            ulong id = this.service.NewUser("foo");

            User user = this.repository.LastUser();

            Assert.IsNotNull(user);
            Assert.AreEqual(id, user.Id);
            Assert.AreEqual("foo", user.Name);
        }

        [TestMethod]
        public void AddFollower()
        {
            ulong userid = this.service.NewUser("foo");
            User user = this.repository.LastUser();
            ulong followerid = this.service.NewUser("bar");
            User follower = this.repository.LastUser();

            this.service.AddFollower(userid, followerid);

            Assert.IsNotNull(user);
            Assert.IsNotNull(follower);

            Assert.IsTrue(user.FollowerIds.Contains(followerid));
            Assert.IsTrue(follower.FollowingIds.Contains(userid));
        }
    }
}
