namespace DnHttp;

/// <summary>
/// Wrapper class for thread-safe generation of pseudo-random numbers.
/// Lazy-load singleton for ThreadStatic <see cref="Random"/>.
/// </summary>
public static class Randomizer
{
    [ThreadStatic] private static Random? _rand;

    private static Random Generate() =>
        new(Guid.NewGuid().GetHashCode());

    public static Random Instance => _rand ??= Generate();
}
