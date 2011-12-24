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
        private Repository repository;
        private ActivityService service;

        [TestInitialize]
        public void Setup()
        {
            this.repository = new Repository();
            this.service = new ActivityService(this.repository);
        }

        [TestMethod]
        public void NewMessage()
        {
            ulong id = this.service.NewMessage(1, "foo");

            Assert.IsTrue(id > 0);
        }

        [TestMethod]
        public void NewMessageAndGetMessage()
        {
            ulong id = this.service.NewMessage(1, "foo");

            Message message = this.repository.Messages.Where(m => m.Id == id).SingleOrDefault();

            Assert.IsNotNull(message);
            Assert.AreEqual(id, message.Id);
            Assert.AreEqual("foo", message.Content);
            Assert.AreEqual(1u, message.UserId);
        }

        [TestMethod]
        public void NewMessageWithExistingMessages()
        {
            this.repository.AddMessage(new Message(100, 1, DateTime.UtcNow, "bar"));
            ulong id = this.service.NewMessage(1, "foo");

            Assert.AreEqual(101u, id);

            Message message = this.repository.Messages.Where(m => m.Id == id).SingleOrDefault();

            Assert.IsNotNull(message);
            Assert.AreEqual(id, message.Id);
            Assert.AreEqual("foo", message.Content);
            Assert.AreEqual(1u, message.UserId);
        }
    }
}
