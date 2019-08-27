using System.Collections.Generic;

namespace Drexel.Collections.Generic
{
    /// <summary>
    /// Represents a strongly-typed, read-only collection of elements that contains no duplicates. The meaning of
    /// "duplicate" depends on the implementation of this interface.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the elements.
    /// </typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Naming",
        "CA1710:Identifiers should have correct suffix",
        Justification = "Naming inherited from existing convention.")]
    public interface IReadOnlySet<out T> : IReadOnlyCollection<T>
    {
    }
}
