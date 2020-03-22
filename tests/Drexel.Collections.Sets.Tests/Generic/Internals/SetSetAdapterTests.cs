using System;
using System.Collections.Generic;
using Drexel.Collections.Generic.Internals;
using Drexel.Collections.Tests.Shared.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drexel.Collections.Tests.Generic.Internals
{
    [TestClass]
    public class SetSetAdapterTests
    {
        [TestMethod]
        public void SetSetAdapter_Ctor_Succeeds()
        {
            const int NumberOfMethods = 21;

            int[] methodsCalled = new int[NumberOfMethods];
            bool[] expected =
                new bool[NumberOfMethods]
                {
                    true,
                    true,
                    true,
                    true,
                    true,
                    false,
                    true,
                    true,
                    false,
                    true,
                    true,
                    true,
                    true,
                    true,
                    true,
                    true,
                    true,
                    true,
                    true,
                    false,
                    true
                };
            System.Collections.Generic.ISet<int> backingSet =
                new MockSystemSet<int>(
                    x => { methodsCalled[0]++; return true; },
                    () => methodsCalled[1]++,
                    x => { methodsCalled[2]++; return true; },
                    (x, y) => methodsCalled[3]++,
                    () => { methodsCalled[4]++; return 0; },
                    x => { methodsCalled[5]++; return true; },
                    x => { methodsCalled[6]++; },
                    () => { methodsCalled[7]++; return new List<int>().GetEnumerator(); },
                    () => { methodsCalled[8]++; return 0; },
                    x => methodsCalled[9]++,
                    x => { methodsCalled[10]++; return true; },
                    x => { methodsCalled[11]++; return true; },
                    () => { methodsCalled[12]++; return true; },
                    x => { methodsCalled[13]++; return true; },
                    x => { methodsCalled[14]++; return true; },
                    x => { methodsCalled[15]++; return true; },
                    x => { methodsCalled[16]++; return true; },
                    x => { methodsCalled[17]++; return true; },
                    x => methodsCalled[18]++,
                    () => { methodsCalled[19]++; return string.Empty; },
                    x => methodsCalled[20]++);

#pragma warning disable IDE0028 // Simplify collection initialization. Intentionally calling .Add separately for clarity
            SetSetAdapter<int> set = new SetSetAdapter<int>(backingSet);
#pragma warning restore IDE0028 // Simplify collection initialization

            set.Add(12);
            set.Clear();
            set.Contains(12);
            set.CopyTo(new int[12], 0);
            _ = set.Count;
            set.ExceptWith(Array.Empty<int>());
            set.GetEnumerator();
            set.IntersectWith(Array.Empty<int>());
            set.IsProperSubsetOf(Array.Empty<int>());
            set.IsProperSupersetOf(Array.Empty<int>());
            _ = set.IsReadOnly;
            set.IsSubsetOf(Array.Empty<int>());
            set.IsSupersetOf(Array.Empty<int>());
            set.Overlaps(Array.Empty<int>());
            set.Remove(12);
            set.SetEquals(Array.Empty<int>());
            set.SymmetricExceptWith(Array.Empty<int>());
            set.UnionWith(Array.Empty<int>());

            for (int counter = 0; counter < NumberOfMethods; counter++)
            {
                Assert.AreEqual(
                    expected[counter] ? 1 : 0,
                    methodsCalled[counter]);
            }
        }
    }
}
