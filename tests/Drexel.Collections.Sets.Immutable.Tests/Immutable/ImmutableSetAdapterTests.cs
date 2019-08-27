using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Drexel.Collections.Immutable.Tests.Shared.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drexel.Collections.Immutable.Tests.Immutable
{
    [TestClass]
    public class ImmutableSetAdapterTests
    {
        [TestMethod]
        public void ImmutableSetAdapter_Ctor_Succeeds()
        {
            const int NumberOfMethods = 17;

            int[] methodsCalled = new int[NumberOfMethods];
            ImmutableHashSet<int> realSet = ImmutableHashSet<int>.Empty;

            System.Collections.Immutable.IImmutableSet<int> backingSet =
                new MockSystemImmutableSet<int>(
                    addDelegate: x => { methodsCalled[0]++; return realSet.Add(x); },
                    clearDelegate: () => { methodsCalled[1]++; return realSet.Clear(); },
                    containsDelegate: x => { methodsCalled[2]++; return realSet.Contains(x); },
                    countDelegate: () => { methodsCalled[3]++; return realSet.Count; },
                    equalsDelegate: null,
                    exceptDelegate: x => { methodsCalled[4]++; return realSet.Except(x); },
                    getEnumeratorDelegate: () => { methodsCalled[5]++; return realSet.GetEnumerator(); },
                    getHashCodeDelegate: null,
                    intersectDelegate: x => { methodsCalled[6]++; return realSet.Intersect(x); },
                    isProperSubsetOfDelegate: x => { methodsCalled[7]++; return realSet.IsProperSubsetOf(x); },
                    isProperSupersetOfDelegate: x => { methodsCalled[8]++; return realSet.IsProperSupersetOf(x); },
                    isSubsetOfDelegate: x => { methodsCalled[9]++; return realSet.IsSubsetOf(x); },
                    isSupersetOfDelegate: x => { methodsCalled[10]++; return realSet.IsSupersetOf(x); },
                    overlapsDelegate: x => { methodsCalled[11]++; return realSet.Overlaps(x); },
                    removeDelegate: x => { methodsCalled[12]++; return realSet.Remove(x); },
                    setEqualsDelegate: x => { methodsCalled[13]++; return realSet.SetEquals(x); },
                    symmetricExceptDelegate: x => { methodsCalled[14]++; return realSet.SymmetricExcept(x); },
                    toStringDelegate: null,
                    tryGetValueDelegate: (int x, out int y) => { methodsCalled[15]++; return realSet.TryGetValue(x, out y); },
                    unionDelegate: x => { methodsCalled[16]++; return realSet.Union(x); });

            ImmutableSetAdapter<int> set = new ImmutableSetAdapter<int>(backingSet);

            set.Add(12);
            set.Clear();
            set.Contains(12);
            _ = set.Count;
            set.Except(Array.Empty<int>());
            set.GetEnumerator();
            set.Intersect(Array.Empty<int>());
            set.IsProperSubsetOf(Array.Empty<int>());
            set.IsProperSupersetOf(Array.Empty<int>());
            set.IsSubsetOf(Array.Empty<int>());
            set.IsSupersetOf(Array.Empty<int>());
            set.Overlaps(Array.Empty<int>());
            set.Remove(12);
            set.SetEquals(Array.Empty<int>());
            set.SymmetricExcept(Array.Empty<int>());
            set.TryGetValue(12, out _);
            set.Union(Array.Empty<int>());

            for (int counter = 0; counter < NumberOfMethods; counter++)
            {
                Assert.AreEqual(1, methodsCalled[counter]);
            }
        }

        [TestMethod]
        public void ImmutableSetAdapter_Add_ElementWhichIsNotAlreadyInSet_ReturnsNewSet()
        {
            ImmutableSetAdapter<int> originalSet = new ImmutableSetAdapter<int>(
                ImmutableHashSet.Create<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10));

            IImmutableSet<int> newSet = originalSet.Add(11);

            Assert.AreNotSame(originalSet, newSet);
        }

        [TestMethod]
        public void ImmutableSetAdapter_Add_ElementWhichIsAlreadyInSet_ReturnsSameSet()
        {
            ImmutableSetAdapter<int> originalSet = new ImmutableSetAdapter<int>(
                ImmutableHashSet.Create<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10));

            IImmutableSet<int> newSet = originalSet.Add(8);

            Assert.AreSame(originalSet, newSet);
        }

        [TestMethod]
        public void ImmutableSetAdapter_Except_ElementWhichIsInSet_ReturnsNewSet()
        {
            int[] initialValues = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] valuesToRemove = new int[] { 6, 7, 8 };
            ImmutableSetAdapter<int> originalSet = new ImmutableSetAdapter<int>(
                ImmutableHashSet.Create<int>(initialValues));

            IImmutableSet<int> newSet = originalSet.Except(valuesToRemove);

            Assert.AreNotSame(originalSet, newSet);
            Assert.AreEqual(initialValues.Length - valuesToRemove.Length, newSet.Count);
        }

        [TestMethod]
        public void ImmutableSetAdapter_Except_ElementWhichIsNotInSet_ReturnsSameSet()
        {
            int[] initialValues = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] valuesToRemove = new int[] { 11, 12, 13 };
            ImmutableSetAdapter<int> originalSet = new ImmutableSetAdapter<int>(
                ImmutableHashSet.Create<int>(initialValues));

            IImmutableSet<int> newSet = originalSet.Except(valuesToRemove);

            Assert.AreSame(originalSet, newSet);
        }

        [TestMethod]
        public void ImmutableSetAdapter_Remove_ElementWhichIsInSet_ReturnsNewSet()
        {
            ImmutableSetAdapter<int> originalSet = new ImmutableSetAdapter<int>(
                ImmutableHashSet.Create<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10));

            IImmutableSet<int> newSet = originalSet.Remove(5);

            Assert.AreNotSame(originalSet, newSet);
            Assert.AreEqual(originalSet.Count - 1, newSet.Count);
        }

        [TestMethod]
        public void ImmutableSetAdapter_Remove_ElementWhichIsNotInSet_ReturnsSameSet()
        {
            ImmutableSetAdapter<int> originalSet = new ImmutableSetAdapter<int>(
                ImmutableHashSet.Create<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10));

            IImmutableSet<int> newSet = originalSet.Remove(15);

            Assert.AreSame(originalSet, newSet);
        }

        [TestMethod]
        public void ImmutableSetAdapter_Union_ElementWhichIsAlreadyInSet_ReturnsSameSet()
        {
            ImmutableSetAdapter<int> originalSet = new ImmutableSetAdapter<int>(
                ImmutableHashSet.Create<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10));

            IImmutableSet<int> newSet = originalSet.Union(new int[] { 5, 6, 7, 8 });

            Assert.AreSame(originalSet, newSet);
        }

        [TestMethod]
        public void ImmutableSetAdapter_Union_ElementWhichIsNotAlreadyInSet_ReturnsNewSet()
        {
            int[] valuesToAdd = new int[] { 11, 12, 13, 14 };
            ImmutableSetAdapter<int> originalSet = new ImmutableSetAdapter<int>(
                ImmutableHashSet.Create<int>(1, 2, 3, 4, 5, 6, 7, 9, 10));

            IImmutableSet<int> newSet = originalSet.Union(valuesToAdd);

            Assert.AreNotSame(originalSet, newSet);
            Assert.AreEqual(originalSet.Count + valuesToAdd.Length, newSet.Count);
        }
    }
}
