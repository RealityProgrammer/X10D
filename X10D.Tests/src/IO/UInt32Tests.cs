﻿using NUnit.Framework;
using X10D.IO;

namespace X10D.Tests.IO;

[TestFixture]
internal class UInt32Tests
{
    [Test]
    public void GetLittleEndianBytes_ReturnsCorrectValue_WithEndianness()
    {
        const uint value = 0x0F;
        byte[] expected = { 0x0F, 0, 0, 0 };
        byte[] actual = value.GetLittleEndianBytes();

        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void GetBigEndianBytes_ReturnsCorrectValue_WithEndianness()
    {
        const uint value = 0x0F;
        byte[] expected = { 0, 0, 0, 0x0F };
        byte[] actual = value.GetBigEndianBytes();

        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void TryWriteLittleEndian_ReturnsTrue_FillsSpanCorrectly_GivenLargeEnoughSpan()
    {
        const uint value = 0x0F;
        byte[] expected = { 0x0F, 0, 0, 0 };

        Span<byte> actual = stackalloc byte[4];
        Assert.That(value.TryWriteLittleEndianBytes(actual));

        CollectionAssert.AreEqual(expected, actual.ToArray());
    }

    [Test]
    public void TryWriteBigEndian_ReturnsTrue_FillsSpanCorrectly_GivenLargeEnoughSpan()
    {
        const uint value = 0x0F;
        byte[] expected = { 0, 0, 0, 0x0F };

        Span<byte> actual = stackalloc byte[4];
        Assert.That(value.TryWriteBigEndianBytes(actual));

        CollectionAssert.AreEqual(expected, actual.ToArray());
    }

    [Test]
    public void TryWriteLittleEndian_RReturnsFalse_GivenSmallSpan()
    {
        const uint value = 0x0F;
        Span<byte> buffer = stackalloc byte[0];
        Assert.That(value.TryWriteLittleEndianBytes(buffer), Is.False);
    }

    [Test]
    public void TryWriteBigEndian_ReturnsFalse_GivenSmallSpan()
    {
        const uint value = 0x0F;
        Span<byte> buffer = stackalloc byte[0];
        Assert.That(value.TryWriteBigEndianBytes(buffer), Is.False);
    }
}
