using System;
using System.Collections;
using System.Collections.Generic;

namespace Drexel.Collections.Immutable
{
    /// <summary>
    /// Adapts a <see cref="System.Collections.Immutable.IImmutableSet{T}"/> to a
    /// <see cref="Drexel.Collections.Immutable.IImmutableSet{T}"/>.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the elements contained by the set.
    /// </typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Naming",
        "CA1710:Identifiers should have correct suffix",
        Justification = "Naming inherited from Adapter pattern.")]
    public sealed class ImmutableSetAdapter<T> :
        Drexel.Collections.Immutable.IImmutableSet<T>,
        IEquatable<Drexel.Collections.Immutable.IImmutableSet<T>>,
        IEquatable<System.Collections.Immutable.IImmutableSet<T>>
    {
#pragma warning disable CA1823 // Unused field. False positive - this field is used.
        private const ImmutableSetAdapter<T>? InitialClearSetValue = default;
#pragma warning restore CA1823 // Unused field.
        private ImmutableSetAdapter<T>? clearSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImmutableSetAdapter{T}"/> class.
        /// </summary>
        /// <param name="set">
        /// The set to adapt.
        /// </param>
        public ImmutableSetAdapter(System.Collections.Immutable.IImmutableSet<T> set)
        {
            this.Set = set ?? throw new ArgumentNullException(nameof(set));
            this.clearSet = ImmutableSetAdapter<T>.InitialClearSetValue;
        }

        /// <summary>
        /// Gets the underlying <see cref="System.Collections.Immutable.IImmutableSet{T}"/> this adapter is adapting.
        /// </summary>
        public System.Collections.Immutable.IImmutableSet<T> Set { get; }

        /// <inheritdoc/>
        public int Count => this.Set.Count;

        /// <inheritdoc/>
        public IImmutableSet<T> Add(T value)
        {
            System.Collections.Immutable.IImmutableSet<T> newSet = this.Set.Add(value);
            if (object.ReferenceEquals(newSet, this.Set))
            {
                return this;
            }
            else
            {
                return new ImmutableSetAdapter<T>(newSet);
            }
        }

        /// <inheritdoc/>
        public IImmutableSet<T> Clear()
        {
            if (object.ReferenceEquals(this.clearSet, ImmutableSetAdapter<T>.InitialClearSetValue))
            {
                this.clearSet = new ImmutableSetAdapter<T>(this.Set.Clear());
            }

#pragma warning disable CS8603 // Possible null reference return. It isn't realizing we ensured it's non-null.
            return this.clearSet;
#pragma warning restore CS8603 // Possible null reference return.
        }

        /// <inheritdoc/>
        public bool Contains(T item)
        {
            return this.Set.Contains(item);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Drexel.Collections.Immutable.IImmutableSet<T> asDrexelSet)
            {
                return this.Equals(asDrexelSet);
            }
            else if (obj is System.Collections.Immutable.IImmutableSet<T> asSystemSet)
            {
                return this.Equals(asSystemSet);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool Equals(IImmutableSet<T> other)
        {
            return base.Equals(other);
        }

        /// <inheritdoc/>
        public bool Equals(System.Collections.Immutable.IImmutableSet<T> other)
        {
            return this.Set.Equals(other);
        }

        /// <inheritdoc/>
        public IImmutableSet<T> Except(IEnumerable<T> other)
        {
            System.Collections.Immutable.IImmutableSet<T> newSet = this.Set.Except(other);
            if (object.ReferenceEquals(newSet, this.Set))
            {
                return this;
            }
            else
            {
                return new ImmutableSetAdapter<T>(newSet);
            }
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            return this.Set.GetEnumerator();
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <inheritdoc/>
        public IImmutableSet<T> Intersect(IEnumerable<T> other)
        {
            return new ImmutableSetAdapter<T>(this.Set.Intersect(other));
        }

        /// <inheritdoc/>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            return this.Set.IsProperSubsetOf(other);
        }

        /// <inheritdoc/>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            return this.Set.IsProperSupersetOf(other);
        }

        /// <inheritdoc/>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            return this.Set.IsSubsetOf(other);
        }

        /// <inheritdoc/>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            return this.Set.IsSupersetOf(other);
        }

        /// <inheritdoc/>
        public bool Overlaps(IEnumerable<T> other)
        {
            return this.Set.Overlaps(other);
        }

        /// <inheritdoc/>
        public IImmutableSet<T> Remove(T value)
        {
            System.Collections.Immutable.IImmutableSet<T> newSet = this.Set.Remove(value);
            if (object.ReferenceEquals(newSet, this.Set))
            {
                return this;
            }
            else
            {
                return new ImmutableSetAdapter<T>(newSet);
            }
        }

        /// <inheritdoc/>
        public bool SetEquals(IEnumerable<T> other)
        {
            return this.Set.SetEquals(other);
        }

        /// <inheritdoc/>
        public IImmutableSet<T> SymmetricExcept(IEnumerable<T> other)
        {
            return new ImmutableSetAdapter<T>(this.Set.SymmetricExcept(other));
        }

        /// <inheritdoc/>
        public bool TryGetValue(T equalValue, out T actualValue)
        {
            return this.Set.TryGetValue(equalValue, out actualValue);
        }

        /// <inheritdoc/>
        public IImmutableSet<T> Union(IEnumerable<T> other)
        {
            System.Collections.Immutable.IImmutableSet<T> newSet = this.Set.Union(other);
            if (object.ReferenceEquals(newSet, this.Set))
            {
                return this;
            }
            else
            {
                return new ImmutableSetAdapter<T>(newSet);
            }
        }

        /// <inheritdoc/>
        System.Collections.Immutable.IImmutableSet<T> System.Collections.Immutable.IImmutableSet<T>.Add(T value) =>
            this.Set.Add(value);

        /// <inheritdoc/>
        System.Collections.Immutable.IImmutableSet<T> System.Collections.Immutable.IImmutableSet<T>.Clear() =>
            this.Set.Clear();

        /// <inheritdoc/>
        System.Collections.Immutable.IImmutableSet<T> System.Collections.Immutable.IImmutableSet<T>.Except(IEnumerable<T> other) =>
            this.Set.Except(other);

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        /// <inheritdoc/>
        System.Collections.Immutable.IImmutableSet<T> System.Collections.Immutable.IImmutableSet<T>.Intersect(IEnumerable<T> other) =>
            this.Set.Intersect(other);

        /// <inheritdoc/>
        System.Collections.Immutable.IImmutableSet<T> System.Collections.Immutable.IImmutableSet<T>.Remove(T value) =>
            this.Set.Remove(value);

        /// <inheritdoc/>
        System.Collections.Immutable.IImmutableSet<T> System.Collections.Immutable.IImmutableSet<T>.SymmetricExcept(IEnumerable<T> other) =>
            this.Set.SymmetricExcept(other);

        /// <inheritdoc/>
        System.Collections.Immutable.IImmutableSet<T> System.Collections.Immutable.IImmutableSet<T>.Union(IEnumerable<T> other) =>
            this.Set.Union(other);
    }
}
