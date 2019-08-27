﻿using System.Collections.Generic;

namespace Drexel.Collections.Generic
{
    /// <summary>
    /// Represents a strongly-typed collection of elements that contains no duplicates.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the elements.
    /// </typeparam>
    public interface ISet<T> : IReadOnlyInvariantSet<T>, System.Collections.Generic.ISet<T>
    {
        // Need to hide the Count property so that implementors don't have to explicitly implement both the ISet
        // and the IReadOnlyInvariantSet Count properties. This doesn't fix the issue that they could still choose to
        // do so, but I'm going to discount this because of how unlikely it is that it's intentional.
        /// <summary>
        /// Gets the number of elements contained in the <see cref="ISet{T}"/>.
        /// </summary>
        new int Count { get; }

        // Need to hide the Add method because ICollection's Add doesn't return a value, but we want to indicate
        // whether the element was added or not.
        /// <summary>
        /// Adds an element to the current set and returns a value to indicate if the element was successfully added.
        /// </summary>
        /// <param name="item">
        /// The element to add to the set.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the element was added to the set; <see langword="false"/> if the element is
        /// already in the set.
        /// </returns>
        new bool Add(T item);

        // Need to hide the Contains method so that implementors don't have to explicitly implement both the
        // ISet and the IReadOnlyInvariantSet Contains methods. This is the same issue as the earlier Count
        // property.
        /// <summary>
        /// Determines whether the current set contains the specified element.
        /// </summary>
        /// <param name="item">
        /// The element to locate in the current set.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the item is found in the current set; otherwise, <see langword="false"/>.
        /// </returns>
        new bool Contains(T item);

        // Same as above.
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
        new bool IsSubsetOf(IEnumerable<T> other);

        // Same as above.
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
        new bool IsSupersetOf(IEnumerable<T> other);

        // Same as above.
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
        new bool IsProperSubsetOf(IEnumerable<T> other);

        // Same as above.
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
        new bool IsProperSupersetOf(IEnumerable<T> other);

        // Same as above.
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
        new bool Overlaps(IEnumerable<T> other);

        // Same as above.
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
        new bool SetEquals(IEnumerable<T> other);
    }
}
