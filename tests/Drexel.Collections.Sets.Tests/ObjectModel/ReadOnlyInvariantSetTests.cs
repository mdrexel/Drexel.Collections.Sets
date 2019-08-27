using System;
using System.Collections.Generic;
using Drexel.Collections.ObjectModel;
using Drexel.Collections.Tests.Shared.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drexel.Collections.Tests.ObjectModel
{
    [TestClass]
    public class ReadOnlyInvariantSetTests
    {
        [TestMethod]
        public void ReadOnlyInvariantSet_Ctor_Succeeds()
        {
            int[] methodsCalled = new int[9];

            ReadOnlyInvariantSet<int> set = new ReadOnlyInvariantSet<int>(
                new MockSet<int>(
                    addDelegate: null,
                    clearDelegate: null,
                    containsDelegate: x => { methodsCalled[0]++; return true; },
                    copyToDelegate: null,
                    countDelegate: () => { methodsCalled[1]++; return 0; },
                    equalsDelegate: null,
                    exceptWithDelegate: null,
                    getEnumeratorDelegate: () => { methodsCalled[2]++; return new List<int>().GetEnumerator(); },
                    getHashCodeDelegate: null,
                    intersectWithDelegate: null,
                    isProperSubsetOfDelegate: x => { methodsCalled[3]++; return true; },
                    isProperSupersetOfDelegate: x => { methodsCalled[4]++; return true; },
                    isReadOnlyDelegate: null,
                    isSubsetOfDelegate: x => { methodsCalled[5]++; return true; },
                    isSupersetOfDelegate: x => { methodsCalled[6]++; return true; },
                    overlapsDelegate: x => { methodsCalled[7]++; return true; },
                    removeDelegate: null,
                    setEqualsDelegate: x => { methodsCalled[8]++; return true; },
                    symmetricExceptWithDelegate: null,
                    toStringDelegate: null,
                    unionWithDelegate: null));

            set.Contains(12);
            _ = set.Count;
            set.GetEnumerator();
            set.IsProperSubsetOf(Array.Empty<int>());
            set.IsProperSupersetOf(Array.Empty<int>());
            set.IsSubsetOf(Array.Empty<int>());
            set.IsSupersetOf(Array.Empty<int>());
            set.Overlaps(Array.Empty<int>());
            set.SetEquals(Array.Empty<int>());

            foreach (int timesCalled in methodsCalled)
            {
                Assert.AreEqual(1, timesCalled);
            }
        }
    }
}
