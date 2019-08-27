using System;
using System.Collections;
using System.Collections.Generic;

namespace Drexel.Collections.Tests.Shared.Mocks
{
    public class MockSystemSet<T> : ISet<T>
    {
        public MockSystemSet()
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
                  null,
                  null)
        {
        }

        public MockSystemSet(ISet<T> set)
            : this(
                  set.Add,
                  set.Clear,
                  set.Contains,
                  set.CopyTo,
                  () => set.Count,
                  set.Equals,
                  set.ExceptWith,
                  set.GetEnumerator,
                  set.GetHashCode,
                  set.IntersectWith,
                  set.IsProperSubsetOf,
                  set.IsProperSupersetOf,
                  () => set.IsReadOnly,
                  set.IsSubsetOf,
                  set.IsSupersetOf,
                  set.Overlaps,
                  set.Remove,
                  set.SetEquals,
                  set.SymmetricExceptWith,
                  set.ToString,
                  set.UnionWith)
        {
        }

        public MockSystemSet(
            Func<T, bool>? addDelegate,
            Action? clearDelegate,
            Func<T, bool>? containsDelegate,
            Action<T[], int>? copyToDelegate,
            Func<int>? countDelegate,
            Func<object, bool>? equalsDelegate,
            Action<IEnumerable<T>>? exceptWithDelegate,
            Func<IEnumerator<T>>? getEnumeratorDelegate,
            Func<int>? getHashCodeDelegate,
            Action<IEnumerable<T>>? intersectWithDelegate,
            Func<IEnumerable<T>, bool>? isProperSubsetOfDelegate,
            Func<IEnumerable<T>, bool>? isProperSupersetOfDelegate,
            Func<bool>? isReadOnlyDelegate,
            Func<IEnumerable<T>, bool>? isSubsetOfDelegate,
            Func<IEnumerable<T>, bool>? isSupersetOfDelegate,
            Func<IEnumerable<T>, bool>? overlapsDelegate,
            Func<T, bool>? removeDelegate,
            Func<IEnumerable<T>, bool>? setEqualsDelegate,
            Action<IEnumerable<T>>? symmetricExceptWithDelegate,
            Func<string>? toStringDelegate,
            Action<IEnumerable<T>>? unionWithDelegate)
        {
            this.AddDelegate = addDelegate ?? ((x) => throw new NotImplementedException());
            this.ClearDelegate = clearDelegate ?? (() => throw new NotImplementedException());
            this.ContainsDelegate = containsDelegate ?? ((x) => throw new NotImplementedException());
            this.CopyToDelegate = copyToDelegate ?? ((x, y) => throw new NotImplementedException());
            this.CountDelegate = countDelegate ?? (() => throw new NotImplementedException());
            this.EqualsDelegate = equalsDelegate ?? ((x) => throw new NotImplementedException());
            this.ExceptWithDelegate = exceptWithDelegate ?? ((x) => throw new NotImplementedException());
            this.GetEnumeratorDelegate = getEnumeratorDelegate ?? (() => throw new NotImplementedException());
            this.GetHashCodeDelegate = getHashCodeDelegate ?? (() => throw new NotImplementedException());
            this.IntersectWithDelegate = intersectWithDelegate ?? ((x) => throw new NotImplementedException());
            this.IsProperSubsetOfDelegate = isProperSubsetOfDelegate ?? ((x) => throw new NotImplementedException());
            this.IsProperSupersetOfDelegate = isProperSupersetOfDelegate ?? ((x) => throw new NotImplementedException());
            this.IsReadOnlyDelegate = isReadOnlyDelegate ?? (() => throw new NotImplementedException());
            this.IsSubsetOfDelegate = isSubsetOfDelegate ?? ((x) => throw new NotImplementedException());
            this.IsSupersetOfDelegate = isSupersetOfDelegate ?? ((x) => throw new NotImplementedException());
            this.OverlapsDelegate = overlapsDelegate ?? ((x) => throw new NotImplementedException());
            this.RemoveDelegate = removeDelegate ?? ((x) => throw new NotImplementedException());
            this.SetEqualsDelegate = setEqualsDelegate ?? ((x) => throw new NotImplementedException());
            this.SymmetricExceptWithDelegate = symmetricExceptWithDelegate ?? ((x) => throw new NotImplementedException());
            this.ToStringDelegate = toStringDelegate ?? (() => throw new NotImplementedException());
            this.UnionWithDelegate = unionWithDelegate ?? ((x) => throw new NotImplementedException());
        }

