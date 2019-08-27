using System.Collections.Generic;
using Drexel.Collections.Generic;

namespace Drexel.Collections.Immutable
{
    /// <summary>
    /// Represents a set of elements that can only be modified by creating a new instance of the set.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the elements.
    /// </typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Naming",
        "CA1710:Identifiers should have correct suffix",
        Justification = "Naming inherited from existing interface.")]
    public interface IImmutableSet<T> : IReadOnlyInvariantSet<T>, System.Collections.Immutable.IImmutableSet<T>
    {
        // The new methods defined in this interface are to make it so that calls to this class are unambiguous, or
        // to return a Drexel.Collections.Immutable.IImutableSet`1 instead of a
        // System.Collections.Immutable.IImmutableSet`1.

        /// <summary>
        /// Gets the number of elements contained in the <see cref="IImmutableSet{T}"/>.
        /// </summary>
        new int Count { get; }

        /// <summary>
        /// Adds the specified element to this immutable set.
        /// </summary>
        /// <param name="value">
        /// The element to add.
        /// </param>
        /// <returns>
        /// A new set with the element added, or this set if the element is already in the set.
        /// </returns>
        new Drexel.Collections.Immutable.IImmutableSet<T> Add(T value);

        /// <summary>
        /// Retrieves an empty immutable set that has the same sorting and ordering semantics as this instance.
        /// </summary>
        /// <returns>
        /// An empty set that has the same sorting and ordering semantics as this instance.
        /// </returns>
        new Drexel.Collections.Immutable.IImmutableSet<T> Clear();

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

        /// <summary>
        /// Removes the elements in the specified collection from the current immutable set.
        /// </summary>
        /// <param name="other">
        /// The collection of items to remove from this set.
        /// </param>
        /// <returns>
        /// A new set with the items removed; or the original set if none of the items were in the set.
        /// </returns>
        new Drexel.Collections.Immutable.IImmutableSet<T> Except(IEnumerable<T> other);

        /// <summary>
        /// Creates an immutable set that contains only elements that exist in this set and the specified set.
        /// </summary>
        /// <param name="other">
        /// The collection to compare to the current <see cref="Drexel.Collections.Immutable.IImmutableSet{T}"/>.
        /// </param>
        /// <returns>
        /// A new immutable set that contains elements that exist in both sets.
        /// </returns>
        new Drexel.Collections.Immutable.IImmutableSet<T> Intersect(IEnumerable<T> other);

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

        /// <summary>
        /// Removes the specified element from this immutable set.
        /// </summary>
        /// <param name="value">
        /// The element to remove.
        /// </param>
        /// <returns>
        /// A new set with the specified element removed, or the current set if the element cannot be found in the set.
        /// </returns>
        new Drexel.Collections.Immutable.IImmutableSet<T> Remove(T value);

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

        /// <summary>
        /// Creates an immutable set that contains only elements that are present either in the current set or in the
        /// specified collection, but not both.
        /// </summary>
        /// <param name="other">
        /// The collection to compare to the current set.
        /// </param>
        /// <returns>
        /// A new set that contains the elements that are present only in the current set or in the specified
        /// collection, but not both.
        /// </returns>
        new Drexel.Collections.Immutable.IImmutableSet<T> SymmetricExcept(IEnumerable<T> other);

        /// <summary>
        /// Creates a new immutable set that contains all elements that are present in either the current set or in the
        /// specified collection.
        /// </summary>
        /// <param name="other">
        /// The collection to add elements from.
        /// </param>
        /// <returns>
        /// A new immutable set with the items added; or the original set if all the items were already in the set.
        /// </returns>
        new Drexel.Collections.Immutable.IImmutableSet<T> Union(IEnumerable<T> other);
    }
}
