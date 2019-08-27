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
    public class ReadOnlySet<T> : IReadOnlySet<T>
    {
        private readonly IReadOnlySet<T> set;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlySet{T}"/> class that is a read-only wrapper around the
        /// specified set.
        /// </summary>
        /// <param name="set">
        /// The set to wrap.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="set"/> is <see langword="null"/>.
        /// </exception>
        public ReadOnlySet(IReadOnlySet<T> set)
        {
            this.set = set ?? throw new ArgumentNullException(nameof(set));
        }

        /// <inheritdoc/>
        public int Count => this.set.Count;

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator() => this.set.GetEnumerator();

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => this.set.GetEnumerator();
    }
}
