namespace Ranges;

/// <summary>
/// Represents a range between two values to be used for comparison.
/// </summary>
/// <typeparam name="T">Data type that implements <seealso cref="IComparable{T}"/> for value comparison.</typeparam>
public interface IRange<T> where T : IComparable<T>
{
    /// <summary>
    /// Gets the start value defined for this instance of <see cref="IRange{T}"/>.
    /// </summary>
    T Start { get; }

    /// <summary>
    /// Gets the end value defined for this instance of <see cref="IRange{T}"/>.
    /// </summary>
    T End { get; }

    /// <summary>
    /// Gets the mode defined for this range.
    /// </summary>
    /// <returns>Value from the <see cref="RangeMode"/> enum defining the current mode of the range.</returns>
    RangeMode GetMode();

    /// <summary>
    /// Checks whether the given <paramref name="value"/> is contained within the current instance of
    /// <see cref="IRange{T}"/>.
    /// </summary>
    /// <param name="value">
    /// Value to be compared against the start and end values defined in this instance of <see cref="IRange{T}"/>.
    /// </param>
    /// <param name="comparer">
    /// Range comparer to be used when checking if <paramref name="value"/> is defined within this instance of
    /// <see cref="IRange{T}"/>, please check <see cref="RangeComparison"/> for more information.
    /// </param>
    /// <returns>True if <paramref name="value"/> is within the defined range, otherwise false.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when <paramref name="comparer"/> has an invalid value.
    /// </exception>
    /// <remarks>
    /// This function will always normalize the range (convert it to <see cref="RangeMode.Normal"/>) before checking if
    /// <paramref name="value"/> is contained within the range, this means that when <paramref name="comparer"/> is
    /// <see cref="RangeComparison.ExcludeStart"/>, then the value to be excluded is the smallest one, the same applies
    /// to <see cref="RangeComparison.ExcludeEnd"/>, as in only the big value will be excluded.
    /// </remarks>
    bool Contains(T value, RangeComparison comparer = RangeComparison.AllInclusive);
}