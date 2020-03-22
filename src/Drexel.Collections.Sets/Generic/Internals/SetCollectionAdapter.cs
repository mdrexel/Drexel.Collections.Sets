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
            if (this.collection.IsReadOnly)
            {
                throw new NotSupportedException(ExceptionMessages.CollectionIsReadOnly);
            }

            if (this.Contains(item))
            {
                return false;
            }

            this.collection.Add(item);
            return true;
        }

        /// <inheritdoc/>
        public void Clear() => this.collection.Clear();

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
        public void CopyTo(T[] array, int arrayIndex) => this.collection.CopyTo(array, arrayIndex);

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Drexel.Collections.Generic.ISet<T> asDrexelSet)
            {
                return this.Equals(asDrexelSet);
            }
            else if (obj is System.Collections.Generic.ICollection<T> asSystemCollection)
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
        public bool Equals(ICollection<T> other)
        {
            return this.collection.Equals(other);
        }

        /// <inheritdoc/>
        public void ExceptWith(IEnumerable<T> other)
        {
            if (this.collection.IsReadOnly)
            {
                throw new NotSupportedException(ExceptionMessages.CollectionIsReadOnly);
            }

            if (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            foreach (T element in other)
            {
                this.collection.Remove(element);
            }
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator() => this.collection.GetEnumerator();

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return base.GetHashCode();
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
