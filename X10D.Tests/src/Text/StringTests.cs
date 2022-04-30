﻿using System.Text;
using System.Text.Json.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using X10D.Text;

namespace X10D.Tests.Text;

[TestClass]
public class StringTests
{
    [TestMethod]
    public void AsNullIfEmpty_ShouldBeCorrect()
    {
        const string sampleString = "Hello World";
        const string whitespaceString = " ";
        const string emptyString = "";
        const string? nullString = null;

        string sampleResult = sampleString.AsNullIfEmpty();
        string whitespaceResult = whitespaceString.AsNullIfEmpty();
        string emptyResult = emptyString.AsNullIfEmpty();
        string? nullResult = nullString.AsNullIfEmpty();

        Assert.AreEqual(sampleString, sampleResult);
        Assert.AreEqual(whitespaceString, whitespaceResult);
        Assert.AreEqual(nullString, emptyResult);
        Assert.AreEqual(nullString, nullResult);
    }

    [TestMethod]
    public void AsNullIfWhiteSpace_ShouldBeCorrect()
    {
        const string sampleString = "Hello World";
        const string whitespaceString = " ";
        const string emptyString = "";
        const string? nullString = null;

        string sampleResult = sampleString.AsNullIfWhiteSpace();
        string whitespaceResult = whitespaceString.AsNullIfWhiteSpace();
        string emptyResult = emptyString.AsNullIfWhiteSpace();
        string? nullResult = nullString.AsNullIfWhiteSpace();

        Assert.AreEqual(sampleString, sampleResult);
        Assert.AreEqual(nullString, whitespaceResult);
        Assert.AreEqual(nullString, emptyResult);
        Assert.AreEqual(nullString, nullResult);
    }

    [TestMethod]
    public void Base64Decode_ShouldReturnHelloWorld_GivenBase64String()
    {
        Assert.AreEqual("Hello World", "SGVsbG8gV29ybGQ=".Base64Decode());
    }


    [TestMethod]
    public void Base64Decode_ShouldThrow_GivenNull()
    {
        string? value = null;
        Assert.ThrowsException<ArgumentNullException>(() => value!.Base64Decode());
    }


    [TestMethod]
    public void Base64Encode_ShouldReturnBase64String_GivenHelloWorld()
    {
        Assert.AreEqual("SGVsbG8gV29ybGQ=", "Hello World".Base64Encode());
    }

    [TestMethod]
    public void Base64Encode_ShouldThrow_GivenNull()
    {
        string? value = null;
        Assert.ThrowsException<ArgumentNullException>(() => value!.Base64Encode());
    }

    [TestMethod]
    public void ChangeEncoding_ShouldReturnAsciiString_GivenUtf8()
    {
        Assert.AreEqual("Hello World", "Hello World".ChangeEncoding(Encoding.UTF8, Encoding.ASCII));
    }

    [TestMethod]
    public void ChangeEncoding_ShouldThrow_GivenNullString()
    {
        string? value = null;
        Assert.ThrowsException<ArgumentNullException>(() => value!.ChangeEncoding(Encoding.UTF8, Encoding.ASCII));
    }

    [TestMethod]
    public void ChangeEncoding_ShouldThrow_GivenNullSourceEncoding()
    {
        Assert.ThrowsException<ArgumentNullException>(() => "Hello World".ChangeEncoding(null!, Encoding.ASCII));
    }

    [TestMethod]
    public void ChangeEncoding_ShouldThrow_GivenNullDestinationEncoding()
    {
        Assert.ThrowsException<ArgumentNullException>(() => "Hello World".ChangeEncoding(Encoding.UTF8, null!));
    }

    [TestMethod]
    public void EnumParse_ShouldReturnCorrectValue_GivenString()
    {
        Assert.AreEqual(DayOfWeek.Monday, "Monday".EnumParse<DayOfWeek>(false));
        Assert.AreEqual(DayOfWeek.Tuesday, "Tuesday".EnumParse<DayOfWeek>(false));
        Assert.AreEqual(DayOfWeek.Wednesday, "Wednesday".EnumParse<DayOfWeek>(false));
        Assert.AreEqual(DayOfWeek.Thursday, "Thursday".EnumParse<DayOfWeek>(false));
        Assert.AreEqual(DayOfWeek.Friday, "Friday".EnumParse<DayOfWeek>(false));
        Assert.AreEqual(DayOfWeek.Saturday, "Saturday".EnumParse<DayOfWeek>(false));
        Assert.AreEqual(DayOfWeek.Sunday, "Sunday".EnumParse<DayOfWeek>(false));
    }

