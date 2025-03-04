using System.Diagnostics.Contracts;

namespace X10D.Collections;

/// <summary>
///     Collection-related extension methods for <see cref="long" />.
/// </summary>
public static class Int64Extensions
{
    private const int Size = sizeof(long) * 8;

    /// <summary>
    ///     Unpacks this 64-bit signed integer into a boolean list, treating it as a bit field.
    /// </summary>
    /// <param name="value">The value to unpack.</param>
    /// <returns>An array of <see cref="bool" /> with length 64.</returns>
    [Pure]
    public static bool[] Unpack(this long value)
    {
        var ret = new bool[Size];
        value.Unpack(ret);
        return ret;
    }

    /// <summary>
    ///     Unpacks this 64-bit signed integer into a boolean list, treating it as a bit field.
    /// </summary>
    /// <param name="value">The value to unpack.</param>
    /// <param name="destination">When this method returns, contains the unpacked booleans from <paramref name="value" />.</param>
    /// <exception cref="ArgumentException"><paramref name="destination" /> is not large enough to contain the result.</exception>
    public static void Unpack(this long value, Span<bool> destination)
    {
        if (destination.Length < Size)
        {
            throw new ArgumentException(ExceptionMessages.DestinationSpanLengthTooShort, nameof(destination));
        }

        for (var index = 0; index < Size; index++)
        {
            destination[index] = (value & (1L << index)) != 0;
        }
    }
}
