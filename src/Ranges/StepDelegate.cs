namespace Ranges;

/// <summary>
/// Represents a function that acts as the step used to generate all the values within the
/// <see cref="ISteppedRange{T}"/>.
/// </summary>
/// <param name="previous">Member of the range previously generated.</param>
/// <typeparam name="T">Data type that implements <seealso cref="IComparable{T}"/> for value comparison.</typeparam>
/// <returns>The next member in the sequence defined by this function.</returns>
public delegate T StepDelegate<T>(T previous) where T : IComparable<T>;