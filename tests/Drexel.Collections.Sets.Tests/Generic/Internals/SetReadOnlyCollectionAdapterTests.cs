using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Drexel.Collections.Generic.Internals;
using Drexel.Collections.Tests.Shared.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drexel.Collections.Tests.Generic.Internals
{
    [TestClass]
    public class SetReadOnlyCollectionAdapterTests
    {
        [TestMethod]
        public void SetReadOnlyCollectionAdapter_Ctor_Succeeds()
        {
            SetReadOnlyCollectionAdapter<string> adapter =
                new SetReadOnlyCollectionAdapter<string>(Array.Empty<string>());

            Assert.IsNotNull(adapter);
            Assert.IsTrue(adapter.IsReadOnly);
        }

        [TestMethod]
        public void SetReadOnlyCollectionAdapter_Ctor_CollectionIsNull_ThrowsArgumentNull()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.ThrowsException<ArgumentNullException>(
                () => new SetReadOnlyCollectionAdapter<string>(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        [TestMethod]
        public void SetReadOnlyCollectionAdapter_Add_ThrowsNotSupported()
        {
            SetReadOnlyCollectionAdapter<string> adapter =
                new SetReadOnlyCollectionAdapter<string>(Array.Empty<string>());
            NotSupportedException e = Assert.ThrowsException<NotSupportedException>(
                () => adapter.Add("foo"));
            Assert.AreEqual(
                ExceptionMessages.CollectionIsReadOnly,
                e.Message);
        }

        [TestMethod]
        public void SetReadOnlyCollectionAdapter_Clear_ThrowsNotSupported()
        {
            SetReadOnlyCollectionAdapter<string> adapter =
                new SetReadOnlyCollectionAdapter<string>(Array.Empty<string>());
            NotSupportedException e = Assert.ThrowsException<NotSupportedException>(
                () => adapter.Clear());
            Assert.AreEqual(
                ExceptionMessages.CollectionIsReadOnly,
                e.Message);
        }

        [TestMethod]
        public void SetReadOnlyCollectionAdapter_Contains_WhenMatchingItemExists_Succeeds()
        {
            IEqualityComparer<int> comparer = new MockEqualityComparer<int>(
                (x, y) => x == y,
                x => x.GetHashCode());

            SetReadOnlyCollectionAdapter<int> adapter =
                new SetReadOnlyCollectionAdapter<int>(
                    new int[] { 1, 2, 3, 4, 5 },
                    comparer);

            Assert.IsTrue(adapter.Contains(4));
        }

        [TestMethod]
        public void SetReadOnlyCollectionAdapter_Contains_WhenNoMatchingItemExists_Succeeds()
        {
            IEqualityComparer<int> comparer = new MockEqualityComparer<int>(
                (x, y) => x == y,
                x => x.GetHashCode());

            SetReadOnlyCollectionAdapter<int> adapter =
                new SetReadOnlyCollectionAdapter<int>(
                    new int[] { 1, 2, 3, 4, 5 },
                    comparer);

            Assert.IsFalse(adapter.Contains(6));
        }

        [TestMethod]
        public void SetReadOnlyCollectionAdapter_Count_Succeeds()
        {
            int[] array = new int[43];
            SetReadOnlyCollectionAdapter<int> adapter = new SetReadOnlyCollectionAdapter<int>(array);

            Assert.AreEqual(array.Length, adapter.Count);
        }

        [TestMethod]
        public void SetReadOnlyCollectionAdapter_CopyTo_Succeeds()
        {
            int[] array = Enumerable.Range(1, 7).ToArray();
            int[] destination = Enumerable.Repeat(-1, 12).ToArray();

            SetReadOnlyCollectionAdapter<int> adapter = new SetReadOnlyCollectionAdapter<int>(array);
            adapter.CopyTo(destination, 2);

            for (int counter = 0; counter < 2; counter++)
            {
                Assert.AreEqual(-1, destination[counter]);
            }

            for (int counter = 2; counter < 9; counter++)
            {
                Assert.AreEqual(array[counter - 2], destination[counter]);
            }

            for (int counter = 9; counter < destination.Length; counter++)
            {
                Assert.AreEqual(-1, destination[counter]);
            }
        }

        [TestMethod]
        public void SetReadOnlyCollectionAdapter_CopyTo_IndexLessThanZero_ThrowsArgumentOutOfRange()
        {
            SetReadOnlyCollectionAdapter<int> adapter =
                new SetReadOnlyCollectionAdapter<int>(new int[5]);
            ArgumentOutOfRangeException e = Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => adapter.CopyTo(new int[5], -1));
            StringAssert.StartsWith(
                e.Message,
                ExceptionMessages.ArrayIndexBelowLowerBound);
        }

        [DataTestMethod]
        [DataRow(6, 4, 0)]
        [DataRow(6, 5, 1)]
        [DataRow(6, 6, 1)]
        [DataRow(12, 7, 4)]
        public void SetReadOnlyCollectionAdapter_CopyTo_DestinationArrayTooSmall_ThrowsArgumentException(
            int sourceArraySize,
            int destinationArraySize,
            int destinationStartIndexInclusive)
        {
            SetReadOnlyCollectionAdapter<int> adapter =
                new SetReadOnlyCollectionAdapter<int>(new int[sourceArraySize]);
            ArgumentException e = Assert.ThrowsException<ArgumentException>(
                () => adapter.CopyTo(new int[destinationArraySize], destinationStartIndexInclusive));
            StringAssert.StartsWith(
                e.Message,
                ExceptionMessages.DestinationArrayNotLongEnough);
        }

        [TestMethod]
        public void SetReadOnlyCollectionAdapter_Equals_WhenEqual_Succeeds()
        {
            SetReadOnlyCollectionAdapter<int> adapter = new SetReadOnlyCollectionAdapter<int>(Array.Empty<int>());

            Assert.IsTrue(adapter.Equals(adapter));
            Assert.IsTrue(adapter.Equals((object)adapter));
        }

        [TestMethod]
        public void SetReadOnlyCollectionAdapter_Equals_WhenNotEqual_Succeeds()
        {
            SetReadOnlyCollectionAdapter<int> left = new SetReadOnlyCollectionAdapter<int>(Array.Empty<int>());
            SetReadOnlyCollectionAdapter<int> right = new SetReadOnlyCollectionAdapter<int>(Array.Empty<int>());

            Assert.IsFalse(left.Equals(right));
            Assert.IsFalse(right.Equals(left));
            Assert.IsFalse(((object)left).Equals(right));
            Assert.IsFalse(left.Equals((object)right));
        }

        [TestMethod]
        public void SetReadOnlyCollectionAdapter_Equals_WhenUnderlyingCollectionEquals_Succeeds()
        {
            IReadOnlyCollection<int> collection = new List<int>();
            SetReadOnlyCollectionAdapter<int> adapter = new SetReadOnlyCollectionAdapter<int>(collection);

            Assert.IsTrue(adapter.Equals(collection));
            Assert.IsTrue(adapter.Equals((object)collection));
        }

        [TestMethod]
        public void SetReadOnlyCollectionAdapter_ExceptWith_ThrowsNotSupported()
        {
            SetReadOnlyCollectionAdapter<int> adapter =
                new SetReadOnlyCollectionAdapter<int>(Array.Empty<int>());
            NotSupportedException e = Assert.ThrowsException<NotSupportedException>(
                () => adapter.ExceptWith(new int[] { 1, 2, 3 }));
            Assert.AreEqual(
                ExceptionMessages.CollectionIsReadOnly,
                e.Message);
        }

        [TestMethod]
        public void SetReadOnlyCollectionAdapter_IntersectWith_ThrowsNotSupported()
        {
            SetReadOnlyCollectionAdapter<int> adapter =
                new SetReadOnlyCollectionAdapter<int>(Array.Empty<int>());
            NotSupportedException e = Assert.ThrowsException<NotSupportedException>(
                () => adapter.IntersectWith(new int[] { 1, 2, 3 }));
            Assert.AreEqual(
                ExceptionMessages.CollectionIsReadOnly,
                e.Message);
        }

        [TestMethod]
        public void SetReadOnlyCollectionAdapter_Overlaps_WhenNull_ThrowsArgumentNull()
        {
            SetReadOnlyCollectionAdapter<int> adapter =
                new SetReadOnlyCollectionAdapter<int>(Array.Empty<int>());
            Assert.ThrowsException<ArgumentNullException>(
                () => adapter.Overlaps(null));
        }

        [TestMethod]
        public void SetReadOnlyCollectionAdapter_Overlaps_AdapterIsEmpty_Succeeds()
        {
            SetReadOnlyCollectionAdapter<int> adapter =
                new SetReadOnlyCollectionAdapter<int>(Array.Empty<int>());
            Assert.IsTrue(adapter.Overlaps(new int[] { 1, 2, 3 }));
        }

        [TestMethod]
        public void SetReadOnlyCollectionAdapter_Remove_ThrowsNotSupported()
        {
            SetReadOnlyCollectionAdapter<string> adapter =
                new SetReadOnlyCollectionAdapter<string>(Array.Empty<string>());
            NotSupportedException e = Assert.ThrowsException<NotSupportedException>(
                () => adapter.Remove("Foo"));
            Assert.AreEqual(
                ExceptionMessages.CollectionIsReadOnly,
                e.Message);
        }

        [TestMethod]
        public void SetReadOnlyCollectionAdapter_SymmetricExceptWith_ThrowsNotSupported()
        {
            SetReadOnlyCollectionAdapter<string> adapter =
                new SetReadOnlyCollectionAdapter<string>(Array.Empty<string>());
            NotSupportedException e = Assert.ThrowsException<NotSupportedException>(
                () => adapter.SymmetricExceptWith(new string[] { "Foo" }));
            Assert.AreEqual(
                ExceptionMessages.CollectionIsReadOnly,
                e.Message);
        }

        [TestMethod]
        public void SetReadOnlyCollectionAdapter_UnionWith_ThrowsNotSupported()
        {
            SetReadOnlyCollectionAdapter<string> adapter =
                new SetReadOnlyCollectionAdapter<string>(Array.Empty<string>());
            NotSupportedException e = Assert.ThrowsException<NotSupportedException>(
                () => adapter.UnionWith(new string[] { "Foo" }));
            Assert.AreEqual(
                ExceptionMessages.CollectionIsReadOnly,
                e.Message);
        }
    }
}
