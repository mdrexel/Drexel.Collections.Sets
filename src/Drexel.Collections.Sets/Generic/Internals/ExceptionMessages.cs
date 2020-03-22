using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Drexel.Collections.Generic.Internals
{
    /// <summary>
    /// Contains exception messages.
    /// </summary>
    internal static class ExceptionMessages
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Design",
            "CA1031:Do not catch general exception types",
            Justification = "Intentionally raising exceptions, and we don't want the constructor to fail.")]
        static ExceptionMessages()
        {
            // Set some sane default messages in English, in case sussing out the system ones fails.
            ExceptionMessages.CollectionIsReadOnly =
                "Collection is read-only.";
            ExceptionMessages.ArrayIndexBelowLowerBound =
                "Number was less than the array's lower bound in the first dimension.";
            ExceptionMessages.DestinationArrayNotLongEnough =
                "Destination array was not long enough. Check destIndex and length, and the array's lower bounds.";

            IList<string> readOnlyCollection = new ReadOnlyCollection<string>(
                new List<string>()
                {
                    "Foo",
                    "Bar",
                    "Baz",
                    "Bazinga"
                });

            try
            {
                readOnlyCollection.Add("asdf");
            }
            catch (NotSupportedException e)
            {
                ExceptionMessages.CollectionIsReadOnly = e.Message;
            }
            catch (Exception)
            {
                // Not expected - swallow it.
            }

            try
            {
                readOnlyCollection.CopyTo(new string[5], -1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                ExceptionMessages.ArrayIndexBelowLowerBound = e.Message;
            }
            catch (Exception)
            {
                // Not expected - swallow it.
            }

            try
            {
                readOnlyCollection.CopyTo(new string[3], 0);
            }
            catch (ArgumentException e)
            {
                ExceptionMessages.DestinationArrayNotLongEnough = e.Message;
            }
            catch (Exception)
            {
                // Not expected - swallow it.
            }
        }

#pragma warning disable SA1629 // Documentation text should end with a period
        /// <summary>
        /// Gets a message like, "Number was less than the array's lower bound in the first dimension."
        /// </summary>
        public static string ArrayIndexBelowLowerBound { get; }

        /// <summary>
        /// Gets a message like, "Collection is read-only."
        /// </summary>
        public static string CollectionIsReadOnly { get; }

        /// <summary>
        /// Gets a message like, "Destination array was not long enough. Check destIndex and length, and the array's lower bounds."
        /// </summary>
        public static string DestinationArrayNotLongEnough { get; }
#pragma warning restore SA1629 // Documentation text should end with a period
    }
}
