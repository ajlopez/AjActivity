using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AjActivity.Collections;

namespace AjActivity.Tests.Collections
{
    [TestClass]
    public class SparseArrayTests
    {
        [TestMethod]
        public void SetElementZero()
        {
            SparseArray<string> array = new SparseArray<string>(10);
            array[0] = "zero";
            Assert.AreEqual("zero", array[0]);
        }

        [TestMethod]
        public void SetOneHundredElements()
        {
            SparseArray<int> array = new SparseArray<int>(10);

            for (int k = 0; k < 100; k++)
                array[(ulong)k] = k;

            for (int k = 0; k < 100; k++)
                Assert.AreEqual(k, array[(ulong)k]);
        }

        [TestMethod]
        public void SetOneThousandElements()
        {
            SparseArray<int> array = new SparseArray<int>(10);

            for (int k = 0; k < 1000; k++)
            {
                array[(ulong)k] = k;
                Assert.AreEqual(k, array[(ulong)k]);
                if (k>1)
                    Assert.AreEqual(1, array[1], string.Format("One lost at {0}", k));
            }

            for (int k = 0; k < 1000; k++)
                Assert.AreEqual(k, array[(ulong)k]);
        }

        [TestMethod]
        public void SetOneThousandSparseElements()
        {
            SparseArray<int> array = new SparseArray<int>(10);

            for (int k = 0; k < 1000; k++)
            {
                array[(ulong)(k*1000)] = k;
                Assert.AreEqual(k, array[(ulong)(k*1000)]);
            }

            for (int k = 0; k < 1000; k++)
                Assert.AreEqual(k, array[(ulong)(k*1000)]);
        }
    }
}
