# Ranges

This is Ranges, a .NET library written as a joke/for fun that aims to contain more ranges than you'll ever need.

Feedback is always welcome.

## How it works?

Below are a few examples on how to use the different Range types.

### `IRange<T>`/`Range<T>`

```cs
using Ranges;

int number = 5;
var range = new Range<int>(1, 10);

// Outputs: "Is 5 within range? yes!"
Console.WriteLine($"Is '{number}' within range? {(range.Contains(number)? "yes!": "no...")}");
```

### `ISteppedRange<T>`/`SteppedRange<T>`

```cs
using Ranges;
int number = 3;
var range = new SteppedRange<int>(0, 10, prev => prev + 2);

// Outputs: "Is 3 within range? no..."
Console.WriteLine($"Is '{number}' within range? {(range.Contains(number)? "yes!": "no...")}");
// Outputs: The range: [ 0, 2, 4, 6, 8, 10 ]
Console.WriteLine($"The range: [ {string.Join(", ", range)} ]");
```

Cool thing about this is that you can use the ranges with anything that implement `IComparable<T>`.

## Things to do

- [x] `IRange<T>`/`Range<T>`: Simple range with inclusive/exclusive value comparers.
- [x] Range value exclusions.
- [x] `ISteppedRange<T>`/`SteppedRange<T>`: Range with step values.
- [ ] Any other type of range you'd like?
- [ ] Extension methods.