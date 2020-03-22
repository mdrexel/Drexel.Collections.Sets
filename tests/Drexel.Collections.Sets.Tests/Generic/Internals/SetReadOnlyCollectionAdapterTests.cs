using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                    new int[]
                    {
                        1,
                        2,
                        3,
                        4,
                        5
                    },
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
                    new int[]
                    {
                        1,
                        2,
                        3,
                        4,
                        5
                    },
                    comparer);

            Assert.IsFalse(adapter.Contains(6));
        }
    }
}
