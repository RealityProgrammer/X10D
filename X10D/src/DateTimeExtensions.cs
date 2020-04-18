﻿namespace X10D
{
    using System;

    /// <summary>
    /// Extension methods for <see cref="DateTime"/>.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Calculates someone's age based on a date of birth.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        public static int Age(this DateTime dateOfBirth)
        {
            return (int) (((DateTime.Today - TimeSpan.FromDays(1) - dateOfBirth.Date).TotalDays + 1) / 365.2425);
        }

        /// <summary>
        /// Gets a DateTime representing the first specified day in the current month
        /// </summary>
        /// <param name="current">The current day</param>
        /// <param name="dayOfWeek">The current day of week</param>
        /// <returns></returns>
        public static DateTime First(this DateTime current, DayOfWeek dayOfWeek)
        {
            DateTime first = current.FirstDayOfMonth();

            if (first.DayOfWeek != dayOfWeek)
            {
                first = first.Next(dayOfWeek);
            }

            return first;
        }

        /// <summary>
        /// Gets a <see cref="DateTime"/> representing the first day in the current month.
        /// </summary>
        /// <param name="current">The current date.</param>
        public static DateTime FirstDayOfMonth(this DateTime current)
        {
            return current.AddDays(1 - current.Day);
        }

        /// <summary>
        /// Gets a <see cref="DateTime"/> representing the last day in the current month.
        /// </summary>
        /// <param name="current">The current date.</param>
        public static DateTime LastDayOfMonth(this DateTime current)
        {
            int daysInMonth = DateTime.DaysInMonth(current.Year, current.Month);

            DateTime last = current.FirstDayOfMonth().AddDays(daysInMonth - 1);
            return last;
        }

        /// <summary>
        /// Gets a <see cref="DateTime"/> representing the last specified day in the current month.
        /// </summary>
        /// <param name="current">The current date.</param>
        /// <param name="dayOfWeek">The current day of week.</param>
        public static DateTime Last(this DateTime current, DayOfWeek dayOfWeek)
        {
            DateTime  last          = current.LastDayOfMonth();
            DayOfWeek lastDayOfWeek = last.DayOfWeek;

            int diff = -Math.Abs(dayOfWeek - lastDayOfWeek);
            return last.AddDays(diff);
        }

        /// <summary>
        /// Gets a <see cref="DateTime"/> representing midnight on the current date.
        /// </summary>
        /// <param name="current">The current date.</param>
        [Obsolete(
            "This method has been deprecated in favor of Humanizer's fluent DateTime API. " +
            "Please consider downloading the Humanizer package for more stable implementations of this method."
        )]
        public static DateTime Midnight(this DateTime current)
        {
            return new DateTime(current.Year, current.Month, current.Day, 0, 0, 0);
        }

        /// <summary>
        /// Gets a <see cref="DateTime"/> representing the first date following the current date which falls on the
        /// given day of the week.
        /// </summary>
        /// <param name="current">The current date.</param>
        /// <param name="dayOfWeek">The day of week for the next date to get.</param>
        public static DateTime Next(this DateTime current, DayOfWeek dayOfWeek)
        {
            int offsetDays = dayOfWeek - current.DayOfWeek;

            if (offsetDays <= 0)
            {
                offsetDays += 7;
            }

            DateTime result = current.AddDays(offsetDays);
            return result;
        }

        /// <summary>
        /// Gets a <see cref="DateTime"/> representing noon on the current date.
        /// </summary>
        /// <param name="current">The current date.</param>
        [Obsolete(
            "This method has been deprecated in favor of Humanizer's fluent DateTime API. " +
            "Please consider downloading the Humanizer package for more stable implementations of this method."
        )]
        public static DateTime Noon(this DateTime current)
        {
            return new DateTime(current.Year, current.Month, current.Day, 12, 0, 0);
        }

        /// <summary>
        /// Converts the <see cref="DateTime"/> to a Unix timestamp.
        /// </summary>
        /// <param name="time">The <see cref="DateTime"/> instance.</param>
        /// <param name="useMillis">Optional. Whether or not the return value should be represented as milliseconds.
        /// Defaults to <see langword="false"/>.</param>
        /// <returns>Returns a Unix timestamp representing the provided <see cref="DateTime"/>.</returns>
        public static long ToUnixTimeStamp(this DateTime time, bool useMillis = false)
        {
            DateTimeOffset offset = time;
            return useMillis ? offset.ToUnixTimeMilliseconds() : offset.ToUnixTimeSeconds();
        }
    }
}