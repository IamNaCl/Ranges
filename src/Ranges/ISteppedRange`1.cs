namespace Ranges;

/// <summary>
/// Represents a range between two values to be used for comparison.
/// </summary>
/// <typeparam name="T">Data type that implements <seealso cref="IComparable{T}"/> for value comparison.</typeparam>
public interface ISteppedRange<T> : IRange<T>, IEnumerable<T> where T : IComparable<T>
{
    /// <summary>
    /// Gets the stepping function that will produce an enumerable containing all the values within the range.
    /// </summary>
    StepDelegate<T> Step { get; }
}