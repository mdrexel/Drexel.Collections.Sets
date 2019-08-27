using System;
using System.Collections;
using System.Collections.Generic;
using Drexel.Collections.Generic;

namespace Drexel.Collections.ObjectModel
{
    /// <summary>
    /// Represents a strongly-typed, read-only collection of elements that contains no duplicates that is a read-only
    /// wrapper around another set.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the elements.
    /// </typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Naming",
        "CA1710:Identifiers should have correct suffix",
        Justification = "Naming inherited from existing convention.")]
    public class ReadOnlyInvariantSet<T> : IReadOnlyInvariantSet<T>
    {
        private readonly Drexel.Collections.Generic.IReadOnlyInvariantSet<T> set;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyInvariantSet{T}"/> class that is a read-only wrapper
        /// around the specified set.
        /// </summary>
        /// <param name="set">
        /// The set to wrap.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="set"/> is <see langword="null"/>.
        /// </exception>
        public ReadOnlyInvariantSet(Drexel.Collections.Generic.IReadOnlyInvariantSet<T> set)
        {
            this.set = set ?? throw new ArgumentNullException(nameof(set));
        }

        /// <inheritdoc/>
        public int Count => this.set.Count;

        /// <inheritdoc/>
        public bool Contains(T item) => this.set.Contains(item);

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator() => this.set.GetEnumerator();

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
        public bool SetEquals(IEnumerable<T> other) => this.set.SetEquals(other);

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
