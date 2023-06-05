using YetAnotherConsoleTables.CommonConverters.Chain;
using YetAnotherConsoleTables.CommonConverters.ValueChange;

namespace YetAnotherConsoleTables.CommonConverters.Tests.Chain
{
    public class ChainedConverter_3Tests : BaseTests
    {
        private class PrependAppendPrependValue
        {
            [TableMemberConverter<ChainedConverter<PrependValueConverter, AppendValueConverter, PrependValueConverter>>(ConstructorArgs = new object[]
            {
                new object[] { "prefix1:" },
                new object[] { ":suffix" },
                new object[] { "prefix2:" }
            })]
            public int Value { get; set; }
        }

        private class PrependPrependPrependValue
        {
            [TableMemberConverter<ChainedConverter<PrependValueConverter, PrependValueConverter, PrependValueConverter>>(ConstructorArgs = new object[]
            {
                new object[] { "prefix1:" },
                new object[] { "prefix2:" },
                new object[] { "prefix3:" }
            })]
            public int Value { get; set; }
        }

        [Theory]
        [InlineData(0, "| prefix2:prefix1:0:suffix |")]
        [InlineData(1000, "| prefix2:prefix1:1000:suffix |")]
        public void PrependAppendPrependValueTest(int value, string expected)
        {
            ConsoleTable.From(new[] { new PrependAppendPrependValue { Value = value } }).Write(_writer);

            Assert.Equal(expected, ValueLine);
        }

        [Theory]
        [InlineData(0, "| prefix3:prefix2:prefix1:0 |")]
        [InlineData(1000, "| prefix3:prefix2:prefix1:1000 |")]
        public void PrependPrependPrependValueTest(int value, string expected)
        {
            ConsoleTable.From(new[] { new PrependPrependPrependValue { Value = value } }).Write(_writer);

            Assert.Equal(expected, ValueLine);
        }
    }
}
