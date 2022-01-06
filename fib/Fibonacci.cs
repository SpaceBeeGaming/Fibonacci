using System.Numerics;

namespace Fibonacci;

/// <summary>
/// Calculates numbers of the Fibonacci sequence.
/// </summary>
public class Fibonacci
{
    private readonly List<BigInteger> _fibList = new();

    /// <summary>
    /// Gets the starting values for the next call to <see cref="Calculate(int)"/>.
    /// </summary>
    public (BigInteger InitialFirst, BigInteger InitialSecond) StartingValues { get; private set; } = (0, 1);

    /// <summary>
    /// Calculates the next <paramref name="count"/> numbers of the sequence.
    /// </summary>
    /// <param name="count">Number of values to calculate.</param>
    public void Calculate(int count)
    {
        // Set starting values.
        _fibList.Clear();
        _fibList.Add(StartingValues.InitialFirst);
        _fibList.Add(StartingValues.InitialSecond);

        int i = 0;
        if (StartingValues.InitialFirst.IsZero)
        {
            PrintInitialValues();
            i = 2;
        }
        // Calculate and print the numbers.
        for (; i < count; i++)
        {
            Console.WriteLine(NextNumber());
        }

        // Set the last two calculated numbers as starting values for next iteration.
        StartingValues = (_fibList[^2], _fibList[^1]);
    }

    /// <summary>
    /// Calculates the next value in the sequence.
    /// </summary>
    /// <returns>The new value.</returns>
    private BigInteger NextNumber() => _fibList.AddAndReturn(_fibList[^1] + _fibList[^2]);

    /// <summary>
    /// Prints the starting values.
    /// </summary>
    private void PrintInitialValues()
    {
        Console.WriteLine(_fibList[0]);
        Console.WriteLine(_fibList[1]);
    }
}
