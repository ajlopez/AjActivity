using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AjActivity.Services;

namespace AjActivity.Tests.Services
{
    [TestClass]
    public class ActivityServiceTests
    {
        private ActivityService service;

        [TestInitialize]
        public void Setup()
        {
            this.service = new ActivityService();
        }

        [TestMethod]
        public void NewMessage()
        {
            ulong id = this.service.NewMessage(1, "foo");

            Assert.IsTrue(id > 0);
        }
    }
}
