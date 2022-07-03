namespace Ranges.Tests;

[TestClass]
public class Range_T_UnitTests
{
    // Not sure if using DataRow to include the expected results is good practice for dynamic tests.
    [TestMethod]
    [DataRow(-2, false)]
    [DataRow(-1, false)]
    [DataRow(0, false)]
    [DataRow(1, true)]
    [DataRow(2, true)]
    [DataRow(3, true)]
    [DataRow(4, true)]
    [DataRow(5, true)]
    [DataRow(6, true)]
    [DataRow(7, true)]
    [DataRow(8, true)]
    [DataRow(9, true)]
    [DataRow(10, true)]
    [DataRow(11, false)]
    [DataRow(12, false)]
    public void Test_Range_Contains_AllInclusiveComparer(int testValue, bool expectedValue)
    {
        var range = new Range<int>(1, 10);
        Assert.AreEqual(expectedValue, range.Contains(testValue, RangeComparison.AllInclusive));
    }

    [TestMethod]
    [DataRow(-2, false)]
    [DataRow(-1, false)]
    [DataRow(0, false)]
    [DataRow(1, false)]
    [DataRow(2, true)]
    [DataRow(3, true)]
    [DataRow(4, true)]
    [DataRow(5, true)]
    [DataRow(6, true)]
    [DataRow(7, true)]
    [DataRow(8, true)]
    [DataRow(9, true)]
    [DataRow(10, false)]
    [DataRow(11, false)]
    [DataRow(12, false)]
    public void Test_Range_Contains_AllExclusiveComparer(int testValue, bool expectedValue)
    {
        var range = new Range<int>(1, 10);
        Assert.AreEqual(expectedValue, range.Contains(testValue, RangeComparison.AllExclusive));
    }

    [TestMethod]
    [DataRow(-2, false)]
    [DataRow(-1, false)]
    [DataRow(0, false)]
    [DataRow(1, false)]
    [DataRow(2, true)]
    [DataRow(3, true)]
    [DataRow(4, true)]
    [DataRow(5, true)]
    [DataRow(6, true)]
    [DataRow(7, true)]
    [DataRow(8, true)]
    [DataRow(9, true)]
    [DataRow(10, true)]
    [DataRow(11, false)]
    [DataRow(12, false)]
    public void Test_Range_Contains_ExcludeStartComparer(int testValue, bool expectedValue)
    {
        var range = new Range<int>(1, 10);
        Assert.AreEqual(expectedValue, range.Contains(testValue, RangeComparison.ExcludeStart));
    }

    [TestMethod]
    [DataRow(-2, false)]
    [DataRow(-1, false)]
    [DataRow(0, false)]
    [DataRow(1, true)]
    [DataRow(2, true)]
    [DataRow(3, true)]
    [DataRow(4, true)]
    [DataRow(5, true)]
    [DataRow(6, true)]
    [DataRow(7, true)]
    [DataRow(8, true)]
    [DataRow(9, true)]
    [DataRow(10, false)]
    [DataRow(11, false)]
    [DataRow(12, false)]
    public void Test_Range_Contains_ExcludeEndComparer(int testValue, bool expectedValue)
    {
        var range = new Range<int>(1, 10);
        Assert.AreEqual(expectedValue, range.Contains(testValue, RangeComparison.ExcludeEnd));
    }

    [TestMethod]
    [DataRow(-2, false)]
    [DataRow(-1, false)]
    [DataRow(0, false)]
    [DataRow(1, true)]
    [DataRow(2, true)]
    [DataRow(3, true)]
    [DataRow(4, true)]
    [DataRow(5, true)]
    [DataRow(6, true)]
    [DataRow(7, true)]
    [DataRow(8, true)]
    [DataRow(9, true)]
    [DataRow(10, true)]
    [DataRow(11, false)]
    [DataRow(12, false)]
    public void Test_ReversedRange_Contains_AllInclusiveComparer(int testValue, bool expectedValue)
    {
        var range = new Range<int>(10, 1);
        Assert.AreEqual(expectedValue, range.Contains(testValue, RangeComparison.AllInclusive));
    }

