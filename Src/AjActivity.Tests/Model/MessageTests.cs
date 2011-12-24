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

            Assert.AreEqual(1, message.Id);
            Assert.AreEqual(2, message.UserId);
            Assert.AreEqual(datetime, message.DateTime);
            Assert.AreEqual("foo", message.Content);
        }
    }
}
