using YetAnotherConsoleTables.CommonConverters.StringReplace;

namespace YetAnotherConsoleTables.CommonConverters.Tests.StringReplace
{
    public class RegexReplaceConverterTests : BaseTests
    {
        private class StringReplace
        {
            [TableMemberConverter<RegexReplaceConverter>(ConstructorArgs = new object[] { "\\d", "-" })]
            public string Value { get; set; }
        }

        [Theory]
        [InlineData(null, "|       |")]
        [InlineData("", "|       |")]
        [InlineData("test0", "| test- |")]
        public void StringReplaceTest(string value, string expected)
        {
            ConsoleTable.From(new[] { new StringReplace { Value = value } }).Write(_writer);

            Assert.Equal(expected, ValueLine);
        }
    }
}
