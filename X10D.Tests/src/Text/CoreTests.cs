using NUnit.Framework;
using X10D.Text;

namespace X10D.Tests.Text;

[TestFixture]
internal class CoreTests
{
    [Test]
    public void ToJsonShouldNotBeEmpty()
    {
        object? obj = null;
        string json = obj.ToJson();
        Assert.That(string.IsNullOrEmpty(json), Is.False);
    }

    [Test]
    public void ToJsonShouldDeserializeEquivalent()
    {
        int[] source = Enumerable.Range(1, 100).ToArray();
        string json = source.ToJson();
        int[]? target = json.FromJson<int[]>();
        CollectionAssert.AreEqual(source, target);
        CollectionAssert.AreEquivalent(source, target);
    }
}
