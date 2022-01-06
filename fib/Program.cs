namespace Fibonacci;

internal static class Program
{
    private static void Main(string[] args)
    {
        Fibonacci fibonacci = new();

        string input = ParseInput(args);

        if (Int32.TryParse(input, out int count))
        {
            do
            {
                fibonacci.Calculate(count);
            }
            while (PromptForMore(count));
        }
        else
        {
            Console.WriteLine($"[{input}] is not a valid integer.");
        }
    }

    private static string ParseInput(string[] args)
    {
        if (args.Length is > 1)
        {
            Console.WriteLine("Only first argument is considered.");
        }

        string? input;

        if (args.Length is >= 1)
        {
            input = args[0];
        }
        else
        {
            Console.Write("How many nymbers to calculate? : ");
            do
            {
                input = Console.ReadLine();
                if (input is null) break;
            } while (input.Any(x => Char.IsDigit(x) is false));

           input ??= "null";
        }

        return input;
    }

    /// <summary>
    /// Prompts about calculating more numbers.
    /// </summary>
    /// <param name="count">The number of numbers to prompt for.</param>
    /// <remarks>The prompt removes itself from console in case of positive confirmation.</remarks>
    /// <returns><see langword="true"/> if user wants more. <see langword="false"/> otherwise.</returns>
    private static bool PromptForMore(int count)
    {
        Console.WriteLine($"Press <ENTER> for [{count}] more numbers.");
        return Console.ReadKey(true).Key is ConsoleKey.Enter
            && ClearLastRow();
    }

    /// <summary>
    /// Clears the previously printed row from console.
    /// </summary>
    /// <returns>Always <see langword="true"/>.</returns>
    private static bool ClearLastRow()
    {
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.Write(new string(' ', Console.BufferWidth));
        Console.CursorLeft = 0;
        return true;
    }
}
