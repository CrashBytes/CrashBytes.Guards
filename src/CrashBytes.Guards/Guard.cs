namespace CrashBytes.Guards;

/// <summary>
/// Entry point for guard clause validation. Use <c>Guard.Against</c> to access guard methods.
/// </summary>
public static class Guard
{
    /// <summary>
    /// Gets the guard clause instance for fluent validation.
    /// </summary>
    /// <example>
    /// <code>
    /// var name = Guard.Against.NullOrEmpty(input, nameof(input));
    /// </code>
    /// </example>
    public static IGuardClause Against { get; } = new GuardClause();
}
