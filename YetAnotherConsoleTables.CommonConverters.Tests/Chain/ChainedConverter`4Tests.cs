using YetAnotherConsoleTables.CommonConverters.Chain;
using YetAnotherConsoleTables.CommonConverters.ValueChange;

namespace YetAnotherConsoleTables.CommonConverters.Tests.Chain
{
    public class ChainedConverter_4Tests : BaseTests
    {
        private class PrependAppendPrependAppendValue
        {
            [TableMemberConverter<ChainedConverter<
                PrependValueConverter,
                AppendValueConverter,
                PrependValueConverter,
                AppendValueConverter>>(ConstructorArgs = new object[]
            {
                new object[] { "prefix1:" },
                new object[] { ":suffix1" },
                new object[] { "prefix2:" },
                new object[] { ":suffix2" }
            })]
            public int Value { get; set; }
        }

        private class PrependPrependPrependPrependValue
        {
            [TableMemberConverter<ChainedConverter<
                PrependValueConverter,
                PrependValueConverter,
                PrependValueConverter,
                PrependValueConverter>>(ConstructorArgs = new object[]
            {
                new object[] { "prefix1:" },
                new object[] { "prefix2:" },
                new object[] { "prefix3:" },
                new object[] { "prefix4:" }
            })]
            public int Value { get; set; }
        }

        [Theory]
        [InlineData(0, "| prefix2:prefix1:0:suffix1:suffix2 |")]
        [InlineData(1000, "| prefix2:prefix1:1000:suffix1:suffix2 |")]
        public void PrependAppendPrependAppendValueTest(int value, string expected)
        {
            ConsoleTable.From(new[] { new PrependAppendPrependAppendValue { Value = value } }).Write(_writer);

            Assert.Equal(expected, ValueLine);
        }

        [Theory]
        [InlineData(0, "| prefix4:prefix3:prefix2:prefix1:0 |")]
        [InlineData(1000, "| prefix4:prefix3:prefix2:prefix1:1000 |")]
        public void PrependPrependPrependPrependValueTest(int value, string expected)
        {
            ConsoleTable.From(new[] { new PrependPrependPrependPrependValue { Value = value } }).Write(_writer);

            Assert.Equal(expected, ValueLine);
        }
    }
}
