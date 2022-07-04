using System.Collections;

namespace Ranges;

/// <summary>
/// Enumerator class for the stepped range.
/// </summary>
// This is a "good" excuse to implement IEnumerator, but for the most time "yield return" should work just fine.
class SteppedRangeEnumerator<T> : IEnumerator<T> where T : struct, IComparable<T>
{
    private bool _started = false;
    private T _start;
    private T _end;
    private StepDelegate<T> _step;
    private RangeMode _mode;

    public T Current { get; private set; }

    object IEnumerator.Current => this.Current;

    public void Dispose() { }

    public bool MoveNext()
    {
        if (_started)
        {
            Current = _step(Current);
        }
        else
        {
            _started = true;
            Current = _start;
        }

        return _mode switch {
            // When reversed, this prevents going to infinity/-infinity based on the step mode.
            RangeMode.Reversed => Current.CompareTo(_start) <= 0 && Current.CompareTo(_end) >= 0,
            _ => Current.CompareTo(_start) >= 0 && Current.CompareTo(_end) <= 0
        };
    }

    public void Reset() =>
        _started = false;

    public SteppedRangeEnumerator(T start, T end, StepDelegate<T> step)
    {
        _start = start;
        _end = end;
        _step = step;
        _mode = Range<T>.GetRangeMode(start, end);
    }
}