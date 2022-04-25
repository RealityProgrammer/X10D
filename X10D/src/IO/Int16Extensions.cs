﻿using System.Buffers.Binary;

namespace X10D.IO;

/// <summary>
///     IO-related extension methods for <see cref="short" />.
/// </summary>
public static class Int16Extensions
{
    /// <summary>
    ///     Returns the current 16-bit signed integer value as an array of bytes.
    /// </summary>
    /// <param name="value">The number to convert.</param>
    /// <returns>An array of bytes with length 2.</returns>
    public static byte[] GetBytes(this short value)
    {
        Span<byte> buffer = stackalloc byte[2];
        value.TryWriteBytes(buffer);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Returns the current 16-bit signed integer value as an array of bytes.
    /// </summary>
    /// <param name="value">The number to convert.</param>
    /// <param name="endianness">The endianness with which to write the bytes.</param>
    /// <returns>An array of bytes with length 2.</returns>
    public static byte[] GetBytes(this short value, Endianness endianness)
    {
        Span<byte> buffer = stackalloc byte[2];
        value.TryWriteBytes(buffer, endianness);
        return buffer.ToArray();
    }

    /// <summary>
    ///     Converts the current 16-bit signed integer into a span of bytes.
    /// </summary>
    /// <param name="value">The <see cref="short" /> value.</param>
    /// <param name="destination">When this method returns, the bytes representing the converted <see cref="short" />.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBytes(this short value, Span<byte> destination)
    {
        return BitConverter.TryWriteBytes(destination, value);
    }

    /// <summary>
    ///     Converts the current 16-bit signed integer into a span of bytes.
    /// </summary>
    /// <param name="value">The <see cref="short" /> value.</param>
    /// <param name="destination">When this method returns, the bytes representing the converted <see cref="short" />.</param>
    /// <param name="endianness">The endianness with which to write the bytes.</param>
    /// <returns><see langword="true" /> if the conversion was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryWriteBytes(this short value, Span<byte> destination, Endianness endianness)
    {
        return endianness == Endianness.BigEndian
            ? BinaryPrimitives.TryWriteInt16BigEndian(destination, value)
            : BinaryPrimitives.TryWriteInt16LittleEndian(destination, value);
    }
}
