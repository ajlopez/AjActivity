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

        [TestMethod]
        public void AddAndEnumerateTenElements()
        {
            TreeList<int> list = new TreeList<int>();

            for (int k = 1; k <= 100; k++)
                list.Add(k);

            Assert.AreEqual(100, list.Count);

            int j = 0;

            foreach (var n in list)
                Assert.AreEqual(++j, n);

            Assert.AreEqual(100, j);
        }
    }
}
