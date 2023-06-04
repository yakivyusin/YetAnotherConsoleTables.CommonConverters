using YetAnotherConsoleTables.CommonConverters.ValueChange;

namespace YetAnotherConsoleTables.CommonConverters.Tests.ValueChange
{
    public class PrependValueConverterTests
    {
        private class PrependIntToString
        {
            [TableMemberConverter<PrependValueConverter>(ConstructorArgs = new object[] { 5 })]
            public string Value { get; set; }
        }

        private class PrependStringToString
        {
            [TableMemberConverter<PrependValueConverter>(ConstructorArgs = new object[] { "prefix:" })]
            public string Value { get; set; }
        }

        private class PrependStringToInt
        {
            [TableMemberConverter<PrependValueConverter>(ConstructorArgs = new object[] { "prefix:" })]
            public int Value { get; set; }
        }

        private readonly StringWriter _writer = new();

        private string ValueLine => _writer.ToString().Split(_writer.NewLine, StringSplitOptions.RemoveEmptyEntries)[3];

        [Theory]
        [InlineData(null, "| 5     |")]
        [InlineData("", "| 5     |")]
        [InlineData("test", "| 5test |")]
        public void PrependIntToStringTest(string value, string expected)
        {
            ConsoleTable.From(new[] { new PrependIntToString { Value = value } }).Write(_writer);

            Assert.Equal(expected, ValueLine);
        }

        [Theory]
        [InlineData(null, "| prefix: |")]
        [InlineData("", "| prefix: |")]
        [InlineData("test", "| prefix:test |")]
        public void PrependStringToStringTest(string value, string expected)
        {
            ConsoleTable.From(new[] { new PrependStringToString { Value = value } }).Write(_writer);

            Assert.Equal(expected, ValueLine);
        }

        [Theory]
        [InlineData(0, "| prefix:0 |")]
        [InlineData(1000, "| prefix:1000 |")]
        public void PrependStringToIntTest(int value, string expected)
        {
            ConsoleTable.From(new[] { new PrependStringToInt { Value = value } }).Write(_writer);

            Assert.Equal(expected, ValueLine);
        }
    }
}
