using System;
using System.Collections;
using System.Collections.Generic;
using Drexel.Collections.Generic.Internals;

namespace Drexel.Collections.Generic
{
    /// <summary>
    /// Adapts an existing collection to a <see cref="Drexel.Collections.Generic.ISet{T}"/>. It is assumed that the
    /// contents of the collection represent a valid set, where "valid" is determined by the instantiator of the
    /// instance of this class.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the elements contained by the set.
    /// </typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Naming",
        "CA1710:Identifiers should have correct suffix",
        Justification = "Naming inherited from existing Adapter design pattern.")]
    public sealed class SetAdapter<T> :
        Drexel.Collections.Generic.ISet<T>,
        IEquatable<Drexel.Collections.Generic.ISet<T>>,
        IEquatable<System.Collections.Generic.ISet<T>>,
        IEquatable<System.Collections.Generic.IReadOnlyCollection<T>>,
        IEquatable<System.Collections.Generic.ICollection<T>>
    {
        private readonly ISet<T> adapter;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetAdapter{T}"/> class, wrapping the specified
        /// <see cref="System.Collections.Generic.ISet{T}"/> <paramref name="set"/>.
        /// </summary>
        /// <param name="set">
        /// The set to wrap.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="set"/> is <see langword="null"/>.
        /// </exception>
        public SetAdapter(System.Collections.Generic.ISet<T> set)
        {
            this.adapter = new SetSetAdapter<T>(set);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetAdapter{T}"/> class, wrapping the specified
        /// <see cref="System.Collections.Generic.IReadOnlyCollection{T}"/> <paramref name="collection"/>. It is
        /// assumed that the contents of the collection represent a valid set, where "valid" is determined by the
        /// caller.
        /// </summary>
        /// <param name="collection">
        /// The collection to wrap.
        /// </param>
        /// <param name="comparer">
        /// The comparer to use when comparing equality of instances contained by <paramref name="collection"/>. This
        /// comparer is used when the methods on the <see cref="ISet{T}"/> interface are called. If
        /// <see langword="null"/>, the default equality comparer for the type <typeparamref name="T"/> will be used.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="collection"/> is <see langword="null"/>.
        /// </exception>
        public SetAdapter(
            System.Collections.Generic.IReadOnlyCollection<T> collection,
            IEqualityComparer<T>? comparer = null)
        {
            this.adapter = new SetReadOnlyCollectionAdapter<T>(collection, comparer);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetAdapter{T}"/> class, wrapping the specified
        /// <see cref="System.Collections.Generic.ICollection{T}"/> <paramref name="collection"/>. It is assumed that
        /// the contents of the collection represent a valid set, where "valid" is determined by the caller.
        /// </summary>
        /// <param name="collection">
        /// The collection to wrap.
        /// </param>
        /// <param name="comparer">
        /// The comparer to use when comparing equality of instances contained by <paramref name="collection"/>. This
        /// comparer is used when the methods on the <see cref="ISet{T}"/> interface are called. If
        /// <see langword="null"/>, the default equality comparer for the type <typeparamref name="T"/> will be used.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="collection"/> is <see langword="null"/>.
        /// </exception>
        public SetAdapter(
            ICollection<T> collection,
            IEqualityComparer<T>? comparer = null)
        {
            this.adapter = new SetCollectionAdapter<T>(collection, comparer);
        }

        /// <inheritdoc/>
        public int Count => this.adapter.Count;

        /// <inheritdoc/>
        public bool IsReadOnly => this.adapter.IsReadOnly;

        /// <inheritdoc/>
        public bool Add(T item) => this.adapter.Add(item);

        /// <inheritdoc/>
        public void Clear() => this.adapter.Clear();

        /// <inheritdoc/>
        public bool Contains(T item) => this.adapter.Contains(item);

        /// <inheritdoc/>
        public void CopyTo(T[] array, int arrayIndex) => this.adapter.CopyTo(array, arrayIndex);

        /// <inheritdoc/>
        public bool Equals(System.Collections.Generic.ISet<T> other) => this.adapter.Equals(other);

        /// <inheritdoc/>
        public bool Equals(Drexel.Collections.Generic.ISet<T> other) => this.adapter.Equals(other);

        /// <inheritdoc/>
        public bool Equals(System.Collections.Generic.IReadOnlyCollection<T> other) => this.adapter.Equals(other);

        /// <inheritdoc/>
        public bool Equals(ICollection<T> other) => this.adapter.Equals(other);

        /// <inheritdoc/>
        public void ExceptWith(IEnumerable<T> other) => this.adapter.ExceptWith(other);

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator() => this.adapter.GetEnumerator();

        /// <inheritdoc/>
        public void IntersectWith(IEnumerable<T> other) => this.adapter.IntersectWith(other);

        /// <inheritdoc/>
        public bool IsProperSubsetOf(IEnumerable<T> other) => this.adapter.IsProperSubsetOf(other);

        /// <inheritdoc/>
        public bool IsProperSupersetOf(IEnumerable<T> other) => this.adapter.IsProperSupersetOf(other);

        /// <inheritdoc/>
        public bool IsSubsetOf(IEnumerable<T> other) => this.adapter.IsSubsetOf(other);

        /// <inheritdoc/>
        public bool IsSupersetOf(IEnumerable<T> other) => this.adapter.IsSupersetOf(other);

        /// <inheritdoc/>
        public bool Overlaps(IEnumerable<T> other) => this.adapter.Overlaps(other);

        /// <inheritdoc/>
        public bool Remove(T item) => this.adapter.Remove(item);

        /// <inheritdoc/>
        public bool SetEquals(IEnumerable<T> other) => this.adapter.SetEquals(other);

        /// <inheritdoc/>
        public void SymmetricExceptWith(IEnumerable<T> other) => this.adapter.SymmetricExceptWith(other);

        /// <inheritdoc/>
        public void UnionWith(IEnumerable<T> other) => this.adapter.UnionWith(other);

        /// <inheritdoc/>
        void ICollection<T>.Add(T item) => this.adapter.Add(item);

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => this.adapter.GetEnumerator();
    }
}
