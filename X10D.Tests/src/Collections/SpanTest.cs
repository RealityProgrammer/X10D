﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Collections;

namespace X10D.Tests.Collections;

[TestClass]
public class SpanTest
{
    [TestMethod]
    public void Count_ShouldReturn0_GivenEmptySpan()
    {
        Span<int> span = Span<int>.Empty;

        int count = span.Count(2);

        Assert.AreEqual(0, count);
    }

    [TestMethod]
    public void Count_ShouldReturn0_GivenEmptyReadOnlySpan()
    {
        ReadOnlySpan<int> span = ReadOnlySpan<int>.Empty;

        int count = span.Count(2);

        Assert.AreEqual(0, count);
    }

    [TestMethod]
    public void Count_ShouldReturn8_GivenSpanWith8MatchingElements()
    {
        Span<int> span = stackalloc int[16] {1, 2, 3, 2, 5, 2, 7, 2, 9, 2, 11, 2, 13, 2, 15, 2};

        int count = span.Count(2);

        Assert.AreEqual(8, count);
    }

    [TestMethod]
    public void Count_ShouldReturn8_GivenReadOnlySpanWith8MatchingElements()
    {
        ReadOnlySpan<int> span = stackalloc int[16] {1, 2, 3, 2, 5, 2, 7, 2, 9, 2, 11, 2, 13, 2, 15, 2};

        int count = span.Count(2);

        Assert.AreEqual(8, count);
    }

    [TestMethod]
    public void Split_OnEmptySpan_ShouldYieldNothing_UsingCharDelimiter_GivenReadOnlySpan()
    {
        ReadOnlySpan<char> span = ReadOnlySpan<char>.Empty;

        var index = 0;
        foreach (ReadOnlySpan<char> unused in span.Split(' '))
        {
            index++;
        }

        Assert.AreEqual(0, index);
    }

    [TestMethod]
    public void Split_OnEmptySpan_ShouldYieldNothing_UsingCharDelimiter_GivenSpan()
    {
        Span<char> span = Span<char>.Empty;

        var index = 0;
        foreach (ReadOnlySpan<char> unused in span.Split(' '))
        {
            index++;
        }

        Assert.AreEqual(0, index);
    }

    [TestMethod]
    public void Split_OnEmptySpan_ShouldYieldNothing_UsingStringDelimiter_GivenReadOnlySpan()
    {
        ReadOnlySpan<char> span = ReadOnlySpan<char>.Empty;

        var index = 0;
        foreach (ReadOnlySpan<char> unused in span.Split(" "))
        {
            index++;
        }

        Assert.AreEqual(0, index);
    }

    [TestMethod]
    public void Split_OnEmptySpan_ShouldYieldNothing_UsingStringDelimiter_GivenSpan()
    {
        Span<char> span = Span<char>.Empty;

        var index = 0;
        foreach (ReadOnlySpan<char> unused in span.Split(" "))
        {
            index++;
        }

        Assert.AreEqual(0, index);
    }

    [TestMethod]
    public void Split_OnOneWord_ShouldYieldLength1_UsingCharDelimiter_GivenReadOnlySpan()
    {
        ReadOnlySpan<char> span = "Hello ".AsSpan();

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(' '))
        {
            if (index == 0)
            {
                Assert.AreEqual("Hello", subSpan.ToString());
            }

            index++;
        }

