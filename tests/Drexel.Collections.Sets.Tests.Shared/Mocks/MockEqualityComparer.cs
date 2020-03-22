using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drexel.Collections.Tests.Shared.Mocks
{
    public class MockEqualityComparer<T> : IEqualityComparer<T>
    {
        public MockEqualityComparer(
            Func<T, T, bool>? equalsFunc = null,
            Func<T, int>? getHashCodeFunc = null)
        {
            this.EqualsFunc = equalsFunc ?? ((x, y) => throw new InternalTestFailureException());
            this.GetHashCodeFunc = getHashCodeFunc ?? (x => throw new InternalTestFailureException());
        }

        public Func<T, T, bool> EqualsFunc { get; set; }

        public Func<T, int> GetHashCodeFunc { get; set; }

        public bool Equals(T x, T y) => this.EqualsFunc.Invoke(x, y);

        public int GetHashCode(T obj) => this.GetHashCodeFunc.Invoke(obj);
    }
}
