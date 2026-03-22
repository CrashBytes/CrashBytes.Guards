using System.Text.RegularExpressions;

namespace CrashBytes.Guards;

/// <summary>
/// Extension methods on <see cref="IGuardClause"/> providing guard clause validations.
/// Each method throws the appropriate exception when the guard condition is violated,
/// and returns the input value when valid for fluent chaining.
/// </summary>
public static class GuardClauseExtensions
{
    // ──────────────────────────────────────────────
    //  Null / Empty checks
    // ──────────────────────────────────────────────

    /// <summary>
    /// Throws <see cref="ArgumentNullException"/> if <paramref name="value"/> is <c>null</c>.
    /// </summary>
    /// <typeparam name="T">The type of the value being guarded.</typeparam>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The non-null <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is <c>null</c>.</exception>
    public static T Null<T>(this IGuardClause guardClause, T? value, string paramName)
    {
        if (value is null)
        {
            throw new ArgumentNullException(paramName, $"Value cannot be null. (Parameter '{paramName}')");
        }

        return value;
    }

    /// <summary>
    /// Throws <see cref="ArgumentException"/> if the string <paramref name="value"/> is <c>null</c> or empty.
    /// </summary>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="value">The string value to check.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The non-null, non-empty <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is <c>null</c> or empty.</exception>
    public static string NullOrEmpty(this IGuardClause guardClause, string? value, string paramName)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException($"Value cannot be null or empty. (Parameter '{paramName}')", paramName);
        }

        return value;
    }

    /// <summary>
    /// Throws <see cref="ArgumentException"/> if the string <paramref name="value"/> is <c>null</c>, empty, or consists only of whitespace.
    /// </summary>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="value">The string value to check.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The non-null, non-empty, non-whitespace <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is <c>null</c>, empty, or whitespace.</exception>
    public static string NullOrWhiteSpace(this IGuardClause guardClause, string? value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(
                $"Value cannot be null, empty, or whitespace. (Parameter '{paramName}')", paramName);
        }

        return value;
    }

    /// <summary>
    /// Throws <see cref="ArgumentException"/> if the collection <paramref name="value"/> is <c>null</c> or empty.
    /// </summary>
    /// <typeparam name="T">The element type of the collection.</typeparam>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="value">The collection to check.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The non-null, non-empty <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is <c>null</c> or contains no elements.</exception>
    public static IEnumerable<T> NullOrEmpty<T>(this IGuardClause guardClause, IEnumerable<T>? value, string paramName)
    {
        if (value is null || !value.Any())
        {
            throw new ArgumentException(
                $"Collection cannot be null or empty. (Parameter '{paramName}')", paramName);
        }

        return value;
    }

    // ──────────────────────────────────────────────
    //  Range / comparison checks
    // ──────────────────────────────────────────────

    /// <summary>
    /// Throws <see cref="ArgumentException"/> if the integer <paramref name="value"/> is zero.
    /// </summary>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The non-zero <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is zero.</exception>
    public static int Zero(this IGuardClause guardClause, int value, string paramName)
    {
        if (value == 0)
        {
            throw new ArgumentException($"Value cannot be zero. (Parameter '{paramName}')", paramName);
        }

        return value;
    }

    /// <summary>
    /// Throws <see cref="ArgumentException"/> if the decimal <paramref name="value"/> is zero.
    /// </summary>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The non-zero <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is zero.</exception>
    public static decimal Zero(this IGuardClause guardClause, decimal value, string paramName)
    {
        if (value == 0m)
        {
            throw new ArgumentException($"Value cannot be zero. (Parameter '{paramName}')", paramName);
        }

        return value;
    }

    /// <summary>
    /// Throws <see cref="ArgumentException"/> if the integer <paramref name="value"/> is negative.
    /// </summary>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The non-negative <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is less than zero.</exception>
    public static int Negative(this IGuardClause guardClause, int value, string paramName)
    {
        if (value < 0)
        {
            throw new ArgumentException(
                $"Value cannot be negative. Value was {value}. (Parameter '{paramName}')", paramName);
        }

        return value;
    }

    /// <summary>
    /// Throws <see cref="ArgumentException"/> if the decimal <paramref name="value"/> is negative.
    /// </summary>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The non-negative <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is less than zero.</exception>
    public static decimal Negative(this IGuardClause guardClause, decimal value, string paramName)
    {
        if (value < 0m)
        {
            throw new ArgumentException(
                $"Value cannot be negative. Value was {value}. (Parameter '{paramName}')", paramName);
        }

        return value;
    }

    /// <summary>
    /// Throws <see cref="ArgumentException"/> if the integer <paramref name="value"/> is negative or zero.
    /// </summary>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The positive <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is less than or equal to zero.</exception>
    public static int NegativeOrZero(this IGuardClause guardClause, int value, string paramName)
    {
        if (value <= 0)
        {
            throw new ArgumentException(
                $"Value cannot be negative or zero. Value was {value}. (Parameter '{paramName}')", paramName);
        }

        return value;
    }

    /// <summary>
    /// Throws <see cref="ArgumentException"/> if the decimal <paramref name="value"/> is negative or zero.
    /// </summary>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The positive <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is less than or equal to zero.</exception>
    public static decimal NegativeOrZero(this IGuardClause guardClause, decimal value, string paramName)
    {
        if (value <= 0m)
        {
            throw new ArgumentException(
                $"Value cannot be negative or zero. Value was {value}. (Parameter '{paramName}')", paramName);
        }

        return value;
    }

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the integer <paramref name="value"/> is outside the specified range.
    /// </summary>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="min">The minimum allowed value (inclusive).</param>
    /// <param name="max">The maximum allowed value (inclusive).</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The in-range <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="value"/> is outside [<paramref name="min"/>, <paramref name="max"/>].</exception>
    public static int OutOfRange(this IGuardClause guardClause, int value, int min, int max, string paramName)
    {
        if (value < min || value > max)
        {
            throw new ArgumentOutOfRangeException(
                paramName, value, $"Value {value} is out of range [{min}, {max}]. (Parameter '{paramName}')");
        }

        return value;
    }

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the decimal <paramref name="value"/> is outside the specified range.
    /// </summary>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="min">The minimum allowed value (inclusive).</param>
    /// <param name="max">The maximum allowed value (inclusive).</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The in-range <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="value"/> is outside [<paramref name="min"/>, <paramref name="max"/>].</exception>
    public static decimal OutOfRange(this IGuardClause guardClause, decimal value, decimal min, decimal max,
        string paramName)
    {
        if (value < min || value > max)
        {
            throw new ArgumentOutOfRangeException(
                paramName, value, $"Value {value} is out of range [{min}, {max}]. (Parameter '{paramName}')");
        }

        return value;
    }

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the integer <paramref name="value"/> is greater than <paramref name="max"/>.
    /// </summary>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="max">The maximum allowed value (inclusive).</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The <paramref name="value"/> that does not exceed <paramref name="max"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="value"/> is greater than <paramref name="max"/>.</exception>
    public static int GreaterThan(this IGuardClause guardClause, int value, int max, string paramName)
    {
        if (value > max)
        {
            throw new ArgumentOutOfRangeException(
                paramName, value, $"Value {value} is greater than maximum {max}. (Parameter '{paramName}')");
        }

        return value;
    }

    /// <summary>
    /// Throws <see cref="ArgumentOutOfRangeException"/> if the integer <paramref name="value"/> is less than <paramref name="min"/>.
    /// </summary>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="value">The value to check.</param>
    /// <param name="min">The minimum allowed value (inclusive).</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The <paramref name="value"/> that is not less than <paramref name="min"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="value"/> is less than <paramref name="min"/>.</exception>
    public static int LessThan(this IGuardClause guardClause, int value, int min, string paramName)
    {
        if (value < min)
        {
            throw new ArgumentOutOfRangeException(
                paramName, value, $"Value {value} is less than minimum {min}. (Parameter '{paramName}')");
        }

        return value;
    }

    // ──────────────────────────────────────────────
    //  String format checks
    // ──────────────────────────────────────────────

    /// <summary>
    /// Throws <see cref="ArgumentException"/> if <paramref name="value"/> is not a valid email address format.
    /// </summary>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="value">The string to check.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The valid email <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not a valid email format.</exception>
    public static string InvalidEmail(this IGuardClause guardClause, string value, string paramName)
    {
        if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            throw new ArgumentException(
                $"Value is not a valid email address. (Parameter '{paramName}')", paramName);
        }

        return value;
    }

    /// <summary>
    /// Throws <see cref="ArgumentException"/> if <paramref name="value"/> is not a valid HTTP or HTTPS URL.
    /// </summary>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="value">The string to check.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The valid URL <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not a valid HTTP/HTTPS URL.</exception>
    public static string InvalidUrl(this IGuardClause guardClause, string value, string paramName)
    {
        if (!Uri.TryCreate(value, UriKind.Absolute, out var uri) ||
            (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
        {
            throw new ArgumentException(
                $"Value is not a valid HTTP/HTTPS URL. (Parameter '{paramName}')", paramName);
        }

        return value;
    }

    /// <summary>
    /// Throws <see cref="ArgumentException"/> if <paramref name="value"/> does not match the specified regex <paramref name="pattern"/>.
    /// </summary>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="value">The string to check.</param>
    /// <param name="pattern">The regex pattern to match against.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The <paramref name="value"/> that matches the pattern.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> does not match <paramref name="pattern"/>.</exception>
    public static string InvalidRegex(this IGuardClause guardClause, string value, string pattern, string paramName)
    {
        if (!Regex.IsMatch(value, pattern))
        {
            throw new ArgumentException(
                $"Value does not match the required pattern '{pattern}'. (Parameter '{paramName}')", paramName);
        }

        return value;
    }

    /// <summary>
    /// Throws <see cref="ArgumentException"/> if the string <paramref name="value"/> length exceeds <paramref name="maxLength"/>.
    /// </summary>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="value">The string to check.</param>
    /// <param name="maxLength">The maximum allowed length.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The <paramref name="value"/> whose length does not exceed <paramref name="maxLength"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when the string length exceeds <paramref name="maxLength"/>.</exception>
    public static string StringTooLong(this IGuardClause guardClause, string value, int maxLength, string paramName)
    {
        if (value.Length > maxLength)
        {
            throw new ArgumentException(
                $"String length {value.Length} exceeds maximum length {maxLength}. (Parameter '{paramName}')",
                paramName);
        }

        return value;
    }

    /// <summary>
    /// Throws <see cref="ArgumentException"/> if the string <paramref name="value"/> length is less than <paramref name="minLength"/>.
    /// </summary>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="value">The string to check.</param>
    /// <param name="minLength">The minimum required length.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The <paramref name="value"/> whose length is at least <paramref name="minLength"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when the string length is less than <paramref name="minLength"/>.</exception>
    public static string StringTooShort(this IGuardClause guardClause, string value, int minLength, string paramName)
    {
        if (value.Length < minLength)
        {
            throw new ArgumentException(
                $"String length {value.Length} is less than minimum length {minLength}. (Parameter '{paramName}')",
                paramName);
        }

        return value;
    }

    // ──────────────────────────────────────────────
    //  GUID check
    // ──────────────────────────────────────────────

    /// <summary>
    /// Throws <see cref="ArgumentException"/> if <paramref name="value"/> is <see cref="Guid.Empty"/>.
    /// </summary>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="value">The GUID to check.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The non-empty <paramref name="value"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is <see cref="Guid.Empty"/>.</exception>
    public static Guid EmptyGuid(this IGuardClause guardClause, Guid value, string paramName)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException($"GUID cannot be empty. (Parameter '{paramName}')", paramName);
        }

        return value;
    }

    // ──────────────────────────────────────────────
    //  DateTime checks
    // ──────────────────────────────────────────────

    /// <summary>
    /// Throws <see cref="ArgumentException"/> if <paramref name="value"/> is in the past (before <see cref="DateTime.UtcNow"/>).
    /// </summary>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="value">The date/time value to check.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The <paramref name="value"/> that is not in the past.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is before <see cref="DateTime.UtcNow"/>.</exception>
    public static DateTime Past(this IGuardClause guardClause, DateTime value, string paramName)
    {
        if (value < DateTime.UtcNow)
        {
            throw new ArgumentException(
                $"Value cannot be in the past. Value was {value:O}. (Parameter '{paramName}')", paramName);
        }

        return value;
    }

    /// <summary>
    /// Throws <see cref="ArgumentException"/> if <paramref name="value"/> is in the future (after <see cref="DateTime.UtcNow"/>).
    /// </summary>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="value">The date/time value to check.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The <paramref name="value"/> that is not in the future.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is after <see cref="DateTime.UtcNow"/>.</exception>
    public static DateTime Future(this IGuardClause guardClause, DateTime value, string paramName)
    {
        if (value > DateTime.UtcNow)
        {
            throw new ArgumentException(
                $"Value cannot be in the future. Value was {value:O}. (Parameter '{paramName}')", paramName);
        }

        return value;
    }

    // ──────────────────────────────────────────────
    //  Predicate check
    // ──────────────────────────────────────────────

    /// <summary>
    /// Throws <see cref="ArgumentException"/> if the <paramref name="predicate"/> returns <c>true</c> for <paramref name="value"/>.
    /// Use this to guard against a condition being met.
    /// </summary>
    /// <typeparam name="T">The type of the value being guarded.</typeparam>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="value">The value to evaluate.</param>
    /// <param name="predicate">The predicate that, if <c>true</c>, indicates an invalid condition.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <param name="message">An optional custom error message.</param>
    /// <returns>The <paramref name="value"/> for which the predicate returned <c>false</c>.</returns>
    /// <exception cref="ArgumentException">Thrown when the <paramref name="predicate"/> returns <c>true</c>.</exception>
    public static T Predicate<T>(this IGuardClause guardClause, T value, Func<T, bool> predicate, string paramName,
        string? message = null)
    {
        if (predicate(value))
        {
            throw new ArgumentException(
                message ?? $"Value does not satisfy the required condition. (Parameter '{paramName}')", paramName);
        }

        return value;
    }

    // ──────────────────────────────────────────────
    //  File system checks
    // ──────────────────────────────────────────────

    /// <summary>
    /// Throws <see cref="FileNotFoundException"/> if the file at <paramref name="path"/> does not exist.
    /// </summary>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="path">The file path to check.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The <paramref name="path"/> to an existing file.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the file does not exist.</exception>
    public static string FileNotFound(this IGuardClause guardClause, string path, string paramName)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException(
                $"File not found. (Parameter '{paramName}')", path);
        }

        return path;
    }

    /// <summary>
    /// Throws <see cref="DirectoryNotFoundException"/> if the directory at <paramref name="path"/> does not exist.
    /// </summary>
    /// <param name="guardClause">The guard clause instance.</param>
    /// <param name="path">The directory path to check.</param>
    /// <param name="paramName">The name of the parameter being guarded.</param>
    /// <returns>The <paramref name="path"/> to an existing directory.</returns>
    /// <exception cref="DirectoryNotFoundException">Thrown when the directory does not exist.</exception>
    public static string DirectoryNotFound(this IGuardClause guardClause, string path, string paramName)
    {
        if (!Directory.Exists(path))
        {
            throw new DirectoryNotFoundException(
                $"Directory not found: '{path}'. (Parameter '{paramName}')");
        }

        return path;
    }
}