    [TestMethod]
    public void EnumParse_ShouldTrim()
    {
        Assert.AreEqual(DayOfWeek.Monday, "   Monday   ".EnumParse<DayOfWeek>());
        Assert.AreEqual(DayOfWeek.Tuesday, "   Tuesday   ".EnumParse<DayOfWeek>());
        Assert.AreEqual(DayOfWeek.Wednesday, "   Wednesday   ".EnumParse<DayOfWeek>());
        Assert.AreEqual(DayOfWeek.Thursday, "   Thursday   ".EnumParse<DayOfWeek>());
        Assert.AreEqual(DayOfWeek.Friday, "   Friday   ".EnumParse<DayOfWeek>());
        Assert.AreEqual(DayOfWeek.Saturday, "   Saturday   ".EnumParse<DayOfWeek>());
        Assert.AreEqual(DayOfWeek.Sunday, "   Sunday   ".EnumParse<DayOfWeek>());
    }

    [TestMethod]
    public void EnumParse_ShouldReturnCorrectValue_GivenString_Generic()
    {
        Assert.AreEqual(DayOfWeek.Monday, "Monday".EnumParse<DayOfWeek>());
        Assert.AreEqual(DayOfWeek.Tuesday, "Tuesday".EnumParse<DayOfWeek>());
        Assert.AreEqual(DayOfWeek.Wednesday, "Wednesday".EnumParse<DayOfWeek>());
        Assert.AreEqual(DayOfWeek.Thursday, "Thursday".EnumParse<DayOfWeek>());
        Assert.AreEqual(DayOfWeek.Friday, "Friday".EnumParse<DayOfWeek>());
        Assert.AreEqual(DayOfWeek.Saturday, "Saturday".EnumParse<DayOfWeek>());
        Assert.AreEqual(DayOfWeek.Sunday, "Sunday".EnumParse<DayOfWeek>());
    }

    [TestMethod]
    public void EnumParse_ShouldThrow_GivenNullString()
    {
        string? value = null;
        Assert.ThrowsException<ArgumentNullException>(() => value!.EnumParse<DayOfWeek>());
    }

    [TestMethod]
    public void EnumParse_ShouldThrow_GivenEmptyOrWhiteSpaceString()
    {
        Assert.ThrowsException<ArgumentException>(() => string.Empty.EnumParse<DayOfWeek>());
        Assert.ThrowsException<ArgumentException>(() => " ".EnumParse<DayOfWeek>());
    }

    [TestMethod]
    public void FromJson_ShouldDeserializeCorrectly_GivenJsonString()
    {
        const string json = "{\"values\": [1, 2, 3]}";
        var target = json.FromJson<SampleStructure>();
        Assert.IsInstanceOfType(target, typeof(SampleStructure));
        Assert.IsNotNull(target);
        Assert.IsNotNull(target.Values);
        Assert.AreEqual(3, target.Values.Length);
        Assert.AreEqual(1, target.Values[0]);
        Assert.AreEqual(2, target.Values[1]);
        Assert.AreEqual(3, target.Values[2]);
    }

