# Drexel.Collections.Sets
These libraries define set-related collection interfaces.

## Motivation
Although there is already an `ISet<T>` interface defined in `System.Collections.Generic`, there is no corresponding `IReadOnlySet<T>` interface. This makes it impossible to define type contracts that expose sets in a generic, read-only, type-safe fashion.

## Solution
These libraries are drop-in replacements for the sets defined by `System.Collections.Generic` and `System.Collections.Immutable`, and include set interfaces derived from two new interfaces, `IReadOnlySet<out T>` and `IReadOnlyInvariantSet<T>`. `IReadOnlySet<out T>` is covariant on `T`, which means that it cannot define some methods typically expected on sets (such as `Contains(T)`). `IReadOnlyInvariantSet<T>` defines these methods.

Although the existing `System.Collections.Immutable` classes could be considered "read-only" (as they have no methods that mutate their state), contracts typed using `IReadOnlyInvariantSet<T>` should be able to accept `IImmutableSet<T>`. This requires us to re-define the immutable contracts with no changes (besides inheriting from `IReadOnlyInvariantSet<T>`).

## Usage
You can utilize `Drexel.Collections.Generic.ISet<T>` and `Drexel.Collections.Immutable.IImmutableSet<T>` as drop-in replacements for their corresponding `System.Collections` interfaces. This will give you access to the new interfaces `Drexel.Collections.Generic.IReadOnlySet<out T>` and `Drexel.Collections.Generic.IReadOnlyInvariantSet<T>`.

You can convert a `System.Collections.Generic.ISet<T>` to a `Drexel.Collections.Generic.ISet<T>` by using the `Drexel.Collections.Generic.SetAdapter<T>` class; similarly, you can convert a `System.Collections.Immutable.IImmutableSet<T>` to a `Drexel.Collections.Immutable.IImmutableSet<T>` using the `Drexel.Collections.Immutable.ImmutableSetAdapter<T>` class.

The `Drexel.Collections.ObjectModel.ReadOnlySet<T>` and `Drexel.Collections.ObjectModel.ReadOnlyInvariantSet<T>` classes operates akin to the `System.Collections.ObjectModel` namespace's classes, allowing you to wrap a `Drexel.Collections.Generic.IReadOnlySet<T>` or `Drexel.Collections.Generic.IReadOnlyInvariantSet<T>` in a read-only layer (to prevent external users from trivially bypassing your read-only contract by casting your returned sets.)