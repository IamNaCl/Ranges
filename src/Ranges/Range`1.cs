namespace Ranges;

/// <inheritdoc/>
[System.Diagnostics.DebuggerDisplay("<Start: {Start}, End: {End}, Mode: {_mode}>")]
public struct Range<T> : IRange<T> where T : struct, IComparable<T>
{
    // Didn't add it as a property as it will be included when serialized.
    private RangeMode _mode;

    public T Start { get; }

    public T End { get; }

    #region Contains
    /// <summary>
    /// Checks whether the given <paramref name="value"/> is contained within the current instance of
    /// <see cref="IRange{T}"/>.
    /// </summary>
    /// <param name="mode">Mode of the range.</param>
    /// <param name="start">Start value of the range.</param>
    /// <param name="end">End value of the range.</param>
    /// <param name="value">
    /// Value to be compared against the start and end values defined in this instance of <see cref="IRange{T}"/>.
    /// </param>
    /// <param name="comparer">
    /// Range comparer to be used when checking if <paramref name="value"/> is defined within this instance of
    /// <see cref="IRange{T}"/>, please check <see cref="RangeComparison"/> for more information.
    /// </param>
    /// <returns>True if the <paramref name="value"/> exists within the given range.</returns>
    internal static bool Contains(RangeMode mode, T start, T end, T value, RangeComparison comparer)
    {
        // Check the <remarks> section in the documentation comment for this.
        // I'd want to do it at the constructor level, but the consumer might want to have the original range for debug.
        (start, end) = mode switch { RangeMode.Reversed => (end, start), _ => (start, end) };

        var startValue = value.CompareTo(start);
        var endValue = value.CompareTo(end);
        return comparer switch {
            RangeComparison.AllInclusive => startValue >= 0 && endValue <= 0,
            RangeComparison.AllExclusive => startValue > 0 && endValue < 0,
            RangeComparison.ExcludeStart => startValue > 0 && endValue <= 0,
            RangeComparison.ExcludeEnd   => startValue >= 0 && endValue < 0,
            _ => throw new InvalidOperationException($"RangeComparison value is invalid: '{comparer}'.")
        };
    }

    public bool Contains(T value, RangeComparison comparer = RangeComparison.AllInclusive) =>
        Contains(GetMode(), Start, End, value, comparer);
    #endregion

    #region GetMode
    public RangeMode GetMode() => _mode;

    /// <summary>
    /// Gets the range mode.
    /// </summary>
    // Here we use "< 0" and "> 0" because CompareTo might return values different than 1 and -1.
    internal static RangeMode GetRangeMode(T start, T end) => start.CompareTo(end) switch
    {
        < 0 => RangeMode.Normal,
        > 0 => RangeMode.Reversed,
          _ => RangeMode.Equal
    };
    #endregion

    /// <summary>
    /// Initializes a new copy of the <see cref="Range{T}"/> struct.
    /// </summary>
    /// <param name="start">Start value.</param>
    /// <param name="end">End value.</param>
    public Range(T start, T end) =>
        (Start, End, _mode) = (start, end, GetRangeMode(start, end));
}