using System.Collections.Generic;

namespace Drexel.Collections.Generic
{
    /// <summary>
    /// Represents a strongly-typed collection of elements that contains no duplicates.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the elements.
    /// </typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Naming",
        "CA1710:Identifiers should have correct suffix",
        Justification = "Naming inherited from existing interface.")]
    public interface ISet<T> : IReadOnlyInvariantSet<T>, System.Collections.Generic.ISet<T>
    {
        /// <summary>
        /// Gets the number of elements contained in the <see cref="ISet{T}"/>.
        /// </summary>
        // Need to hide the Count property so that implementors don't have to explicitly implement both the ISet
        // and the IReadOnlyInvariantSet Count properties. This doesn't fix the issue that they could still choose to
        // do so, but I'm going to discount this because of how unlikely it is that it's intentional.
        new int Count { get; }

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
        /// <exception cref="System.NotSupportedException">
        /// Thrown when this method is called on a read-only set.
        /// </exception>
        // Need to hide the Add method because ICollection's Add doesn't return a value, but we want to indicate
        // whether the element was added or not.
        new bool Add(T item);

        /// <summary>
        /// Determines whether the current set contains the specified element.
        /// </summary>
        /// <param name="item">
        /// The element to locate in the current set.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the item is found in the current set; otherwise, <see langword="false"/>.
        /// </returns>
        // Need to hide the Contains method so that implementors don't have to explicitly implement both the
        // ISet and the IReadOnlyInvariantSet Contains methods. This is the same issue as the earlier Count
        // property.
        new bool Contains(T item);

        /// <summary>
        /// Removes all elements in the specified collection from the current set.
        /// </summary>
        /// <param name="other">
        /// The collection of items to remove from the set.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="other"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="System.NotSupportedException">
        /// Thrown when this method is called on a read-only set.
        /// </exception>
        new void ExceptWith(IEnumerable<T> other);

        /// <summary>
        /// Modifies the current set so that it contains only elements that are also in a specified collection.
        /// </summary>
        /// <param name="other">
        /// The collection to compare to the current set.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="other"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="System.NotSupportedException">
        /// Thrown when this method is called on a read-only set.
        /// </exception>
        new void IntersectWith(IEnumerable<T> other);

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
        // Same as above.
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
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="other"/> is <see langword="null"/>.
        /// </exception>
        // Same as above.
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
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="other"/> is <see langword="null"/>.
        /// </exception>
        // Same as above.
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
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="other"/> is <see langword="null"/>.
        /// </exception>
        // Same as above.
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
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="other"/> is <see langword="null"/>.
        /// </exception>
        // Same as above.
        new bool Overlaps(IEnumerable<T> other);

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
        // Same as above.
        new bool SetEquals(IEnumerable<T> other);

        /// <summary>
        /// Modifies the current set so that it contains only elements that are present either in the current set or in
        /// the specified collection, but not both.
        /// </summary>
        /// <param name="other">
        /// The collection to compare to the current set.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="other"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="System.NotSupportedException">
        /// Thrown when this method is called on a read-only set.
        /// </exception>
        // Same as above.
        new void SymmetricExceptWith(IEnumerable<T> other);

        /// <summary>
        /// Modifies the current set so that it contains all elements that are present in the current set, in the
        /// specified collection, or in both.
        /// </summary>
        /// <param name="other">
        /// The collection to compare to the current set.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="other"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="System.NotSupportedException">
        /// Thrown when this method is called on a read-only set.
        /// </exception>
        // Same as above.
        new void UnionWith(IEnumerable<T> other);
    }
}
