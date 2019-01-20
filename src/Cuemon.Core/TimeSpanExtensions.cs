﻿using System;

namespace Cuemon
{
    /// <summary>
    /// Extension methods for the <see cref="TimeSpan"/> structure.
    /// </summary>
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Represents the number of ticks in 1 nanosecond. This field is constant.
        /// </summary>
        public const double TicksPerNanosecond = 0.01;

        /// <summary>
        /// Represents the number of ticks in 1 microsecond. This field is constant.
        /// </summary>
        public const double TicksPerMicrosecond = TicksPerNanosecond * 1000;

        /// <summary>
        /// Gets the total number of nanoseconds represented by the specified <see cref="TimeSpan"/> structure.
        /// </summary>
        /// <param name="ts">The <see cref="TimeSpan"/> to extend.</param>
        /// <returns>The total number of nanoseconds represented by the specified <see cref="TimeSpan"/> structure.</returns>
        public static double GetTotalNanoseconds(this TimeSpan ts)
        {
            return ts.Ticks / TicksPerNanosecond;
        }

        /// <summary>
        /// Gets the nanoseconds of the time interval represented by the specified <see cref="TimeSpan"/> structure.
        /// </summary>
        /// <param name="ts">The <see cref="TimeSpan"/> to extend with a nanoseconds component.</param>
        /// <returns>The nanoseconds component by the specified <see cref="TimeSpan"/> structure. The return value ranges from -999 through 999.</returns>
        public static int GetNanoseconds(this TimeSpan ts)
        {
            return (int)(GetTotalNanoseconds(ts) % 1000);
        }

        /// <summary>
        /// Gets the total number of microseconds represented by the specified <see cref="TimeSpan"/> structure.
        /// </summary>
        /// <param name="ts">The <see cref="TimeSpan"/> to extend.</param>
        /// <returns>The total number of microseconds represented by the specified <see cref="TimeSpan"/> structure.</returns>
        public static double GetTotalMicroseconds(this TimeSpan ts)
        {
            return ts.Ticks / TicksPerMicrosecond;
        }

        /// <summary>
        /// Gets the microseconds of the time interval represented by the specified <see cref="TimeSpan"/> structure.
        /// </summary>
        /// <param name="ts">The <see cref="TimeSpan"/> to extend with a microseconds component.</param>
        /// <returns>The millisecond component by the specified <see cref="TimeSpan"/> structure. The return value ranges from -999 through 999.</returns>
        public static int GetMicroseconds(this TimeSpan ts)
        {
            return (int)(GetTotalMicroseconds(ts) % 1000);
        }

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> value that is rounded towards negative infinity.
        /// </summary>
        /// <param name="value">A <see cref="TimeSpan"/> value to be rounded.</param>
        /// <param name="interval">The <see cref="TimeSpan"/> value that specifies the rounding of <paramref name="value"/>.</param>
        /// <returns>A <see cref="TimeSpan"/> value that is rounded towards negative infinity.</returns>
        public static TimeSpan Floor(this TimeSpan value, TimeSpan interval)
        {
            return Round(value, interval, VerticalDirection.Down);
        }

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> value that is rounded towards positive infinity.
        /// </summary>
        /// <param name="value">A <see cref="TimeSpan"/> value to be rounded.</param>
        /// <param name="interval">The <see cref="TimeSpan"/> value that specifies the rounding of <paramref name="value"/>.</param>
        /// <returns>A <see cref="TimeSpan"/> value that is rounded towards positive infinity.</returns>
        public static TimeSpan Ceiling(this TimeSpan value, TimeSpan interval)
        {
            return Round(value, interval, VerticalDirection.Up);
        }

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> value that is rounded towards negative infinity.
        /// </summary>
        /// <param name="value">A <see cref="TimeSpan"/> value to be rounded.</param>
        /// <param name="interval">The <see cref="double"/> value that in combination with <paramref name="timeUnit"/> specifies the rounding of <paramref name="value"/>.</param>
        /// <param name="timeUnit">One of the enumeration values that specifies the time unit of <paramref name="interval"/>.</param>
        /// <returns>A <see cref="TimeSpan"/> value that is rounded towards negative infinity.</returns>
        public static TimeSpan Floor(this TimeSpan value, double interval, TimeUnit timeUnit)
        {
            return Round(value, interval, timeUnit, VerticalDirection.Down);
        }

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> value that is rounded towards positive infinity.
        /// </summary>
        /// <param name="value">A <see cref="TimeSpan"/> value to be rounded.</param>
        /// <param name="interval">The <see cref="double"/> value that in combination with <paramref name="timeUnit"/> specifies the rounding of <paramref name="value"/>.</param>
        /// <param name="timeUnit">One of the enumeration values that specifies the time unit of <paramref name="interval"/>.</param>
        /// <returns>A <see cref="TimeSpan"/> value that is rounded towards positive infinity.</returns>
        public static TimeSpan Ceiling(this TimeSpan value, double interval, TimeUnit timeUnit)
        {
            return Round(value, interval, timeUnit, VerticalDirection.Up);
        }

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> value that is rounded either towards negative infinity or positive infinity.
        /// </summary>
        /// <param name="value">A <see cref="TimeSpan"/> value to be rounded.</param>
        /// <param name="interval">The <see cref="double"/> value that in combination with <paramref name="timeUnit"/> specifies the rounding of <paramref name="value"/>.</param>
        /// <param name="timeUnit">One of the enumeration values that specifies the time unit of <paramref name="interval"/>.</param>
        /// <param name="direction">One of the enumeration values that specifies the direction of the rounding.</param>
        /// <returns>A <see cref="TimeSpan"/> value that is rounded either towards negative infinity or positive infinity.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="direction"/> is an invalid enumeration value.
        /// </exception>
        public static TimeSpan Round(this TimeSpan value, double interval, TimeUnit timeUnit, VerticalDirection direction)
        {
            return Round(value, TimeSpanConverter.FromDouble(interval, timeUnit), direction);
        }

        /// <summary>
        /// Returns a <see cref="TimeSpan"/> value that is rounded either towards negative infinity or positive infinity.
        /// </summary>
        /// <param name="value">A <see cref="TimeSpan"/> value to be rounded.</param>
        /// <param name="interval">The <see cref="TimeSpan"/> value that specifies the rounding of <paramref name="value"/>.</param>
        /// <param name="direction">One of the enumeration values that specifies the direction of the rounding.</param>
        /// <returns>A <see cref="TimeSpan"/> value that is rounded either towards negative infinity or positive infinity.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="direction"/> is an invalid enumeration value.
        /// </exception>
        public static TimeSpan Round(this TimeSpan value, TimeSpan interval, VerticalDirection direction)
        {
            long valueTicks = interval < TimeSpan.Zero ? value.Add(interval).Ticks : value.Ticks;
            long absoluteIntervalTicks = Math.Abs(interval.Ticks);
            long remainder = valueTicks % absoluteIntervalTicks;
            switch (direction)
            {
                case VerticalDirection.Up:
                    long adjustment = (absoluteIntervalTicks - (remainder)) % absoluteIntervalTicks;
                    return new TimeSpan(valueTicks + adjustment);
                case VerticalDirection.Down:
                    return new TimeSpan(valueTicks - remainder);
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction));
            }
        }
    }
}