using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using X10D.CompilerServices;

namespace X10D.Time;

/// <summary>
///     Time-related extension methods for <see cref="uint" />.
/// </summary>
[CLSCompliant(false)]
public static class UInt32Extensions
{
    /// <summary>
    ///     Converts a Unix time expressed as the number of milliseconds that have elapsed since 1970-01-01T00:00:00Z to a
    ///     <see cref="DateTimeOffset" /> value.
    /// </summary>
    /// <param name="value">
    ///     A Unix time, expressed as the number of milliseconds that have elapsed since 1970-01-01T00:00:00Z (January 1,
    ///     1970, at 12:00 AM UTC). For Unix times before this date, its value is negative.
    /// </param>
    /// <returns>A date and time value that represents the same moment in time as the Unix time.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <para><paramref name="value" /> is less than -62,135,596,800,000.</para>
    ///     -or-
    ///     <para><paramref name="value" /> is greater than 253,402,300,799,999.</para>
    /// </exception>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static DateTimeOffset FromUnixTimeMilliseconds(this uint value)
    {
        return DateTimeOffset.FromUnixTimeMilliseconds(value);
    }

    /// <summary>
    ///     Converts a Unix time expressed as the number of seconds that have elapsed since 1970-01-01T00:00:00Z to a
    ///     <see cref="DateTimeOffset" /> value.
    /// </summary>
    /// <param name="value">
    ///     A Unix time, expressed as the number of seconds that have elapsed since 1970-01-01T00:00:00Z (January 1, 1970, at
    ///     12:00 AM UTC). For Unix times before this date, its value is negative.
    /// </param>
    /// <returns>A date and time value that represents the same moment in time as the Unix time.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <para><paramref name="value" /> is less than -62,135,596,800.</para>
    ///     -or-
    ///     <para><paramref name="value" /> is greater than 253,402,300,799.</para>
    /// </exception>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static DateTimeOffset FromUnixTimeSeconds(this uint value)
    {
        return DateTimeOffset.FromUnixTimeSeconds(value);
    }

    /// <summary>
    ///     Returns a value indicating whether the current integer, representing a year, is a leap year.
    /// </summary>
    /// <param name="value">The value whose leap year status to check.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> refers to a leap year; otherwise, <see langword="false" />.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="value" /> is 0.</exception>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static bool IsLeapYear(this uint value)
    {
        if (value == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), ExceptionMessages.YearCannotBeZero);
        }

        return value % 4 == 0 && (value % 100 != 0 || value % 400 == 0);
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of ticks.
    /// </summary>
    /// <param name="value">The duration, in ticks.</param>
    /// <returns>A <see cref="TimeSpan" /> whose <see cref="TimeSpan.Ticks" /> will equal <paramref name="value" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static TimeSpan Ticks(this uint value)
    {
        return TimeSpan.FromTicks(value);
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of milliseconds.
    /// </summary>
    /// <param name="value">The duration, in milliseconds.</param>
    /// <returns>
    ///     A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalMilliseconds" /> will equal <paramref name="value" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static TimeSpan Milliseconds(this uint value)
    {
        return TimeSpan.FromMilliseconds(value);
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of seconds.
    /// </summary>
    /// <param name="value">The duration, in seconds.</param>
    /// <returns>
    ///     A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalSeconds" /> will equal <paramref name="value" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static TimeSpan Seconds(this uint value)
    {
        return TimeSpan.FromSeconds(value);
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of minutes.
    /// </summary>
    /// <param name="value">The duration, in minutes.</param>
    /// <returns>
    ///     A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalMinutes" /> will equal <paramref name="value" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static TimeSpan Minutes(this uint value)
    {
        return TimeSpan.FromMinutes(value);
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of hours.
    /// </summary>
    /// <param name="value">The duration, in hours.</param>
    /// <returns>
    ///     A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalHours" /> will equal <paramref name="value" />.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static TimeSpan Hours(this uint value)
    {
        return TimeSpan.FromHours(value);
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of days.
    /// </summary>
    /// <param name="value">The duration, in days.</param>
    /// <returns>A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalDays" /> will equal <paramref name="value" />.</returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static TimeSpan Days(this uint value)
    {
        return TimeSpan.FromDays(value);
    }

    /// <summary>
    ///     Returns a <see cref="TimeSpan" /> that represents this value as the number of weeks.
    /// </summary>
    /// <param name="value">The duration, in weeks.</param>
    /// <returns>
    ///     A <see cref="TimeSpan" /> whose <see cref="TimeSpan.TotalDays" /> will equal <paramref name="value" /> × 7.
    /// </returns>
    [Pure]
    [MethodImpl(CompilerResources.MaxOptimization)]
    public static TimeSpan Weeks(this uint value)
    {
        return TimeSpan.FromDays(value * 7);
    }
}
