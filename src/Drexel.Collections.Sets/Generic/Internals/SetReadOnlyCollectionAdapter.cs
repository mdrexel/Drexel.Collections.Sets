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
    internal sealed class SetReadOnlyCollectionAdapter<T> :
        Drexel.Collections.Generic.ISet<T>,
        IEquatable<Drexel.Collections.Generic.ISet<T>>,
        IEquatable<System.Collections.Generic.IReadOnlyCollection<T>>
    {
        private readonly System.Collections.Generic.IReadOnlyCollection<T> collection;
        private readonly IEqualityComparer<T> comparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetReadOnlyCollectionAdapter{T}"/> class.
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
        /// Thrown when <paramref name="collection"/> or <paramref name="comparer"/> are <see langword="null"/>.
        /// </exception>
        public SetReadOnlyCollectionAdapter(
            System.Collections.Generic.IReadOnlyCollection<T> collection,
            IEqualityComparer<T>? comparer = null)
        {
            this.collection = collection ?? throw new ArgumentNullException(nameof(collection));
            this.comparer = comparer ?? EqualityComparer<T>.Default;
        }

        /// <inheritdoc/>
        public int Count => this.collection.Count;

        /// <inheritdoc/>
        // Since the contract is given in terms of IReadOnlyCollection, report to consumers that the set is read-only,
        // even if the underlying collection supports being mutated.
        public bool IsReadOnly => true;

        /// <inheritdoc/>
        public bool Add(T item) => throw new NotSupportedException(ExceptionMessages.CollectionIsReadOnly);

        /// <inheritdoc/>
        public void Clear() => throw new NotSupportedException(ExceptionMessages.CollectionIsReadOnly);

        /// <inheritdoc/>
        public bool Contains(T item)
        {
            foreach (T element in this.collection)
            {
                if (this.comparer.Equals(element, item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc/>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            else if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(arrayIndex),
                    ExceptionMessages.ArrayIndexBelowLowerBound);
            }
            else if ((array.Length - arrayIndex) < this.Count)
            {
                throw new ArgumentException(
                    ExceptionMessages.DestinationArrayNotLongEnough,
                    nameof(array));
            }
            else
            {
                IEnumerator<T> enumerator = this.collection.GetEnumerator();
                for (int counter = arrayIndex; enumerator.MoveNext(); counter++)
                {
                    array[counter] = enumerator.Current;
                }
            }
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Drexel.Collections.Generic.ISet<T> asDrexelSet)
            {
                return this.Equals(asDrexelSet);
            }
            else if (obj is System.Collections.Generic.IReadOnlyCollection<T> asSystemCollection)
            {
                return this.Equals(asSystemCollection);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool Equals(Drexel.Collections.Generic.ISet<T> other)
        {
            return base.Equals(other);
        }

        /// <inheritdoc/>
        public bool Equals(System.Collections.Generic.IReadOnlyCollection<T> other)
        {
            return this.collection.Equals(other);
        }

        /// <inheritdoc/>
        public void ExceptWith(IEnumerable<T> other) =>
            throw new NotSupportedException(ExceptionMessages.CollectionIsReadOnly);

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator() => this.collection.GetEnumerator();

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <inheritdoc/>
        public void IntersectWith(IEnumerable<T> other) =>
            throw new NotSupportedException(ExceptionMessages.CollectionIsReadOnly);

        /// <inheritdoc/>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            return new HashSet<T>(this.collection, this.comparer).IsProperSubsetOf(other);
        }

        /// <inheritdoc/>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            return new HashSet<T>(this.collection, this.comparer).IsProperSupersetOf(other);
        }

        /// <inheritdoc/>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            return new HashSet<T>(this.collection, this.comparer).IsSubsetOf(other);
        }

        /// <inheritdoc/>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            return new HashSet<T>(this.collection, this.comparer).IsSupersetOf(other);
        }

        /// <inheritdoc/>
        public bool Overlaps(IEnumerable<T> other)
        {
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            else if (this.collection.Count == 0)
            {
                return true;
            }

            return new HashSet<T>(this.collection, this.comparer).Overlaps(other);
        }

        /// <inheritdoc/>
        public bool Remove(T item) =>
            throw new NotSupportedException(ExceptionMessages.CollectionIsReadOnly);

        /// <inheritdoc/>
        public bool SetEquals(IEnumerable<T> other)
        {
            return new HashSet<T>(this.collection, this.comparer).SetEquals(other);
        }

        /// <inheritdoc/>
        public void SymmetricExceptWith(IEnumerable<T> other) =>
            throw new NotSupportedException(ExceptionMessages.CollectionIsReadOnly);

        /// <inheritdoc/>
        public void UnionWith(IEnumerable<T> other) =>
            throw new NotSupportedException(ExceptionMessages.CollectionIsReadOnly);

        /// <inheritdoc/>
        void ICollection<T>.Add(T item) => this.Add(item);

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
