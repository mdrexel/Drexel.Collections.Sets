using System;
using System.Collections;
using System.Collections.Generic;

namespace Drexel.Collections.Immutable.Tests.Shared.Mocks
{
    public class MockSystemImmutableSet<T> : System.Collections.Immutable.IImmutableSet<T>
    {
        public MockSystemImmutableSet()
            : this(
                  null,
                  null,
                  null,
                  null,
                  null,
                  null,
                  null,
                  null,
                  null,
                  null,
                  null,
                  null,
                  null,
                  null,
                  null,
                  null,
                  null,
                  null,
                  null,
                  null)
        {
        }

        public MockSystemImmutableSet(System.Collections.Immutable.IImmutableSet<T> set)
            : this(
                  set.Add,
                  set.Clear,
                  set.Contains,
                  () => set.Count,
                  set.Equals,
                  set.Except,
                  set.GetEnumerator,
                  set.GetHashCode,
                  set.Intersect,
                  set.IsProperSubsetOf,
                  set.IsProperSupersetOf,
                  set.IsSubsetOf,
                  set.IsSupersetOf,
                  set.Overlaps,
                  set.Remove,
                  set.SetEquals,
                  set.SymmetricExcept,
                  set.ToString,
                  set.TryGetValue,
                  set.Union)
        {
        }

        public MockSystemImmutableSet(
            Func<T, System.Collections.Immutable.IImmutableSet<T>>? addDelegate,
            Func<System.Collections.Immutable.IImmutableSet<T>>? clearDelegate,
            Func<T, bool>? containsDelegate,
            Func<int>? countDelegate,
            Func<object, bool>? equalsDelegate,
            Func<IEnumerable<T>, System.Collections.Immutable.IImmutableSet<T>>? exceptDelegate,
            Func<IEnumerator<T>>? getEnumeratorDelegate,
            Func<int>? getHashCodeDelegate,
            Func<IEnumerable<T>, System.Collections.Immutable.IImmutableSet<T>>? intersectDelegate,
            Func<IEnumerable<T>, bool>? isProperSubsetOfDelegate,
            Func<IEnumerable<T>, bool>? isProperSupersetOfDelegate,
            Func<IEnumerable<T>, bool>? isSubsetOfDelegate,
            Func<IEnumerable<T>, bool>? isSupersetOfDelegate,
            Func<IEnumerable<T>, bool>? overlapsDelegate,
            Func<T, System.Collections.Immutable.IImmutableSet<T>>? removeDelegate,
            Func<IEnumerable<T>, bool>? setEqualsDelegate,
            Func<IEnumerable<T>, System.Collections.Immutable.IImmutableSet<T>>? symmetricExceptDelegate,
            Func<string>? toStringDelegate,
            TryGetValueDelegateSignature? tryGetValueDelegate,
            Func<IEnumerable<T>, System.Collections.Immutable.IImmutableSet<T>>? unionDelegate)
        {
            this.AddDelegate = addDelegate ?? ((x) => throw new NotImplementedException());
            this.ClearDelegate = clearDelegate ?? (() => throw new NotImplementedException());
            this.ContainsDelegate = containsDelegate ?? ((x) => throw new NotImplementedException());
            this.CountDelegate = countDelegate ?? (() => throw new NotImplementedException());
            this.EqualsDelegate = equalsDelegate ?? ((x) => throw new NotImplementedException());
            this.ExceptDelegate = exceptDelegate ?? ((x) => throw new NotImplementedException());
            this.GetEnumeratorDelegate = getEnumeratorDelegate ?? (() => throw new NotImplementedException());
            this.GetHashCodeDelegate = getHashCodeDelegate ?? (() => throw new NotImplementedException());
            this.IntersectDelegate = intersectDelegate ?? ((x) => throw new NotImplementedException());
            this.IsProperSubsetOfDelegate = isProperSubsetOfDelegate ?? ((x) => throw new NotImplementedException());
            this.IsProperSupersetOfDelegate = isProperSupersetOfDelegate ?? ((x) => throw new NotImplementedException());
            this.IsSubsetOfDelegate = isSubsetOfDelegate ?? ((x) => throw new NotImplementedException());
            this.IsSupersetOfDelegate = isSupersetOfDelegate ?? ((x) => throw new NotImplementedException());
            this.OverlapsDelegate = overlapsDelegate ?? ((x) => throw new NotImplementedException());
            this.RemoveDelegate = removeDelegate ?? ((x) => throw new NotImplementedException());
            this.SetEqualsDelegate = setEqualsDelegate ?? ((x) => throw new NotImplementedException());
            this.SymmetricExceptDelegate = symmetricExceptDelegate ?? ((x) => throw new NotImplementedException());
            this.ToStringDelegate = toStringDelegate ?? (() => throw new NotImplementedException());
            this.TryGetValueDelegate = tryGetValueDelegate ?? ((T x, out T y) => throw new NotImplementedException());
            this.UnionDelegate = unionDelegate ?? ((x) => throw new NotImplementedException());
        }

