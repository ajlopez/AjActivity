using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AjActivity.Collections;

namespace AjActivity.Tests.Collections
{
    [TestClass]
    public class TreeListTests
    {
        [TestMethod]
        public void AddOneElement()
        {
            TreeList<int> list = new TreeList<int>();
            list.Add(1);
            Assert.AreEqual(1, list.Count);
        }
    }
}
