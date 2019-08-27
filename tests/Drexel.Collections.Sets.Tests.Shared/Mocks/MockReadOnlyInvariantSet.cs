using System;
using System.Collections;
using System.Collections.Generic;
using Drexel.Collections.Generic;

namespace Drexel.Collections.Tests.Shared.Mocks
{
    public class MockReadOnlyInvariantSet<T> : IReadOnlyInvariantSet<T>
    {
        public MockReadOnlyInvariantSet(IReadOnlyInvariantSet<T> set)
            : this(
                  set.Contains,
                  () => set.Count,
                  set.Equals,
                  set.GetEnumerator,
                  set.GetHashCode,
                  set.IsProperSubsetOf,
                  set.IsProperSupersetOf,
                  set.IsSubsetOf,
                  set.IsSupersetOf,
                  set.Overlaps,
                  set.SetEquals,
                  set.ToString)
        {
        }

        public MockReadOnlyInvariantSet(
            Func<T, bool>? containsDelegate = null,
            Func<int>? countDelegate = null,
            Func<object, bool>? equalsDelegate = null,
            Func<IEnumerator<T>>? getEnumeratorDelegate = null,
            Func<int>? getHashCodeDelegate = null,
            Func<IEnumerable<T>, bool>? isProperSubsetOfDelegate = null,
            Func<IEnumerable<T>, bool>? isProperSupersetOfDelegate = null,
            Func<IEnumerable<T>, bool>? isSubsetOfDelegate = null,
            Func<IEnumerable<T>, bool>? isSupersetOfDelegate = null,
            Func<IEnumerable<T>, bool>? overlapsDelegate = null,
            Func<IEnumerable<T>, bool>? setEqualsDelegate = null,
            Func<string>? toStringDelegate = null)
        {
            this.ContainsDelegate = containsDelegate ?? ((x) => throw new NotImplementedException());
            this.CountDelegate = countDelegate ?? (() => throw new NotImplementedException());
            this.EqualsDelegate = equalsDelegate ?? ((x) => throw new NotImplementedException());
            this.GetEnumeratorDelegate = getEnumeratorDelegate ?? (() => throw new NotImplementedException());
            this.GetHashCodeDelegate = getHashCodeDelegate ?? (() => throw new NotImplementedException());
            this.IsProperSubsetOfDelegate = isProperSubsetOfDelegate ?? ((x) => throw new NotImplementedException());
            this.IsProperSupersetOfDelegate = isProperSupersetOfDelegate ?? ((x) => throw new NotImplementedException());
            this.IsSubsetOfDelegate = isSubsetOfDelegate ?? ((x) => throw new NotImplementedException());
            this.IsSupersetOfDelegate = isSupersetOfDelegate ?? ((x) => throw new NotImplementedException());
            this.OverlapsDelegate = overlapsDelegate ?? ((x) => throw new NotImplementedException());
            this.SetEqualsDelegate = setEqualsDelegate ?? ((x) => throw new NotImplementedException());
            this.ToStringDelegate = toStringDelegate ?? (() => throw new NotImplementedException());
        }

        public Func<T, bool> ContainsDelegate { get; set; }

        public Func<int> CountDelegate { get; set; }

        public Func<object, bool> EqualsDelegate { get; set; }

        public Func<IEnumerator<T>> GetEnumeratorDelegate { get; set; }

        public Func<int> GetHashCodeDelegate { get; set; }

        public Func<IEnumerable<T>, bool> IsProperSubsetOfDelegate { get; set; }

        public Func<IEnumerable<T>, bool> IsProperSupersetOfDelegate { get; set; }

        public Func<IEnumerable<T>, bool> IsSubsetOfDelegate { get; set; }

        public Func<IEnumerable<T>, bool> IsSupersetOfDelegate { get; set; }

        public Func<IEnumerable<T>, bool> OverlapsDelegate { get; set; }

        public Func<IEnumerable<T>, bool> SetEqualsDelegate { get; set; }

        public Func<string> ToStringDelegate { get; set; }

        public int Count => this.CountDelegate.Invoke();

        public bool Contains(T item) => this.ContainsDelegate.Invoke(item);

        public override bool Equals(object obj) => this.EqualsDelegate.Invoke(obj);

        public IEnumerator<T> GetEnumerator() => this.GetEnumeratorDelegate.Invoke();

        public override int GetHashCode() => this.GetHashCodeDelegate.Invoke();

        public bool IsProperSubsetOf(IEnumerable<T> other) => this.IsProperSubsetOfDelegate.Invoke(other);

        public bool IsProperSupersetOf(IEnumerable<T> other) => this.IsProperSupersetOfDelegate.Invoke(other);

        public bool IsSubsetOf(IEnumerable<T> other) => this.IsSubsetOfDelegate.Invoke(other);

        public bool IsSupersetOf(IEnumerable<T> other) => this.IsSupersetOfDelegate.Invoke(other);

        public bool Overlaps(IEnumerable<T> other) => this.OverlapsDelegate.Invoke(other);

        public bool SetEquals(IEnumerable<T> other) => this.SetEqualsDelegate.Invoke(other);

        public override string ToString() => this.ToStringDelegate.Invoke();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
