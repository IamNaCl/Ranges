using System.Collections;

namespace Ranges;

/// <inheritdoc/>
/// <remarks>
/// Note: This type of range implements exclusions on values that are not part of the final range enumeration.
/// </remarks>
[System.Diagnostics.DebuggerDisplayAttribute("<Start: {Start}, End: {End}, Mode: {_mode}>")]
public class SteppedRange<T> : ISteppedRange<T> where T : struct, IComparable<T>
{
    private RangeMode _mode;

    public StepDelegate<T> Step { get; }

    public T Start { get; }

    public T End { get; }

    // This Contains method will ensure that the value to be compared is within the final range.
    public bool Contains(T value, RangeComparison comparer = RangeComparison.AllInclusive) =>
        Range<T>.Contains(GetMode(), Start, End, value, comparer) && this.Any(_ => _.CompareTo(value) == 0);

    public RangeMode GetMode() => _mode;

    #region IEnumerable
    public IEnumerator<T> GetEnumerator() =>
        new SteppedRangeEnumerator<T>(Start, End, Step);

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    #endregion

    public SteppedRange(T start, T end, StepDelegate<T> step) =>
        (Start, End, _mode, Step) = (start, end, Range<T>.GetRangeMode(start, end), step);
}