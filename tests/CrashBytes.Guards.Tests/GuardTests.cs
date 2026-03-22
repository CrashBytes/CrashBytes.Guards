namespace CrashBytes.Guards.Tests;

public class GuardNullTests
{
    [Fact]
    public void Null_NullValue_ThrowsArgumentNullException()
    {
        string? value = null;
        Assert.Throws<ArgumentNullException>(() => Guard.Against.Null(value, nameof(value)));
    }

    [Fact]
    public void Null_NonNullValue_ReturnsValue()
    {
        var result = Guard.Against.Null("hello", "param");
        Assert.Equal("hello", result);
    }

    [Fact]
    public void Null_NonNullObject_ReturnsValue()
    {
        var obj = new object();
        var result = Guard.Against.Null(obj, "param");
        Assert.Same(obj, result);
    }
}

public class GuardNullOrEmptyStringTests
{
    [Fact]
    public void NullOrEmpty_NullString_ThrowsArgumentException()
    {
        string? value = null;
        Assert.Throws<ArgumentException>(() => Guard.Against.NullOrEmpty(value, nameof(value)));
    }

    [Fact]
    public void NullOrEmpty_EmptyString_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Guard.Against.NullOrEmpty(string.Empty, "param"));
    }

    [Fact]
    public void NullOrEmpty_ValidString_ReturnsValue()
    {
        var result = Guard.Against.NullOrEmpty("hello", "param");
        Assert.Equal("hello", result);
    }

    [Fact]
    public void NullOrEmpty_WhitespaceString_ReturnsValue()
    {
        var result = Guard.Against.NullOrEmpty("  ", "param");
        Assert.Equal("  ", result);
    }
}

public class GuardNullOrWhiteSpaceTests
{
    [Fact]
    public void NullOrWhiteSpace_NullString_ThrowsArgumentException()
    {
        string? value = null;
        Assert.Throws<ArgumentException>(() => Guard.Against.NullOrWhiteSpace(value, nameof(value)));
    }

    [Fact]
    public void NullOrWhiteSpace_EmptyString_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Guard.Against.NullOrWhiteSpace(string.Empty, "param"));
    }

    [Fact]
    public void NullOrWhiteSpace_WhitespaceString_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Guard.Against.NullOrWhiteSpace("   ", "param"));
    }

    [Fact]
    public void NullOrWhiteSpace_ValidString_ReturnsValue()
    {
        var result = Guard.Against.NullOrWhiteSpace("hello", "param");
        Assert.Equal("hello", result);
    }
}

public class GuardNullOrEmptyCollectionTests
{
    [Fact]
    public void NullOrEmpty_NullCollection_ThrowsArgumentException()
    {
        IEnumerable<int>? value = null;
        Assert.Throws<ArgumentException>(() => Guard.Against.NullOrEmpty(value, nameof(value)));
    }

    [Fact]
    public void NullOrEmpty_EmptyCollection_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Guard.Against.NullOrEmpty(Array.Empty<int>(), "param"));
    }

    [Fact]
    public void NullOrEmpty_NonEmptyCollection_ReturnsValue()
    {
        var collection = new[] { 1, 2, 3 };
        var result = Guard.Against.NullOrEmpty(collection, "param");
        Assert.Equal(collection, result);
    }
}

public class GuardZeroTests
{
    [Fact]
    public void Zero_Int_ZeroValue_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Guard.Against.Zero(0, "param"));
    }

    [Fact]
    public void Zero_Int_NonZeroValue_ReturnsValue()
    {
        Assert.Equal(5, Guard.Against.Zero(5, "param"));
    }

    [Fact]
    public void Zero_Int_NegativeValue_ReturnsValue()
    {
        Assert.Equal(-3, Guard.Against.Zero(-3, "param"));
    }

    [Fact]
    public void Zero_Decimal_ZeroValue_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Guard.Against.Zero(0m, "param"));
    }

    [Fact]
    public void Zero_Decimal_NonZeroValue_ReturnsValue()
    {
        Assert.Equal(5.5m, Guard.Against.Zero(5.5m, "param"));
    }
}