    [TestMethod]
    public void GetBytes_ShouldReturnUtf8Bytes_GivenHelloWorld()
    {
        var expected = new byte[] {0x48, 0x65, 0x6C, 0x6C, 0x6F, 0x20, 0x57, 0x6F, 0x72, 0x6C, 0x64};
        byte[] actual = "Hello World".GetBytes();

        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetBytes_ShouldReturnAsciiBytes_GivenHelloWorld()
    {
        var expected = new byte[] {0x48, 0x65, 0x6C, 0x6C, 0x6F, 0x20, 0x57, 0x6F, 0x72, 0x6C, 0x64};
        byte[] actual = "Hello World".GetBytes(Encoding.ASCII);

        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetBytes_ShouldThrow_GivenNullString()
    {
        string? value = null;
        Assert.ThrowsException<ArgumentNullException>(() => value!.GetBytes());
        Assert.ThrowsException<ArgumentNullException>(() => value!.GetBytes(Encoding.ASCII));
    }

    [TestMethod]
    public void GetBytes_ShouldThrow_GivenNullEncoding()
    {
        Assert.ThrowsException<ArgumentNullException>(() => "Hello World".GetBytes(null!));
    }

    [TestMethod]
    public void IsLower_ShouldReturnTrue_GivenLowercaseString()
    {
        Assert.IsTrue("hello world".IsLower());
    }

    [TestMethod]
    public void IsLower_ShouldReturnFalse_GivenMixedCaseString()
    {
        Assert.IsFalse("Hello World".IsLower());
    }

    [TestMethod]
    public void IsLower_ShouldReturnFalse_GivenUppercaseString()
    {
        Assert.IsFalse("HELLO WORLD".IsLower());
    }

    [TestMethod]
    public void IsLower_ShouldThrow_GivenNull()
    {
        string? value = null;
        Assert.ThrowsException<ArgumentNullException>(() => value!.IsLower());
    }

    [TestMethod]
    public void IsPalindrome_ShouldBeCorrect_GivenString()
    {
        const string inputA = "Race car";
        const string inputB = "Racecar";
        const string inputC = "A man, a plan, a canal, panama";
        const string inputD = "Jackdaws love my big sphinx of quartz";
        const string inputE = "Y";
        const string inputF = "1";

        Assert.IsTrue(inputA.IsPalindrome(), inputA);
        Assert.IsTrue(inputB.IsPalindrome(), inputB);
        Assert.IsTrue(inputC.IsPalindrome(), inputC);
        Assert.IsFalse(inputD.IsPalindrome(), inputD);
        Assert.IsTrue(inputE.IsPalindrome(), inputE);
        Assert.IsTrue(inputF.IsPalindrome(), inputF);
    }

    [TestMethod]
    public void IsPalindrome_ShouldReturnFalse_GivenEmptyString()
    {
        Assert.IsFalse(string.Empty.IsPalindrome());
    }

    [TestMethod]
    public void IsPalindrome_ShouldThrow_GivenNull()
    {
        Assert.ThrowsException<ArgumentNullException>(() => ((string?)null)!.IsPalindrome());
    }

    [TestMethod]
    public void IsUpper_ShouldReturnFalse_GivenLowercaseString()
    {
        Assert.IsFalse("hello world".IsUpper());
    }

    [TestMethod]
    public void IsUpper_ShouldReturnFalse_GivenMixedCaseString()
    {
        Assert.IsFalse("Hello World".IsUpper());
    }

    [TestMethod]
    public void IsUpper_ShouldReturnTrue_GivenUppercaseString()
    {
        Assert.IsTrue("HELLO WORLD".IsUpper());
    }

    [TestMethod]
    public void IsUpper_ShouldThrow_GivenNull()
    {
        string? value = null;
        Assert.ThrowsException<ArgumentNullException>(() => value!.IsUpper());
    }

    [TestMethod]
    public void Randomize_ShouldReorder_GivenString()
    {
        const string input = "Hello World";
        var random = new Random(1);
        Assert.AreEqual("le rooldeoH", input.Randomize(input.Length, random));
    }

    [TestMethod]
    public void Randomize_ShouldReturnEmptyString_GivenLength1()
    {
        Assert.AreEqual(string.Empty, "Hello World".Randomize(0));
    }

    [TestMethod]
    public void Randomize_ShouldThrow_GivenNull()
    {
        string? value = null;
        Assert.ThrowsException<ArgumentNullException>(() => value!.Randomize(1));
    }

    [TestMethod]
    public void Randomize_ShouldThrow_GivenNegativeLength()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => string.Empty.Randomize(-1));
    }

