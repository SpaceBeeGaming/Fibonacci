namespace Fibonacci;

public static class Extensions
{
    /// <summary>
    /// Adds the <paramref name="value"/> to the <paramref name="collection"/> and returns the <paramref name="value"/>./>.
    /// </summary>
    /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
    /// <param name="collection">The collection to add the <paramref name="value"/> to.</param>
    /// <param name="value">The value to add.</param>
    /// <returns>The added <paramref name="value"/>.</returns>
    public static T AddAndReturn<T>(this ICollection<T> collection, T value)
    {
        _ = collection ?? throw new ArgumentNullException(nameof(collection));
        _ = value ?? throw new ArgumentNullException(nameof(value));

        collection.Add(value);
        return value;
    }
}