public class GuardNegativeTests
{
    [Fact]
    public void Negative_Int_NegativeValue_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Guard.Against.Negative(-1, "param"));
    }

    [Fact]
    public void Negative_Int_ZeroValue_ReturnsValue()
    {
        Assert.Equal(0, Guard.Against.Negative(0, "param"));
    }

    [Fact]
    public void Negative_Int_PositiveValue_ReturnsValue()
    {
        Assert.Equal(5, Guard.Against.Negative(5, "param"));
    }

    [Fact]
    public void Negative_Decimal_NegativeValue_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Guard.Against.Negative(-0.01m, "param"));
    }

    [Fact]
    public void Negative_Decimal_ZeroValue_ReturnsValue()
    {
        Assert.Equal(0m, Guard.Against.Negative(0m, "param"));
    }

    [Fact]
    public void Negative_Decimal_PositiveValue_ReturnsValue()
    {
        Assert.Equal(5.5m, Guard.Against.Negative(5.5m, "param"));
    }
}

public class GuardNegativeOrZeroTests
{
    [Fact]
    public void NegativeOrZero_Int_NegativeValue_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Guard.Against.NegativeOrZero(-1, "param"));
    }

    [Fact]
    public void NegativeOrZero_Int_ZeroValue_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Guard.Against.NegativeOrZero(0, "param"));
    }

    [Fact]
    public void NegativeOrZero_Int_PositiveValue_ReturnsValue()
    {
        Assert.Equal(5, Guard.Against.NegativeOrZero(5, "param"));
    }

    [Fact]
    public void NegativeOrZero_Decimal_NegativeValue_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Guard.Against.NegativeOrZero(-0.01m, "param"));
    }

    [Fact]
    public void NegativeOrZero_Decimal_ZeroValue_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Guard.Against.NegativeOrZero(0m, "param"));
    }

    [Fact]
    public void NegativeOrZero_Decimal_PositiveValue_ReturnsValue()
    {
        Assert.Equal(1.5m, Guard.Against.NegativeOrZero(1.5m, "param"));
    }
}

public class GuardOutOfRangeTests
{
    [Fact]
    public void OutOfRange_Int_BelowMin_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Against.OutOfRange(0, 1, 10, "param"));
    }

    [Fact]
    public void OutOfRange_Int_AboveMax_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Against.OutOfRange(11, 1, 10, "param"));
    }

    [Fact]
    public void OutOfRange_Int_AtMin_ReturnsValue()
    {
        Assert.Equal(1, Guard.Against.OutOfRange(1, 1, 10, "param"));
    }

    [Fact]
    public void OutOfRange_Int_AtMax_ReturnsValue()
    {
        Assert.Equal(10, Guard.Against.OutOfRange(10, 1, 10, "param"));
    }

    [Fact]
    public void OutOfRange_Int_InRange_ReturnsValue()
    {
        Assert.Equal(5, Guard.Against.OutOfRange(5, 1, 10, "param"));
    }

    [Fact]
    public void OutOfRange_Decimal_BelowMin_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Against.OutOfRange(0.5m, 1m, 10m, "param"));
    }

    [Fact]
    public void OutOfRange_Decimal_AboveMax_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Against.OutOfRange(10.5m, 1m, 10m, "param"));
    }

    [Fact]
    public void OutOfRange_Decimal_InRange_ReturnsValue()
    {
        Assert.Equal(5.5m, Guard.Against.OutOfRange(5.5m, 1m, 10m, "param"));
    }
}

public class GuardGreaterThanTests
{
    [Fact]
    public void GreaterThan_AboveMax_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Against.GreaterThan(11, 10, "param"));
    }

    [Fact]
    public void GreaterThan_AtMax_ReturnsValue()
    {
        Assert.Equal(10, Guard.Against.GreaterThan(10, 10, "param"));
    }

    [Fact]
    public void GreaterThan_BelowMax_ReturnsValue()
    {
        Assert.Equal(5, Guard.Against.GreaterThan(5, 10, "param"));
    }
}

