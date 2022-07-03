namespace Ranges;

/// <summary>
/// Specifies the comparison mode of a range object.
/// </summary>
public enum RangeComparison
{
    /// <summary>
    /// Include both start and end values in the comparison, this is the default mode.
    /// </summary>
    AllInclusive = 0,

    /// <summary>
    /// Exclude the start value of the range from the comparison.
    /// </summary>
    ExcludeStart = 1,

    /// <summary>
    /// Exclude the end value of the range from the comparison.
    /// </summary>
    ExcludeEnd = 2,

    /// <summary>
    /// Exclude both start and end values from the comparison.
    /// </summary>
    AllExclusive = ExcludeStart | ExcludeEnd
}