        public delegate bool TryGetValueDelegateSignature(T equalValue, out T actualValue);

        public Func<T, System.Collections.Immutable.IImmutableSet<T>> AddDelegate { get; set; }

        public Func<System.Collections.Immutable.IImmutableSet<T>> ClearDelegate { get; set; }

        public Func<T, bool> ContainsDelegate { get; set; }

        public Func<int> CountDelegate { get; set; }

        public Func<object, bool> EqualsDelegate { get; set; }

        public Func<IEnumerable<T>, System.Collections.Immutable.IImmutableSet<T>> ExceptDelegate { get; set; }

        public Func<IEnumerator<T>> GetEnumeratorDelegate { get; set; }

        public Func<int> GetHashCodeDelegate { get; set; }

        public Func<IEnumerable<T>, System.Collections.Immutable.IImmutableSet<T>> IntersectDelegate { get; set; }

        public Func<IEnumerable<T>, bool> IsProperSubsetOfDelegate { get; set; }

        public Func<IEnumerable<T>, bool> IsProperSupersetOfDelegate { get; set; }

        public Func<IEnumerable<T>, bool> IsSubsetOfDelegate { get; set; }

        public Func<IEnumerable<T>, bool> IsSupersetOfDelegate { get; set; }

        public Func<IEnumerable<T>, bool> OverlapsDelegate { get; set; }

        public Func<T, System.Collections.Immutable.IImmutableSet<T>> RemoveDelegate { get; set; }

        public Func<IEnumerable<T>, bool> SetEqualsDelegate { get; set; }

        public Func<IEnumerable<T>, System.Collections.Immutable.IImmutableSet<T>> SymmetricExceptDelegate { get; set; }

        public Func<string> ToStringDelegate { get; set; }

        public TryGetValueDelegateSignature TryGetValueDelegate { get; set; }

        public Func<IEnumerable<T>, System.Collections.Immutable.IImmutableSet<T>> UnionDelegate { get; set; }

        public int Count => this.CountDelegate.Invoke();

        public System.Collections.Immutable.IImmutableSet<T> Add(T value) => this.AddDelegate.Invoke(value);

        public System.Collections.Immutable.IImmutableSet<T> Clear() => this.ClearDelegate.Invoke();

        public bool Contains(T item) => this.ContainsDelegate.Invoke(item);

        public override bool Equals(object obj) => this.EqualsDelegate.Invoke(obj);

        public System.Collections.Immutable.IImmutableSet<T> Except(IEnumerable<T> other) => this.ExceptDelegate.Invoke(other);

        public IEnumerator<T> GetEnumerator() => this.GetEnumeratorDelegate.Invoke();

        public override int GetHashCode() => this.GetHashCodeDelegate.Invoke();

        public System.Collections.Immutable.IImmutableSet<T> Intersect(IEnumerable<T> other) => this.IntersectDelegate.Invoke(other);

        public bool IsProperSubsetOf(IEnumerable<T> other) => this.IsProperSubsetOfDelegate.Invoke(other);

        public bool IsProperSupersetOf(IEnumerable<T> other) => this.IsProperSupersetOfDelegate.Invoke(other);

        public bool IsSubsetOf(IEnumerable<T> other) => this.IsSubsetOfDelegate.Invoke(other);

        public bool IsSupersetOf(IEnumerable<T> other) => this.IsSupersetOfDelegate.Invoke(other);

        public bool Overlaps(IEnumerable<T> other) => this.OverlapsDelegate.Invoke(other);

        public System.Collections.Immutable.IImmutableSet<T> Remove(T value) => this.RemoveDelegate.Invoke(value);

        public bool SetEquals(IEnumerable<T> other) => this.SetEqualsDelegate.Invoke(other);

        public System.Collections.Immutable.IImmutableSet<T> SymmetricExcept(IEnumerable<T> other) => this.SymmetricExceptDelegate.Invoke(other);

        public override string ToString() => this.ToStringDelegate.Invoke();

        public bool TryGetValue(T equalValue, out T actualValue) => this.TryGetValueDelegate.Invoke(equalValue, out actualValue);

        public System.Collections.Immutable.IImmutableSet<T> Union(IEnumerable<T> other) => this.UnionDelegate.Invoke(other);

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
