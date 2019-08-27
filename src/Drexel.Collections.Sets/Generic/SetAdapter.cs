using System;
using System.Collections;
using System.Collections.Generic;

namespace Drexel.Collections.Generic
{
    /// <summary>
    /// Adapts a <see cref="System.Collections.Generic.ISet{T}"/> to a
    /// <see cref="Drexel.Collections.Generic.ISet{T}"/>.
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
        IEquatable<System.Collections.Generic.ISet<T>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetAdapter{T}"/> class.
        /// </summary>
        /// <param name="set">
        /// The set to adapt.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="set"/> is <see langword="null"/>.
        /// </exception>
        public SetAdapter(System.Collections.Generic.ISet<T> set)
        {
            this.Set = set ?? throw new ArgumentNullException(nameof(set));
        }

        /// <summary>
        /// Gets the underlying <see cref="System.Collections.Generic.ISet{T}"/> this adapter is adapting.
        /// </summary>
        public System.Collections.Generic.ISet<T> Set { get; }

        /// <inheritdoc/>
        public int Count => this.Set.Count;

        /// <inheritdoc/>
        public bool IsReadOnly => this.Set.IsReadOnly;

        /// <inheritdoc/>
        public bool Add(T item) => this.Set.Add(item);

        /// <inheritdoc/>
        public void Clear() => this.Set.Clear();

        /// <inheritdoc/>
        public bool Contains(T item) => this.Set.Contains(item);

        /// <inheritdoc/>
        public void CopyTo(T[] array, int arrayIndex) => this.Set.CopyTo(array, arrayIndex);

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Drexel.Collections.Generic.ISet<T> asDrexelSet)
            {
                return this.Equals(asDrexelSet);
            }
            else if (obj is System.Collections.Generic.ISet<T> asSystemSet)
            {
                return this.Equals(asSystemSet);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool Equals(Drexel.Collections.Generic.ISet<T> other)
        {
            return base.Equals(other);
        }

        /// <inheritdoc/>
        public bool Equals(System.Collections.Generic.ISet<T> other)
        {
            return this.Set.Equals(other);
        }

        /// <inheritdoc/>
        public void ExceptWith(IEnumerable<T> other) => this.Set.ExceptWith(other);

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator() => this.Set.GetEnumerator();

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <inheritdoc/>
        public void IntersectWith(IEnumerable<T> other) => this.Set.IntersectWith(other);

        /// <inheritdoc/>
        public bool IsProperSubsetOf(IEnumerable<T> other) => this.Set.IsProperSubsetOf(other);

        /// <inheritdoc/>
        public bool IsProperSupersetOf(IEnumerable<T> other) => this.Set.IsProperSupersetOf(other);

        /// <inheritdoc/>
        public bool IsSubsetOf(IEnumerable<T> other) => this.Set.IsSubsetOf(other);

        /// <inheritdoc/>
        public bool IsSupersetOf(IEnumerable<T> other) => this.Set.IsSupersetOf(other);

        /// <inheritdoc/>
        public bool Overlaps(IEnumerable<T> other) => this.Set.Overlaps(other);

        /// <inheritdoc/>
        public bool Remove(T item) => this.Set.Remove(item);

        /// <inheritdoc/>
        public bool SetEquals(IEnumerable<T> other) => this.Set.SetEquals(other);

        /// <inheritdoc/>
        public void SymmetricExceptWith(IEnumerable<T> other) => this.Set.SymmetricExceptWith(other);

        /// <inheritdoc/>
        public void UnionWith(IEnumerable<T> other) => this.Set.UnionWith(other);

        /// <inheritdoc/>
        void ICollection<T>.Add(T item) => this.Add(item);

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
