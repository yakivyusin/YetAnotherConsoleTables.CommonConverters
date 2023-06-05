using YetAnotherConsoleTables.CommonConverters.ValueChange;

namespace YetAnotherConsoleTables.CommonConverters.Tests.ValueChange
{
    public class WrapValueConverterTests : BaseTests
    {
        private class WrapStringWithStringAndInt
        {
            [TableMemberConverter<WrapValueConverter>(ConstructorArgs = new object[] { "prefix:", 1 })]
            public string Value { get; set; }
        }

        private class WrapIntWithStringAndString
        {
            [TableMemberConverter<WrapValueConverter>(ConstructorArgs = new object[] { "prefix:", ":suffix" })]
            public int Value { get; set; }
        }

        [Theory]
        [InlineData(null, "| prefix:1 |")]
        [InlineData("", "| prefix:1 |")]
        [InlineData("test", "| prefix:test1 |")]
        public void WrapStringWithStringAndIntTest(string value, string expected)
        {
            ConsoleTable.From(new[] { new WrapStringWithStringAndInt { Value = value } }).Write(_writer);

            Assert.Equal(expected, ValueLine);
        }

        [Theory]
        [InlineData(0, "| prefix:0:suffix |")]
        [InlineData(1000, "| prefix:1000:suffix |")]
        public void WrapIntWithStringAndStringTest(int value, string expected)
        {
            ConsoleTable.From(new[] { new WrapIntWithStringAndString { Value = value } }).Write(_writer);

            Assert.Equal(expected, ValueLine);
        }
    }
}
