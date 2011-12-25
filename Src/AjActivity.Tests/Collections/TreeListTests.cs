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
        public void AddAndEnumerateOneHundredElements()
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

        [TestMethod]
        public void EmptyListContainsNoElements()
        {
            TreeList<int> list = new TreeList<int>();

            Assert.AreEqual(0, list.Count);
            Assert.IsFalse(list.Contains(0));
            Assert.IsFalse(list.Contains(1));
            Assert.IsFalse(list.Contains(2));
        }

        [TestMethod]
        public void AddAndEnumerateOneHundredElementsWithNodeSizeTen()
        {
            TreeList<int> list = new TreeList<int>(10);

            for (int k = 1; k <= 100; k++)
                list.Add(k);

            Assert.AreEqual(100, list.Count);

            int j = 0;

            foreach (var n in list)
                Assert.AreEqual(++j, n);

            Assert.AreEqual(100, j);
        }

        [TestMethod]
        public void AddAndEnumerateOneThousandElementsWithNodeSizeTen()
        {
            TreeList<int> list = new TreeList<int>(10);

            for (int k = 1; k <= 1000; k++)
                list.Add(k);

            Assert.AreEqual(1000, list.Count);

            int j = 0;

            foreach (var n in list)
                Assert.AreEqual(++j, n);

            Assert.AreEqual(1000, j);
        }
    }
}