public class GuardLessThanTests
{
    [Fact]
    public void LessThan_BelowMin_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Against.LessThan(0, 1, "param"));
    }

    [Fact]
    public void LessThan_AtMin_ReturnsValue()
    {
        Assert.Equal(1, Guard.Against.LessThan(1, 1, "param"));
    }

    [Fact]
    public void LessThan_AboveMin_ReturnsValue()
    {
        Assert.Equal(5, Guard.Against.LessThan(5, 1, "param"));
    }
}

public class GuardInvalidEmailTests
{
    [Theory]
    [InlineData("test@example.com")]
    [InlineData("user.name@domain.co.uk")]
    [InlineData("user+tag@example.com")]
    public void InvalidEmail_ValidEmail_ReturnsValue(string email)
    {
        var result = Guard.Against.InvalidEmail(email, "param");
        Assert.Equal(email, result);
    }

    [Theory]
    [InlineData("notanemail")]
    [InlineData("@domain.com")]
    [InlineData("user@")]
    [InlineData("user@domain")]
    public void InvalidEmail_InvalidEmail_ThrowsArgumentException(string email)
    {
        Assert.Throws<ArgumentException>(() => Guard.Against.InvalidEmail(email, "param"));
    }
}

public class GuardInvalidUrlTests
{
    [Theory]
    [InlineData("https://example.com")]
    [InlineData("http://example.com")]
    [InlineData("https://example.com/path?query=1")]
    public void InvalidUrl_ValidUrl_ReturnsValue(string url)
    {
        var result = Guard.Against.InvalidUrl(url, "param");
        Assert.Equal(url, result);
    }

    [Theory]
    [InlineData("not-a-url")]
    [InlineData("ftp://example.com")]
    [InlineData("example.com")]
    public void InvalidUrl_InvalidUrl_ThrowsArgumentException(string url)
    {
        Assert.Throws<ArgumentException>(() => Guard.Against.InvalidUrl(url, "param"));
    }
}

public class GuardInvalidRegexTests
{
    [Fact]
    public void InvalidRegex_Matches_ReturnsValue()
    {
        var result = Guard.Against.InvalidRegex("abc123", @"^[a-z]+\d+$", "param");
        Assert.Equal("abc123", result);
    }

    [Fact]
    public void InvalidRegex_DoesNotMatch_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Guard.Against.InvalidRegex("ABC", @"^[a-z]+$", "param"));
    }
}

public class GuardStringTooLongTests
{
    [Fact]
    public void StringTooLong_ExceedsMax_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Guard.Against.StringTooLong("Hello World", 5, "param"));
    }

    [Fact]
    public void StringTooLong_ExactlyMax_ReturnsValue()
    {
        var result = Guard.Against.StringTooLong("Hello", 5, "param");
        Assert.Equal("Hello", result);
    }

    [Fact]
    public void StringTooLong_UnderMax_ReturnsValue()
    {
        var result = Guard.Against.StringTooLong("Hi", 5, "param");
        Assert.Equal("Hi", result);
    }
}

public class GuardStringTooShortTests
{
    [Fact]
    public void StringTooShort_BelowMin_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Guard.Against.StringTooShort("Hi", 5, "param"));
    }

    [Fact]
    public void StringTooShort_ExactlyMin_ReturnsValue()
    {
        var result = Guard.Against.StringTooShort("Hello", 5, "param");
        Assert.Equal("Hello", result);
    }

    [Fact]
    public void StringTooShort_OverMin_ReturnsValue()
    {
        var result = Guard.Against.StringTooShort("Hello World", 5, "param");
        Assert.Equal("Hello World", result);
    }
}

public class GuardEmptyGuidTests
{
    [Fact]
    public void EmptyGuid_EmptyValue_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Guard.Against.EmptyGuid(Guid.Empty, "param"));
    }

    [Fact]
    public void EmptyGuid_ValidGuid_ReturnsValue()
    {
        var guid = Guid.NewGuid();
        var result = Guard.Against.EmptyGuid(guid, "param");
        Assert.Equal(guid, result);
    }
}

