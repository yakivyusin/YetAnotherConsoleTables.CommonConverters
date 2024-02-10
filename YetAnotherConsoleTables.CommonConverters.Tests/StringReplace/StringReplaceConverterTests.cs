using YetAnotherConsoleTables.CommonConverters.StringReplace;

namespace YetAnotherConsoleTables.CommonConverters.Tests.StringReplace;

public class StringReplaceConverterTests : BaseTests
{
    private class IntReplace
    {
        [TableMemberConverter<StringReplaceConverter>(ConstructorArgs = new object[] { "0", "1" })]
        public int Value { get; set; }
    }

    private class StringReplace
    {
        [TableMemberConverter<StringReplaceConverter>(ConstructorArgs = new object[] { "test", "tast" })]
        public string Value { get; set; }
    }

    [Theory]
    [InlineData(0, "| 1     |")]
    [InlineData(10, "| 11    |")]
    [InlineData(21, "| 21    |")]
    public void IntReplaceTest(int value, string expected)
    {
        ConsoleTable.From(new[] { new IntReplace { Value = value } }).Write(_writer);

        Assert.Equal(expected, ValueLine);
    }

    [Theory]
    [InlineData(null, "|       |")]
    [InlineData("", "|       |")]
    [InlineData("test", "| tast  |")]
    public void StringReplaceTest(string value, string expected)
    {
        ConsoleTable.From(new[] { new StringReplace { Value = value } }).Write(_writer);

        Assert.Equal(expected, ValueLine);
    }
}
