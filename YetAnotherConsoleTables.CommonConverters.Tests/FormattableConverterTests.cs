namespace YetAnotherConsoleTables.CommonConverters.Tests;

public class FormattableConverterTests : BaseTests
{
    private class DateTimeFormat
    {
        [TableMemberConverter<FormattableConverter>(ConstructorArgs = new object[] { "HH:mm:ss" })]
        public DateTime Value { get; set; }
    }

    private class DoubleFormat
    {
        [TableMemberConverter<FormattableConverter>(ConstructorArgs = new object[] { "C", "en-GB" })]
        public double Value { get; set; }
    }

    private class FloatFormat
    {
        [TableMemberConverter<FormattableConverter>(ConstructorArgs = new object[] { "", "en-US" })]
        public float Value { get; set; }
    }

    [Theory]
    [MemberData(nameof(GetDataForDateTimeFormat))]
    public void DateTimeFormatTest(DateTime value, string expected)
    {
        ConsoleTable.From(new[] { new DateTimeFormat { Value = value } }).Write(_writer);

        Assert.Equal(expected, ValueLine);
    }

    [Theory]
    [InlineData(0.5, "| £0.50 |")]
    [InlineData(1.0, "| £1.00 |")]
    [InlineData(1.5, "| £1.50 |")]
    public void DoubleFormatTest(double value, string expected)
    {
        ConsoleTable.From(new[] { new DoubleFormat { Value = value } }).Write(_writer);

        Assert.Equal(expected, ValueLine);
    }

    [Theory]
    [InlineData(0.5f, "| 0.5   |")]
    [InlineData(1.0f, "| 1     |")]
    [InlineData(1.5f, "| 1.5   |")]
    public void FloatFormatTest(float value, string expected)
    {
        ConsoleTable.From(new[] { new FloatFormat { Value = value } }).Write(_writer);

        Assert.Equal(expected, ValueLine);
    }

    public static IEnumerable<object[]> GetDataForDateTimeFormat()
    {
        yield return new object[]
        {
            new DateTime(1, 1, 1, 0, 0, 0),
            "| 00:00:00 |"
        };

        yield return new object[]
        {
            new DateTime(1, 1, 1, 20, 21, 24),
            "| 20:21:24 |"
        };
    }
}
