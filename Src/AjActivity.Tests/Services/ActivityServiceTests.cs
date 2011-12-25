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
    public class ActivityServiceTests
    {
        private UserRepository userrepository;
        private MessageRepository msgrepository;
        private ActivityService service;
        private User user;
        private IList<User> followers = new List<User>();

        [TestInitialize]
        public void Setup()
        {
            this.userrepository = new UserRepository();
            this.msgrepository = new MessageRepository();
            this.service = new ActivityService(this.msgrepository, this.userrepository);

            UserService uservice = new UserService(this.userrepository);
            this.user = uservice.NewUser("user");

            for (int k = 1; k <= 100; k++)
            {
                User follower = uservice.NewUser("follower" + k);
                uservice.AddFollower(this.user.Id, follower.Id);
                this.followers.Add(follower);
            }
        }

        [TestMethod]
        public void NewMessage()
        {
            Message message = this.service.NewMessage(1, "foo");

            Assert.IsNotNull(message);
            Assert.IsTrue(message.Id > 0);
            Assert.AreEqual("foo", message.Content);
        }

        [TestMethod]
        public void NewMessageInUserTimeline()
        {
            Message message = this.service.NewMessage(1, "foo");

            Assert.IsTrue(this.user.Messages.Contains(message));
        }

        [TestMethod]
        public void NewMessageInFollowersTimeline()
        {
            Message message = this.service.NewMessage(1, "foo");

            foreach (User follower in this.followers)
            {
                Assert.IsTrue(follower.Messages.Contains(message));
            }
        }

        [TestMethod]
        public void NewMessageWithExistingMessages()
        {
            for (int k = 1; k <= 100; k++)
                this.service.NewMessage(1, "bar" + k);

            Message message = this.service.NewMessage(1, "foo");

            Assert.AreEqual(101u, message.Id);
            Assert.IsNotNull(message);
            Assert.AreEqual("foo", message.Content);
            Assert.AreEqual(1u, message.UserId);
        }
    }
}
