# Ranges

This is Ranges, a .NET library written as a joke/for fun that aims to contain more ranges than you'll ever need.

Feedback is always welcome.

## How it works?

For `IRange<T>`/`Range<T>`, it is really simple:

```cs
using Ranges;

int number = 5;
var range = new Range<int>(1, 10);

Console.WriteLine($"Is '{number}' within range? {(range.Contains(number)? "yes!": "no...")}");
```

Cool thing about this is that you can use it with anything that implement `IComparable<T>`.

## Things to do

- [x] `IRange<T>`/`Range<T>`: Simple range with inclusive/exclusive value comparers.
- [x] Range value exclusions.
- [x] `ISteppedRange<T>`/`SteppedRange<T>`: Range with step values.
- [ ] Any other type of range you'd like?
- [ ] Extension methods.