    [TestMethod]
    public void Repeat_ShouldReturnRepeatedString_GivenString()
    {
        const string expected = "aaaaaaaaaa";
        string actual = "a".Repeat(10);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Repeat_ShouldReturnEmptyString_GivenCount0()
    {
        Assert.AreEqual(string.Empty, "a".Repeat(0));
    }

    [TestMethod]
    public void Repeat_ShouldReturnItself_GivenCount1()
    {
        string repeated = "a".Repeat(1);
        Assert.AreEqual(1, repeated.Length);
        Assert.AreEqual("a", repeated);
    }

    [TestMethod]
    public void Repeat_ShouldThrow_GivenNegativeCount()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => "a".Repeat(-1));
    }

    [TestMethod]
    public void Repeat_ShouldThrow_GivenNull()
    {
        string? value = null;
        Assert.ThrowsException<ArgumentNullException>(() => value!.Repeat(0));
    }

    [TestMethod]
    public void Reverse_ShouldBeCorrect()
    {
        const string input = "Hello World";
        const string expected = "dlroW olleH";

        string result = input.Reverse();

        Assert.AreEqual(string.Empty.Reverse(), string.Empty);
        Assert.AreEqual(" ".Reverse(), " ");
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Reverse_ShouldThrow_GivenNull()
    {
        string? value = null;
        Assert.ThrowsException<ArgumentNullException>(() => value!.Reverse());
    }

    [TestMethod]
    public void Shuffled_ShouldReorder_GivenString()
    {
        const string alphabet = "abcdefghijklmnopqrstuvwxyz";
        string shuffled = alphabet;

        Assert.AreEqual(alphabet, shuffled);

        shuffled = alphabet.Shuffled();

        Assert.AreNotEqual(alphabet, shuffled);
    }

    [TestMethod]
    public void Shuffled_ShouldThrow_GivenNull()
    {
        string? value = null;
        Assert.ThrowsException<ArgumentNullException>(() => value!.Shuffled());
    }

    [TestMethod]
    public void Split_ShouldYieldCorrectStrings_GivenString()
    {
        string[] chunks = "Hello World".Split(2).ToArray();
        Assert.AreEqual(6, chunks.Length);
        Assert.AreEqual("He", chunks[0]);
        Assert.AreEqual("ll", chunks[1]);
        Assert.AreEqual("o ", chunks[2]);
        Assert.AreEqual("Wo", chunks[3]);
        Assert.AreEqual("rl", chunks[4]);
        Assert.AreEqual("d", chunks[5]);
    }

    [TestMethod]
    public void Split_ShouldYieldEmptyString_GivenChunkSize0()
    {
        string[] chunks = "Hello World".Split(0).ToArray();
        Assert.AreEqual(1, chunks.Length);
        Assert.AreEqual(string.Empty, chunks[0]);
    }

    [TestMethod]
    public void Split_ShouldThrow_GivenNullString()
    {
        string? value = null;

        // forcing enumeration with ToArray is required for the exception to be thrown
        Assert.ThrowsException<ArgumentNullException>(() => value!.Split(0).ToArray());
    }

    [TestMethod]
    public void WithEmptyAlternative_ShouldBeCorrect()
    {
        const string inputA = "Hello World";
        const string inputB = " ";
        const string inputC = "";
        const string? inputD = null;
        const string alternative = "ALTERNATIVE";

        string resultA = inputA.WithEmptyAlternative(alternative);
        string resultB = inputB.WithEmptyAlternative(alternative);
        string resultC = inputC.WithEmptyAlternative(alternative);
        string resultD = inputD.WithEmptyAlternative(alternative);

        Assert.AreEqual(resultA, inputA);
        Assert.AreEqual(resultB, inputB);
        Assert.AreEqual(resultC, alternative);
        Assert.AreEqual(resultD, alternative);
        Assert.AreEqual(alternative, ((string?)null).WithEmptyAlternative(alternative));
    }

    [TestMethod]
    public void WithWhiteSpaceAlternative_ShouldBeCorrect()
    {
        const string input = " ";
        const string alternative = "ALTERNATIVE";

        string result = input.WithWhiteSpaceAlternative(alternative);

        Assert.AreEqual(result, alternative);
        Assert.AreEqual(alternative, ((string?)null).WithWhiteSpaceAlternative(alternative));
    }

    private struct SampleStructure
    {
        [JsonPropertyName("values")]
        public int[] Values { get; set; }
    }
}