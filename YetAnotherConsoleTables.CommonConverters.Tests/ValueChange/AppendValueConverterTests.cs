using YetAnotherConsoleTables.CommonConverters.ValueChange;

namespace YetAnotherConsoleTables.CommonConverters.Tests.ValueChange;

public class AppendValueConverterTests : BaseTests
{
    private class AppendIntToString
    {
        [TableMemberConverter<AppendValueConverter>(ConstructorArgs = new object[] { 5 })]
        public string Value { get; set; }
    }

    private class AppendStringToString
    {
        [TableMemberConverter<AppendValueConverter>(ConstructorArgs = new object[] { ":suffix" })]
        public string Value { get; set; }
    }

    private class AppendStringToInt
    {
        [TableMemberConverter<AppendValueConverter>(ConstructorArgs = new object[] { ":suffix" })]
        public int Value { get; set; }
    }

    [Theory]
    [InlineData(null, "| 5     |")]
    [InlineData("", "| 5     |")]
    [InlineData("test", "| test5 |")]
    public void AppendIntToStringTest(string value, string expected)
    {
        ConsoleTable.From(new[] { new AppendIntToString { Value = value } }).Write(_writer);

        Assert.Equal(expected, ValueLine);
    }

    [Theory]
    [InlineData(null, "| :suffix |")]
    [InlineData("", "| :suffix |")]
    [InlineData("test", "| test:suffix |")]
    public void AppendStringToStringTest(string value, string expected)
    {
        ConsoleTable.From(new[] { new AppendStringToString { Value = value } }).Write(_writer);

        Assert.Equal(expected, ValueLine);
    }

    [Theory]
    [InlineData(0, "| 0:suffix |")]
    [InlineData(1000, "| 1000:suffix |")]
    public void AppendStringToIntTest(int value, string expected)
    {
        ConsoleTable.From(new[] { new AppendStringToInt { Value = value } }).Write(_writer);

        Assert.Equal(expected, ValueLine);
    }
}
