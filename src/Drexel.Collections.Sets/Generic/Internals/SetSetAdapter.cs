using System;
using System.Collections;
using System.Collections.Generic;

namespace Drexel.Collections.Generic.Internals
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
    public sealed class SetSetAdapter<T> :
        Drexel.Collections.Generic.ISet<T>,
        IEquatable<Drexel.Collections.Generic.ISet<T>>,
        IEquatable<System.Collections.Generic.ISet<T>>
    {
        private readonly System.Collections.Generic.ISet<T> set;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetSetAdapter{T}"/> class.
        /// </summary>
        /// <param name="set">
        /// The set to adapt.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="set"/> is <see langword="null"/>.
        /// </exception>
        public SetSetAdapter(System.Collections.Generic.ISet<T> set)
        {
            this.set = set ?? throw new ArgumentNullException(nameof(set));
        }

        /// <inheritdoc/>
        public int Count => this.set.Count;

        /// <inheritdoc/>
        public bool IsReadOnly => this.set.IsReadOnly;

        /// <inheritdoc/>
        public bool Add(T item) => this.set.Add(item);

        /// <inheritdoc/>
        public void Clear() => this.set.Clear();

        /// <inheritdoc/>
        public bool Contains(T item) => this.set.Contains(item);

        /// <inheritdoc/>
        public void CopyTo(T[] array, int arrayIndex) => this.set.CopyTo(array, arrayIndex);

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
            return this.set.Equals(other);
        }

        /// <inheritdoc/>
        public void ExceptWith(IEnumerable<T> other) => this.set.ExceptWith(other);

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator() => this.set.GetEnumerator();

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <inheritdoc/>
        public void IntersectWith(IEnumerable<T> other) => this.set.IntersectWith(other);

        /// <inheritdoc/>
        public bool IsProperSubsetOf(IEnumerable<T> other) => this.set.IsProperSubsetOf(other);

        /// <inheritdoc/>
        public bool IsProperSupersetOf(IEnumerable<T> other) => this.set.IsProperSupersetOf(other);

        /// <inheritdoc/>
        public bool IsSubsetOf(IEnumerable<T> other) => this.set.IsSubsetOf(other);

        /// <inheritdoc/>
        public bool IsSupersetOf(IEnumerable<T> other) => this.set.IsSupersetOf(other);

        /// <inheritdoc/>
        public bool Overlaps(IEnumerable<T> other) => this.set.Overlaps(other);

        /// <inheritdoc/>
        public bool Remove(T item) => this.set.Remove(item);

        /// <inheritdoc/>
        public bool SetEquals(IEnumerable<T> other) => this.set.SetEquals(other);

        /// <inheritdoc/>
        public void SymmetricExceptWith(IEnumerable<T> other) => this.set.SymmetricExceptWith(other);

        /// <inheritdoc/>
        public void UnionWith(IEnumerable<T> other) => this.set.UnionWith(other);

        /// <inheritdoc/>
        void ICollection<T>.Add(T item) => this.Add(item);

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