        public Func<T, bool> AddDelegate { get; set; }

        public Action ClearDelegate { get; set; }

        public Func<T, bool> ContainsDelegate { get; set; }

        public Action<T[], int> CopyToDelegate { get; set; }

        public Func<int> CountDelegate { get; set; }

        public Func<object, bool> EqualsDelegate { get; set; }

        public Action<IEnumerable<T>> ExceptWithDelegate { get; set; }

        public Func<IEnumerator<T>> GetEnumeratorDelegate { get; set; }

        public Func<int> GetHashCodeDelegate { get; set; }

        public Action<IEnumerable<T>> IntersectWithDelegate { get; set; }

        public Func<IEnumerable<T>, bool> IsProperSubsetOfDelegate { get; set; }

        public Func<IEnumerable<T>, bool> IsProperSupersetOfDelegate { get; set; }

        public Func<bool> IsReadOnlyDelegate { get; set; }

        public Func<IEnumerable<T>, bool> IsSubsetOfDelegate { get; set; }

        public Func<IEnumerable<T>, bool> IsSupersetOfDelegate { get; set; }

        public Func<IEnumerable<T>, bool> OverlapsDelegate { get; set; }

        public Func<T, bool> RemoveDelegate { get; set; }

        public Func<IEnumerable<T>, bool> SetEqualsDelegate { get; set; }

        public Action<IEnumerable<T>> SymmetricExceptWithDelegate { get; set; }

        public Func<string> ToStringDelegate { get; set; }

        public Action<IEnumerable<T>> UnionWithDelegate { get; set; }

        public int Count => this.CountDelegate.Invoke();

        public bool IsReadOnly => this.IsReadOnlyDelegate.Invoke();

        public bool Add(T item) => this.AddDelegate.Invoke(item);

        public void Clear() => this.ClearDelegate.Invoke();

        public bool Contains(T item) => this.ContainsDelegate.Invoke(item);

        public void CopyTo(T[] array, int arrayIndex) => this.CopyToDelegate.Invoke(array, arrayIndex);

        public override bool Equals(object obj) => this.EqualsDelegate.Invoke(obj);

        public void ExceptWith(IEnumerable<T> other) => this.ExceptWithDelegate.Invoke(other);

        public IEnumerator<T> GetEnumerator() => this.GetEnumeratorDelegate.Invoke();

        public override int GetHashCode() => this.GetHashCodeDelegate.Invoke();

        public void IntersectWith(IEnumerable<T> other) => this.IntersectWithDelegate.Invoke(other);

        public bool IsProperSubsetOf(IEnumerable<T> other) => this.IsProperSubsetOfDelegate.Invoke(other);

        public bool IsProperSupersetOf(IEnumerable<T> other) => this.IsProperSupersetOfDelegate.Invoke(other);

        public bool IsSubsetOf(IEnumerable<T> other) => this.IsSubsetOfDelegate.Invoke(other);

        public bool IsSupersetOf(IEnumerable<T> other) => this.IsSupersetOfDelegate.Invoke(other);

        public bool Overlaps(IEnumerable<T> other) => this.OverlapsDelegate.Invoke(other);

        public bool Remove(T item) => this.RemoveDelegate.Invoke(item);

        public bool SetEquals(IEnumerable<T> other) => this.SetEqualsDelegate.Invoke(other);

        public void SymmetricExceptWith(IEnumerable<T> other) => this.SymmetricExceptWithDelegate.Invoke(other);

        public override string ToString() => this.ToStringDelegate.Invoke();

        public void UnionWith(IEnumerable<T> other) => this.UnionWithDelegate.Invoke(other);

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        void ICollection<T>.Add(T item) => this.Add(item);
    }
}
