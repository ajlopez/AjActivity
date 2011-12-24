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

            User user = this.repository.GetUserById(id);

            Assert.IsNotNull(user);
            Assert.AreEqual(id, user.Id);
            Assert.AreEqual("foo", user.Name);
        }

        [TestMethod]
        public void NewMessageWithExistingMessages()
        {
            this.repository.AddUser(new User(100, "bar"));
            ulong id = this.service.NewUser("foo");

            Assert.AreEqual(101u, id);

            User user = this.repository.GetUserById(id);

            Assert.IsNotNull(user);
            Assert.AreEqual(id, user.Id);
            Assert.AreEqual("foo", user.Name);
        }

        [TestMethod]
        public void AddFollower()
        {
            ulong userid = this.service.NewUser("foo");
            ulong followerid = this.service.NewUser("bar");

            this.service.AddFollower(userid, followerid);

            User user = this.repository.GetUserById(userid);
            User follower = this.repository.GetUserById(followerid);

            Assert.IsNotNull(user);
            Assert.IsNotNull(follower);

            Assert.IsTrue(user.FollowerIds.Contains(followerid));
            Assert.IsTrue(follower.FollowingIds.Contains(userid));
        }
    }
}
