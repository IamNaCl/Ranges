namespace Ranges;

/// <summary>
/// Specifies the mode this range is defined.
/// </summary>
public enum RangeMode
{
    /// <summary>
    /// Range is in "normal" mode, where the start is a value smaller than the end value.
    /// </summary>
    Normal,

    /// <summary>
    /// Range is in "equal" mode, where both start and end have the same value.
    /// </summary>
    Equal,

    /// <summary>
    /// Range is in "reversed" mode, where the start value is bigger than the end value.
    /// </summary>
    Reversed
}