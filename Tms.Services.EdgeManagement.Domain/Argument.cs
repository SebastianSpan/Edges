using Microsoft;
using System;

namespace Tms
{
    /// <summary>
    /// Provides methodes to check argument values.
    /// </summary>
    public static class Argument
    {
        /// <summary>
        /// Checks, if the given value is null.
        /// </summary>
        /// <param name="argumentName">Name of the argument</param>
        /// <param name="value">Value of the argument</param>
        public static void ThrowIfNull(string argumentName, [ValidatedNotNull] object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        /// <summary>
        /// Checks if the given value is null or empty.
        /// </summary>
        /// <param name="argumentName"></param>
        /// <param name="value"></param>
        public static void ThrowIfNullOrEmpty(string argumentName, [ValidatedNotNull] string value)
        {
            ThrowIfNull(argumentName, value);

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"Parameter {argumentName} is empty.");
            }
        }

        /// <summary>
        /// Checks if the given value is null or whitespace.
        /// </summary>
        /// <param name="argumentName"></param>
        /// <param name="value"></param>
        public static void ThrowIfNullOrWhitespace(string argumentName, [ValidatedNotNull] string value)
        {
            ThrowIfNull(argumentName, value);

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"Parameter {argumentName} is empty.");
            }
        }
    }
}
