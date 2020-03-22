using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Drexel.Collections.Generic.Internals;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drexel.Collections.Tests.Generic.Internals
{
    [TestClass]
    public class SetCollectionAdapterTests
    {
        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void SetCollectionAdapter_Ctor_Succeeds(bool shouldBeReadOnly)
        {
            List<string> content = new List<string>() { "foo", "bar", "baz" };
            ICollection<string> collection =
                shouldBeReadOnly
                    ? new ReadOnlyCollection<string>(content)
                    : (ICollection<string>)content;

            SetCollectionAdapter<string> adapter =
                new SetCollectionAdapter<string>(collection);

            Assert.IsNotNull(adapter);
            Assert.AreEqual(shouldBeReadOnly, adapter.IsReadOnly);
        }

        [TestMethod]
        public void SetCollectionAdapter_Ctor_CollectionIsNull_ThrowsArgumentNull()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.ThrowsException<ArgumentNullException>(
                () => new SetCollectionAdapter<string>(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        [TestMethod]
        public void SetCollectionAdapter_Add_ElementNotPresent_ReturnsTrue()
        {
            List<int> backingList = new List<int>() { 12, 13, 14 };
            SetCollectionAdapter<int> adapter = new SetCollectionAdapter<int>(backingList);

            Assert.IsTrue(adapter.Add(7));
            CollectionAssert.Contains(backingList, 7);
        }

        [TestMethod]
        public void SetCollectionAdapter_Add_ElementPresent_ReturnsFalse()
        {
            List<int> backingList = new List<int>() { 12, 13, 14 };
            SetCollectionAdapter<int> adapter = new SetCollectionAdapter<int>(backingList);

            Assert.IsFalse(adapter.Add(13));
            Assert.AreEqual(3, backingList.Count);
        }

        [TestMethod]
        public void SetCollectionAdapter_Add_IsReadOnly_ThrowsNotSupported()
        {
            ICollection<int> backingList = new ReadOnlyCollection<int>(new List<int>() { 12, 13, 14 });
            SetCollectionAdapter<int> adapter = new SetCollectionAdapter<int>(backingList);

            NotSupportedException e = Assert.ThrowsException<NotSupportedException>(
                () => adapter.Add(7));
            Assert.AreEqual(
                ExceptionMessages.CollectionIsReadOnly,
                e.Message);
        }

        [TestMethod]
        public void SetCollectionAdapter_Contains_ElementPresent_ReturnsTrue()
        {
            List<int> backingList = new List<int>() { 12, 13, 14 };
            SetCollectionAdapter<int> adapter = new SetCollectionAdapter<int>(backingList);

            Assert.IsTrue(adapter.Contains(13));
        }

        [TestMethod]
        public void SetCollectionAdapter_Contains_ElementNotPresent_ReturnsFalse()
        {
            List<int> backingList = new List<int>() { 12, 13, 14 };
            SetCollectionAdapter<int> adapter = new SetCollectionAdapter<int>(backingList);

            Assert.IsFalse(adapter.Contains(7));
        }

        [TestMethod]
        public void SetCollectionAdapter_ExceptWith_Null_ThrowsArgumentNull()
        {
            List<int> backingList = new List<int>() { 12, 13, 14 };
            SetCollectionAdapter<int> adapter = new SetCollectionAdapter<int>(backingList);

            Assert.ThrowsException<ArgumentNullException>(
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                () => adapter.ExceptWith(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        [TestMethod]
        public void SetCollectionAdapter_ExceptWith_IsReadOnly_ThrowsNotSupported()
        {
            ICollection<int> backingList = new ReadOnlyCollection<int>(new List<int>() { 12, 13, 14 });
            SetCollectionAdapter<int> adapter = new SetCollectionAdapter<int>(backingList);

            NotSupportedException e = Assert.ThrowsException<NotSupportedException>(
                () => adapter.ExceptWith(new int[] { 7, 12 }));
            Assert.AreEqual(
                ExceptionMessages.CollectionIsReadOnly,
                e.Message);
        }

        [TestMethod]
        public void SetCollectionAdapter_ExceptWith_RemovesContainedElements()
        {
            List<int> backingList = new List<int>() { 12, 13, 14 };
            SetCollectionAdapter<int> adapter = new SetCollectionAdapter<int>(backingList);

            adapter.ExceptWith(new int[] { 7, 13, 28, 12 });

            Assert.AreEqual(1, backingList.Count);
            Assert.AreEqual(14, backingList[0]);
        }

        [TestMethod]
        public void SetCollectionAdapter_IntersectWith_Null_ThrowsArgumentNull()
        {
            List<int> backingList = new List<int>() { 12, 13, 14 };
            SetCollectionAdapter<int> adapter = new SetCollectionAdapter<int>(backingList);

            Assert.ThrowsException<ArgumentNullException>(
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                () => adapter.IntersectWith(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        [TestMethod]
        public void SetCollectionAdapter_IntersectWith_IsReadOnly_ThrowsNotSupported()
        {
            ICollection<int> backingList = new ReadOnlyCollection<int>(new List<int>() { 12, 13, 14 });
            SetCollectionAdapter<int> adapter = new SetCollectionAdapter<int>(backingList);

            NotSupportedException e = Assert.ThrowsException<NotSupportedException>(
                () => adapter.IntersectWith(new int[] { 7, 12 }));
            Assert.AreEqual(
                ExceptionMessages.CollectionIsReadOnly,
                e.Message);
        }

        [TestMethod]
        public void SetCollectionAdapter_IntersectWith_RemovesElementsNotContainedByOther()
        {
            List<int> backingList = new List<int>() { 12, 13, 14, 15, 16 };
            SetCollectionAdapter<int> adapter = new SetCollectionAdapter<int>(backingList);

            adapter.IntersectWith(new int[] { 7, 16, 94, 14 });

            CollectionAssert.AreEquivalent(new int[] { 14, 16 }, backingList);
        }
    }
}