        Assert.AreEqual(1, index);
    }

    [TestMethod]
    public void Split_OnOneWord_ShouldYieldLength1_UsingCharDelimiter_GivenSpan()
    {
        ReadOnlySpan<char> source = "Hello ".AsSpan();
        Span<char> span = stackalloc char[source.Length];
        source.CopyTo(span);

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(' '))
        {
            if (index == 0)
            {
                Assert.AreEqual("Hello", subSpan.ToString());
            }

            index++;
        }

        Assert.AreEqual(1, index);
    }

    [TestMethod]
    public void Split_OnOneWord_ShouldYieldLength1_UsingStringDelimiter_GivenReadOnlySpan()
    {
        ReadOnlySpan<char> span = "Hello ".AsSpan();

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(" "))
        {
            if (index == 0)
            {
                Assert.AreEqual("Hello", subSpan.ToString());
            }

            index++;
        }

        Assert.AreEqual(1, index);
    }

    [TestMethod]
    public void Split_OnOneWord_ShouldYieldLength1_UsingStringDelimiter_GivenSpan()
    {
        ReadOnlySpan<char> source = "Hello ".AsSpan();
        Span<char> span = stackalloc char[source.Length];
        source.CopyTo(span);

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(" "))
        {
            if (index == 0)
            {
                Assert.AreEqual("Hello", subSpan.ToString());
            }

            index++;
        }

        Assert.AreEqual(1, index);
    }

    [TestMethod]
    public void Split_OnOneWordWithoutDelimiter_ShouldYieldLength1_UsingCharDelimiter_GivenReadOnlySpan()
    {
        ReadOnlySpan<char> span = "Hello".AsSpan();

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(' '))
        {
            if (index == 0)
            {
                Assert.AreEqual("Hello", subSpan.ToString());
            }

            index++;
        }

        Assert.AreEqual(1, index);
    }

    [TestMethod]
    public void Split_OnOneWordWithoutDelimiter_ShouldYieldLength1_UsingCharDelimiter_GivenSpan()
    {
        ReadOnlySpan<char> source = "Hello".AsSpan();
        Span<char> span = stackalloc char[source.Length];
        source.CopyTo(span);

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(' '))
        {
            if (index == 0)
            {
                Assert.AreEqual("Hello", subSpan.ToString());
            }

            index++;
        }

        Assert.AreEqual(1, index);
    }

    [TestMethod]
    public void Split_OnOneWordWithoutDelimiter_ShouldYieldLength1_UsingStringDelimiter_GivenReadOnlySpan()
    {
        ReadOnlySpan<char> span = "Hello".AsSpan();

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(" "))
        {
            if (index == 0)
            {
                Assert.AreEqual("Hello", subSpan.ToString());
            }

            index++;
        }

        Assert.AreEqual(1, index);
    }

    [TestMethod]
    public void Split_OnOneWordWithoutDelimiter_ShouldYieldLength1_UsingStringDelimiter_GivenSpan()
    {
        ReadOnlySpan<char> source = "Hello".AsSpan();
        Span<char> span = stackalloc char[source.Length];
        source.CopyTo(span);

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(" "))
        {
            if (index == 0)
            {
                Assert.AreEqual("Hello", subSpan.ToString());
            }

            index++;
        }

        Assert.AreEqual(1, index);
    }

    [TestMethod]
    public void Split_OnTwoWords_ShouldYieldLength2_UsingCharDelimiter_GivenReadOnlySpan()
    {
        ReadOnlySpan<char> span = "Hello World ".AsSpan();

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(' '))
        {
            switch (index)
            {
                case 0:
                    Assert.AreEqual("Hello", subSpan.ToString());
                    break;
                case 1:
                    Assert.AreEqual("World", subSpan.ToString());
                    break;
            }

            index++;
        }

        Assert.AreEqual(2, index);
    }

    [TestMethod]
    public void Split_OnTwoWords_ShouldYieldLength2_UsingCharDelimiter_GivenSpan()
    {
        ReadOnlySpan<char> source = "Hello World ".AsSpan();
        Span<char> span = stackalloc char[source.Length];
        source.CopyTo(span);

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(' '))
        {
            switch (index)
            {
                case 0:
                    Assert.AreEqual("Hello", subSpan.ToString());
                    break;
                case 1:
                    Assert.AreEqual("World", subSpan.ToString());
                    break;
            }

            index++;
        }

        Assert.AreEqual(2, index);
    }

    [TestMethod]
    public void Split_OnTwoWords_ShouldYieldLength2_UsingStringDelimiter_GivenReadOnlySpan()
    {
        ReadOnlySpan<char> span = "Hello World ".AsSpan();

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(" "))
        {
            switch (index)
            {
                case 0:
                    Assert.AreEqual("Hello", subSpan.ToString());
                    break;
                case 1:
                    Assert.AreEqual("World", subSpan.ToString());
                    break;
            }

            index++;
        }

        Assert.AreEqual(2, index);
    }

    [TestMethod]
    public void Split_OnTwoWords_ShouldYieldLength2_UsingStringDelimiter_GivenSpan()
    {
        ReadOnlySpan<char> source = "Hello World ".AsSpan();
        Span<char> span = stackalloc char[source.Length];
        source.CopyTo(span);

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(" "))
        {
            switch (index)
            {
                case 0:
                    Assert.AreEqual("Hello", subSpan.ToString());
                    break;
                case 1:
                    Assert.AreEqual("World", subSpan.ToString());
                    break;
            }

            index++;
        }

        Assert.AreEqual(2, index);
    }

    [TestMethod]
    public void Split_OnThreeWords_ShouldYieldLength3_UsingCharDelimiter_GivenReadOnlySpan()
    {
        ReadOnlySpan<char> span = "Hello, the World ".AsSpan();

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(' '))
        {
            switch (index)
            {
                case 0:
                    Assert.AreEqual("Hello,", subSpan.ToString());
                    break;
                case 1:
                    Assert.AreEqual("the", subSpan.ToString());
                    break;
                case 2:
                    Assert.AreEqual("World", subSpan.ToString());
                    break;
            }

            index++;
        }

        Assert.AreEqual(3, index);
    }

    [TestMethod]
    public void Split_OnThreeWords_ShouldYieldLength3_UsingCharDelimiter_GivenSpan()
    {
        ReadOnlySpan<char> source = "Hello, the World ".AsSpan();
        Span<char> span = stackalloc char[source.Length];
        source.CopyTo(span);

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(' '))
        {
            switch (index)
            {
                case 0:
                    Assert.AreEqual("Hello,", subSpan.ToString());
                    break;
                case 1:
                    Assert.AreEqual("the", subSpan.ToString());
                    break;
                case 2:
                    Assert.AreEqual("World", subSpan.ToString());
                    break;
            }

            index++;
        }

        Assert.AreEqual(3, index);
    }

    [TestMethod]
    public void Split_OnThreeWords_ShouldYieldLength3_UsingStringDelimiter_GivenReadOnlySpan()
    {
        ReadOnlySpan<char> span = "Hello, the World ".AsSpan();

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(" "))
        {
            switch (index)
            {
                case 0:
                    Assert.AreEqual("Hello,", subSpan.ToString());
                    break;
                case 1:
                    Assert.AreEqual("the", subSpan.ToString());
                    break;
                case 2:
                    Assert.AreEqual("World", subSpan.ToString());
                    break;
            }

            index++;
        }

        Assert.AreEqual(3, index);
    }

    [TestMethod]
    public void Split_OnThreeWords_ShouldYieldLength3_UsingStringDelimiter_GivenSpan()
    {
        ReadOnlySpan<char> source = "Hello, the World ".AsSpan();
        Span<char> span = stackalloc char[source.Length];
        source.CopyTo(span);

        var index = 0;
        foreach (ReadOnlySpan<char> subSpan in span.Split(" "))
        {
            switch (index)
            {
                case 0:
                    Assert.AreEqual("Hello,", subSpan.ToString());
                    break;
                case 1:
                    Assert.AreEqual("the", subSpan.ToString());
                    break;
                case 2:
                    Assert.AreEqual("World", subSpan.ToString());
                    break;
            }

            index++;
        }

        Assert.AreEqual(3, index);
    }
}