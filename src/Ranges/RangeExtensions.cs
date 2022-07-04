namespace Ranges;

/// <summary>
/// Contains extension methods for the <see cref="Range{T}"/> data type and its variants.
/// </summary>
public static class RangeExtensions
{
    /// <summary>
    /// Checks whether the given <paramref name="value"/> is contained within the current instance of
    /// <see cref="IRange{T}"/>.
    /// </summary>
    /// <param name="range">Range to compare the value against.</param>
    /// <param name="value">
    /// Value to be compared against the start and end values defined in this instance of <see cref="IRange{T}"/>.
    /// </param>
    /// <param name="exclusions">Contains all the values to be explicitly excluded from the range.</param>
    /// <param name="comparer">
    /// Range comparer to be used when checking if <paramref name="value"/> is defined within this instance of
    /// <see cref="IRange{T}"/>, please check <see cref="RangeComparison"/> for more information.
    /// </param>
    /// <typeparam name="T">Data type that implements <seealso cref="IComparable{T}"/> for value comparison.</typeparam>
    /// <returns>
    /// True if <paramref name="value"/> is within the defined range and is not in the <paramref name="exclusions"/>
    /// enumerable, otherwise false.
    /// </returns>
    public static bool Contains<T>(this IRange<T>? range,
                                   T value,
                                   IEnumerable<T>? exclusions,
                                   RangeComparison comparer = RangeComparison.AllInclusive) where T : IComparable<T>
    {
        if (range is null)
            throw new ArgumentNullException(nameof(range));

        // Make sure there's a value in explicitExclusions before checking.
        exclusions ??= Enumerable.Empty<T>();
        // If the range contains the value, check if it is not explicitly excluded.
        return range.Contains(value) && !exclusions.Any(_ => _.CompareTo(value) == 0);
    }
}