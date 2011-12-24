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
        [TestMethod]
        public void NewMessage()
        {
            ActivityService service = new ActivityService();

            ulong id = service.NewMessage(1, "foo");

            Assert.IsTrue(id > 0);
        }
    }
}
