namespace PartitionLabels.UnitTests;

public class Tests {
    [SetUp]
    public void Setup() {
    }

    [Test]
    public void Test_ExampleOne_Pass() {
        Assert.That(PartitionLabels.Solution("ababcbacadefegdehijhklij"), Is.EqualTo(new int[] { 9, 7, 8 }));
    }
    
    [Test]
    public void Test_ExampleTwo_Pass() {
        Assert.That(PartitionLabels.Solution("eccbbbbdec"), Is.EqualTo(new int[] { 10 }));
    }
    
    [TestCase("a", new int[] { 1 })]
    [TestCase("b", new int[] { 1 })]
    [TestCase("c", new int[] { 1 })]
    public void Test_OneEnglishLowercaseLetter_Pass(string s, int[] expected) {
        Assert.That(PartitionLabels.Solution(s), Is.EqualTo(expected));
    }
    
    [TestCase("A", new int[] { 1 })]
    [TestCase("B", new int[] { 1 })]
    [TestCase("C", new int[] { 1 })]
    public void Test_OneEnglishUppercaseLetter_Pass(string s, int[] expected) {
        Assert.That(PartitionLabels.Solution(s), Is.EqualTo(expected));
    }
    
}