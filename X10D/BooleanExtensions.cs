﻿namespace X10D
{
    #region Using Directives

    using System;

    #endregion

    /// <summary>
    /// Extension methods for <see cref="Boolean"/>.
    /// </summary>
    public static class BooleanExtensions
    {
        /// <summary>
        /// Gets an integer value that represents this boolean.
        /// </summary>
        /// <param name="value">The boolean.</param>
        /// <returns>Returns 1 if <paramref name="value"/> is <see langword="true"/>, 0 otherwise.</returns>
        public static int ToInt32(this bool value) =>
            value ? 1 : 0;
    }
}