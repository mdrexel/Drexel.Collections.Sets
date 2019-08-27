using System;
using System.Collections;
using System.Collections.Generic;
using Drexel.Collections.Generic;

namespace Drexel.Collections.Tests.Shared.Mocks
{
    public class MockReadOnlySet<T> : IReadOnlySet<T>
    {
        public MockReadOnlySet(IReadOnlySet<T> set)
            : this(
                  () => set.Count,
                  set.Equals,
                  set.GetEnumerator,
                  set.GetHashCode,
                  set.ToString)
        {
        }

        public MockReadOnlySet(
            Func<int>? countDelegate = null,
            Func<object, bool>? equalsDelegate = null,
            Func<IEnumerator<T>>? getEnumeratorDelegate = null,
            Func<int>? getHashCodeDelegate = null,
            Func<string>? toStringDelegate = null)
        {
            this.CountDelegate = countDelegate ?? (() => throw new NotImplementedException());
            this.EqualsDelegate = equalsDelegate ?? ((x) => throw new NotImplementedException());
            this.GetEnumeratorDelegate = getEnumeratorDelegate ?? (() => throw new NotImplementedException());
            this.GetHashCodeDelegate = getHashCodeDelegate ?? (() => throw new NotImplementedException());
            this.ToStringDelegate = toStringDelegate ?? (() => throw new NotImplementedException());
        }

        public Func<int> CountDelegate { get; set; }

        public Func<object, bool> EqualsDelegate { get; set; }

        public Func<IEnumerator<T>> GetEnumeratorDelegate { get; set; }

        public Func<int> GetHashCodeDelegate { get; set; }

        public Func<string> ToStringDelegate { get; set; }

        public int Count => this.CountDelegate.Invoke();

        public override bool Equals(object obj) => this.EqualsDelegate.Invoke(obj);

        public IEnumerator<T> GetEnumerator() => this.GetEnumeratorDelegate.Invoke();

        public override int GetHashCode() => this.GetHashCodeDelegate.Invoke();

        public override string ToString() => this.ToStringDelegate.Invoke();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