    [TestMethod]
    [DataRow(-2, false)]
    [DataRow(-1, false)]
    [DataRow(0, false)]
    [DataRow(1, false)]
    [DataRow(2, true)]
    [DataRow(3, true)]
    [DataRow(4, true)]
    [DataRow(5, true)]
    [DataRow(6, true)]
    [DataRow(7, true)]
    [DataRow(8, true)]
    [DataRow(9, true)]
    [DataRow(10, false)]
    [DataRow(11, false)]
    [DataRow(12, false)]
    public void Test_ReversedRange_Contains_AllExclusiveComparer(int testValue, bool expectedValue)
    {
        var range = new Range<int>(10, 1);
        Assert.AreEqual(expectedValue, range.Contains(testValue, RangeComparison.AllExclusive));
    }

    [TestMethod]
    [DataRow(-2, false)]
    [DataRow(-1, false)]
    [DataRow(0, false)]
    [DataRow(1, false)]
    [DataRow(2, true)]
    [DataRow(3, true)]
    [DataRow(4, true)]
    [DataRow(5, true)]
    [DataRow(6, true)]
    [DataRow(7, true)]
    [DataRow(8, true)]
    [DataRow(9, true)]
    [DataRow(10, true)]
    [DataRow(11, false)]
    [DataRow(12, false)]
    public void Test_ReversedRange_Contains_ExcludeStartComparer(int testValue, bool expectedValue)
    {
        var range = new Range<int>(10, 1);
        Assert.AreEqual(expectedValue, range.Contains(testValue, RangeComparison.ExcludeStart));
    }

    [TestMethod]
    [DataRow(-2, false)]
    [DataRow(-1, false)]
    [DataRow(0, false)]
    [DataRow(1, true)]
    [DataRow(2, true)]
    [DataRow(3, true)]
    [DataRow(4, true)]
    [DataRow(5, true)]
    [DataRow(6, true)]
    [DataRow(7, true)]
    [DataRow(8, true)]
    [DataRow(9, true)]
    [DataRow(10, false)]
    [DataRow(11, false)]
    [DataRow(12, false)]
    public void Test_ReversedRange_Contains_ExcludeEndComparer(int testValue, bool expectedValue)
    {
        var range = new Range<int>(10, 1);
        Assert.AreEqual(expectedValue, range.Contains(testValue, RangeComparison.ExcludeEnd));
    }

    [TestMethod]
    [DataRow(0, false)]
    [DataRow(1, true)]
    [DataRow(2, false)]
    public void Test_EqualRange_Contains_AllInclusiveComparer(int testValue, bool expectedValue)
    {
        var range = new Range<int>(1, 1);
        Assert.AreEqual(expectedValue, range.Contains(testValue, RangeComparison.AllInclusive));
    }

    // All exclusive on an equal range is kind of pointless, but it is allowed, so we need to account for correct
    // behavior.
    [TestMethod]
    [DataRow(0, false)]
    [DataRow(1, false)]
    [DataRow(2, false)]
    public void Test_EqualRange_Contains_AllExclusiveComparer(int testValue, bool expectedValue)
    {
        var range = new Range<int>(1, 1);
        Assert.AreEqual(expectedValue, range.Contains(testValue, RangeComparison.AllExclusive));
    }

    // ExcludeStart and ExcludeEnd should work the same as AllExclusive.
    [TestMethod]
    [DataRow(0, false)]
    [DataRow(1, false)]
    [DataRow(2, false)]
    public void Test_EqualRange_Contains_ExcludeStartComparer(int testValue, bool expectedValue)
    {
        var range = new Range<int>(1, 1);
        Assert.AreEqual(expectedValue, range.Contains(testValue, RangeComparison.ExcludeStart));
    }

    [TestMethod]
    [DataRow(0, false)]
    [DataRow(1, false)]
    [DataRow(2, false)]
    public void Test_EqualRange_Contains_ExcludeEndComparer(int testValue, bool expectedValue)
    {
        var range = new Range<int>(1, 1);
        Assert.AreEqual(expectedValue, range.Contains(testValue, RangeComparison.ExcludeEnd));
    }

    [TestMethod]
    public void Test_Range_Contains_InvalidRangeComparison()
    {
        var range = new Range<int>(1, 10);
        Assert.ThrowsException<InvalidOperationException>(() => range.Contains(4, (RangeComparison)(-1)));
    }
}
