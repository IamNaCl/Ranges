namespace Ranges.Tests;

[TestClass]
public class SteppedRange_T_UnitTests
{
    [TestMethod]
    public void Test_SteppedRange_HasAllEvenNumbersFrom0to10()
    {
        var range = new SteppedRange<int>(0, 10, prev => prev + 2);
        var expected = new[] { 0, 2, 4, 6, 8, 10 };
        Assert.IsTrue(expected.SequenceEqual(range));
    }

    [TestMethod]
    public void Test_SteppedRange_HasAllEvenNumbersFrom10to0()
    {
        var range = new SteppedRange<int>(10, 0, prev => prev - 2);
        var expected = new[] { 10, 8, 6, 4, 2, 0 };
        Assert.IsTrue(expected.SequenceEqual(range));
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(2)]
    [DataRow(4)]
    [DataRow(6)]
    [DataRow(8)]
    [DataRow(10)]
    public void Test_SteppedRange_Contains_ValuesWithinRange(int testValue)
    {
        // Range: 0, 2, 4, 6, 8, 10
        var range = new SteppedRange<int>(0, 10, prev => prev + 2);
        Assert.IsTrue(range.Contains(testValue));
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(3)]
    [DataRow(5)]
    [DataRow(7)]
    [DataRow(9)]
    public void Test_SteppedRange_DoesNotContain_Values(int testValue)
    {
        // Range: 0, 2, 4, 6, 8, 10
        var range = new SteppedRange<int>(0, 10, prev => prev + 2);
        Assert.IsFalse(range.Contains(testValue));
    }
}
