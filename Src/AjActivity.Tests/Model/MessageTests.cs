using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AjActivity.Model;

namespace AjActivity.Tests.Model
{
    [TestClass]
    public class MessageTests
    {
        [TestMethod]
        public void CreateMessage()
        {
            DateTime datetime = DateTime.UtcNow;
            Message message = new Message(1, 2, datetime, "foo");

            Assert.AreEqual(1u, message.Id);
            Assert.AreEqual(2u, message.UserId);
            Assert.AreEqual(datetime, message.DateTime);
            Assert.AreEqual("foo", message.Content);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RaiseWhenIdIsZero()
        {
            DateTime datetime = DateTime.UtcNow;
            Message message = new Message(0, 2, datetime, "foo");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RaiseWhenUserIdIsZero()
        {
            DateTime datetime = DateTime.UtcNow;
            Message message = new Message(1, 0, datetime, "foo");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RaiseWhenContentIsNull()
        {
            DateTime datetime = DateTime.UtcNow;
            Message message = new Message(1, 2, datetime, null);
        }
    }
}
