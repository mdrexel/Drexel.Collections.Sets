﻿using System.Collections.Generic;

namespace Drexel.Collections.Generic
{
    /// <summary>
    /// Represents a strongly-typed, read-only collection of elements that contains no duplicates.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the elements.
    /// </typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Naming",
        "CA1710:Identifiers should have correct suffix",
        Justification = "Naming inherited from existing convention.")]
    public interface IReadOnlyInvariantSet<T> : IReadOnlySet<T>
    {
        /// <summary>
        /// Determines whether the current set contains the specified element.
        /// </summary>
        /// <param name="item">
        /// The element to locate in the current set.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the item is found in the current set; otherwise, <see langword="false"/>.
        /// </returns>
        bool Contains(T item);

        /// <summary>
        /// Determines whether the current set is a subset of the specified <paramref name="other"/>. Being a subset
        /// means that <paramref name="other"/> contains all elements of this set.
        /// </summary>
        /// <param name="other">
        /// The collection to compare to the current set.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the current set is a subset of the specified <paramref name="other"/>; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="other"/> is <see langword="null"/>.
        /// </exception>
        bool IsSubsetOf(IEnumerable<T> other);

        /// <summary>
        /// Determines whether the current set is a superset of the specified <paramref name="other"/>. Being a
        /// superset means that this set contains all elements of <paramref name="other"/>.
        /// </summary>
        /// <param name="other">
        /// The collection to compare to the current set.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the current set is a superset of the specified <paramref name="other"/>;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="other"/> is <see langword="null"/>.
        /// </exception>
        bool IsSupersetOf(IEnumerable<T> other);

        /// <summary>
        /// Determines whether the current set is a proper subset of the specified <paramref name="other"/>. Being a
        /// "proper" subset means that <paramref name="other"/> contains all elements of this set, as well as at least
        /// one element not in this set.
        /// </summary>
        /// <param name="other">
        /// The collection to compare to the current set.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the current set is a proper subset of the specified <paramref name="other"/>;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="other"/> is <see langword="null"/>.
        /// </exception>
        bool IsProperSubsetOf(IEnumerable<T> other);

        /// <summary>
        /// Determines whether the current set is a proper superset of the specified <paramref name="other"/>. Being a
        /// "proper" superset means that this set contains all the elements of <paramref name="other"/>, as well as at
        /// least one element not in <paramref name="other"/>.
        /// </summary>
        /// <param name="other">
        /// The collection to compare to the current set.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the current set is a proper superset of the specified <paramref name="other"/>;
        /// otherwise, <see langword="false"/>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="other"/> is <see langword="null"/>.
        /// </exception>
        bool IsProperSupersetOf(IEnumerable<T> other);

        /// <summary>
        /// Determines whether the current set overlaps the specified <paramref name="other"/>. Overlapping means that
        /// this set contains at least one element also contained by <paramref name="other"/>.
        /// </summary>
        /// <param name="other">
        /// The collection to compare to the current set.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the current set overlaps the specified <paramref name="other"/>; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="other"/> is <see langword="null"/>.
        /// </exception>
        bool Overlaps(IEnumerable<T> other);

        /// <summary>
        /// Determines whether the current set is equal to the specified <paramref name="other"/>.
        /// </summary>
        /// <param name="other">
        /// The collection to compare to the current set.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the current set is equal to the specified <paramref name="other"/>; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="other"/> is <see langword="null"/>.
        /// </exception>
        bool SetEquals(IEnumerable<T> other);
    }
}