public class GuardPastTests
{
    [Fact]
    public void Past_PastDate_ThrowsArgumentException()
    {
        var pastDate = DateTime.UtcNow.AddDays(-1);
        Assert.Throws<ArgumentException>(() => Guard.Against.Past(pastDate, "param"));
    }

    [Fact]
    public void Past_FutureDate_ReturnsValue()
    {
        var futureDate = DateTime.UtcNow.AddDays(1);
        var result = Guard.Against.Past(futureDate, "param");
        Assert.Equal(futureDate, result);
    }
}

public class GuardFutureTests
{
    [Fact]
    public void Future_FutureDate_ThrowsArgumentException()
    {
        var futureDate = DateTime.UtcNow.AddDays(1);
        Assert.Throws<ArgumentException>(() => Guard.Against.Future(futureDate, "param"));
    }

    [Fact]
    public void Future_PastDate_ReturnsValue()
    {
        var pastDate = DateTime.UtcNow.AddDays(-1);
        var result = Guard.Against.Future(pastDate, "param");
        Assert.Equal(pastDate, result);
    }
}

public class GuardPredicateTests
{
    [Fact]
    public void Predicate_ConditionMet_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            Guard.Against.Predicate(5, x => x > 3, "param"));
    }

    [Fact]
    public void Predicate_ConditionNotMet_ReturnsValue()
    {
        var result = Guard.Against.Predicate(2, x => x > 3, "param");
        Assert.Equal(2, result);
    }

    [Fact]
    public void Predicate_CustomMessage_UsesMessage()
    {
        var ex = Assert.Throws<ArgumentException>(() =>
            Guard.Against.Predicate(5, x => x > 3, "param", "Value must not exceed 3."));
        Assert.Contains("Value must not exceed 3.", ex.Message);
    }

    [Fact]
    public void Predicate_DefaultMessage_ContainsParamName()
    {
        var ex = Assert.Throws<ArgumentException>(() =>
            Guard.Against.Predicate(5, x => x > 3, "myParam"));
        Assert.Contains("myParam", ex.Message);
    }
}

public class GuardFileNotFoundTests
{
    [Fact]
    public void FileNotFound_NonExistentFile_ThrowsFileNotFoundException()
    {
        Assert.Throws<FileNotFoundException>(() =>
            Guard.Against.FileNotFound("/nonexistent/path/file.txt", "param"));
    }

    [Fact]
    public void FileNotFound_ExistingFile_ReturnsPath()
    {
        var tempFile = Path.GetTempFileName();
        try
        {
            var result = Guard.Against.FileNotFound(tempFile, "param");
            Assert.Equal(tempFile, result);
        }
        finally
        {
            File.Delete(tempFile);
        }
    }
}

public class GuardDirectoryNotFoundTests
{
    [Fact]
    public void DirectoryNotFound_NonExistentDirectory_ThrowsDirectoryNotFoundException()
    {
        Assert.Throws<DirectoryNotFoundException>(() =>
            Guard.Against.DirectoryNotFound("/nonexistent/directory/path", "param"));
    }

    [Fact]
    public void DirectoryNotFound_ExistingDirectory_ReturnsPath()
    {
        var tempDir = Path.GetTempPath();
        var result = Guard.Against.DirectoryNotFound(tempDir, "param");
        Assert.Equal(tempDir, result);
    }
}

public class GuardFluentChainingTests
{
    [Fact]
    public void Guard_Against_ReturnsIGuardClause()
    {
        Assert.IsAssignableFrom<IGuardClause>(Guard.Against);
    }

    [Fact]
    public void Guard_FluentChaining_AllowsMultipleGuards()
    {
        string value = "hello@example.com";
        var result = Guard.Against.NullOrEmpty(value, "email");
        Guard.Against.InvalidEmail(result, "email");
    }
}
