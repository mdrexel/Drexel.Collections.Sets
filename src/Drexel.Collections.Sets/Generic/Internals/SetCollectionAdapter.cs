using System;
using System.Collections;
using System.Collections.Generic;

namespace Drexel.Collections.Generic.Internals
{
    /// <summary>
    /// Adapts a <see cref="System.Collections.Generic.IReadOnlyCollection{T}"/> to a
    /// <see cref="Drexel.Collections.Generic.ISet{T}"/>. It is assumed that the contents of the collection represent
    /// a valid set, where "valid" is determined by the instantiator of the instance of this class.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the elements contained by the set.
    /// </typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Naming",
        "CA1710:Identifiers should have correct suffix",
        Justification = "Naming inherited from existing Adapter design pattern.")]
    internal sealed class SetCollectionAdapter<T> :
        Drexel.Collections.Generic.ISet<T>,
        IEquatable<Drexel.Collections.Generic.ISet<T>>,
        IEquatable<System.Collections.Generic.ICollection<T>>
    {
        private readonly System.Collections.Generic.ICollection<T> collection;
        private readonly IEqualityComparer<T> comparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetCollectionAdapter{T}"/> class.
        /// </summary>
        /// <param name="collection">
        /// The set to adapt.
        /// </param>
        /// <param name="comparer">
        /// The comparer to use when comparing equality of instances contained by <paramref name="collection"/>. This
        /// comparer is used when the methods on the <see cref="ISet{T}"/> interface are called. If
        /// <see langword="null"/>, the default equality comparer for the type <typeparamref name="T"/> will be used.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="collection"/> is <see langword="null"/>.
        /// </exception>
        public SetCollectionAdapter(
            System.Collections.Generic.ICollection<T> collection,
            IEqualityComparer<T>? comparer = null)
        {
            this.collection = collection ?? throw new ArgumentNullException(nameof(collection));
            this.comparer = comparer ?? EqualityComparer<T>.Default;
        }

        /// <inheritdoc/>
        public int Count => this.collection.Count;

        /// <inheritdoc/>
        public bool IsReadOnly => this.collection.IsReadOnly;

        /// <inheritdoc/>
        public bool Add(T item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Clear()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool Equals(ISet<T> other)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool Equals(ICollection<T> other)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void ExceptWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void IntersectWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool Overlaps(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool SetEquals(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void UnionWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        void ICollection<T>.Add(T item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
