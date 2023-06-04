using YetAnotherConsoleTables.CommonConverters.ChainConverters;
using YetAnotherConsoleTables.CommonConverters.ValueChange;

namespace YetAnotherConsoleTables.CommonConverters.Tests.ChainConverters
{
    public class ChainedConverter_6Tests : BaseTests
    {
        private class PrependAppendPrependAppendPrependAppendValue
        {
            [TableMemberConverter<ChainedConverter<
                PrependValueConverter,
                AppendValueConverter,
                PrependValueConverter,
                AppendValueConverter,
                ChainedConverter<PrependValueConverter, AppendValueConverter>>>(ConstructorArgs = new object[]
            {
                new object[] { "prefix1:" },
                new object[] { ":suffix1" },
                new object[] { "prefix2:" },
                new object[] { ":suffix2" },
                new object[]
                {
                    new object[] { "prefix3:" },
                    new object[] { ":suffix3" }
                }
            })]
            public int Value { get; set; }
        }

        private class PrependPrependPrependPrependPrependPrependValue
        {
            [TableMemberConverter<ChainedConverter<
                PrependValueConverter,
                PrependValueConverter,
                PrependValueConverter,
                PrependValueConverter,
                ChainedConverter<PrependValueConverter, PrependValueConverter>>>(ConstructorArgs = new object[]
            {
                new object[] { "prefix1:" },
                new object[] { "prefix2:" },
                new object[] { "prefix3:" },
                new object[] { "prefix4:" },
                new object[]
                {
                    new object[] { "prefix5:" },
                    new object[] { "prefix6:" }
                }
            })]
            public int Value { get; set; }
        }

        [Theory]
        [InlineData(0, "| prefix3:prefix2:prefix1:0:suffix1:suffix2:suffix3 |")]
        [InlineData(1000, "| prefix3:prefix2:prefix1:1000:suffix1:suffix2:suffix3 |")]
        public void PrependAppendPrependAppendPrependAppendValueTest(int value, string expected)
        {
            ConsoleTable.From(new[] { new PrependAppendPrependAppendPrependAppendValue { Value = value } }).Write(_writer);

            Assert.Equal(expected, ValueLine);
        }

        [Theory]
        [InlineData(0, "| prefix6:prefix5:prefix4:prefix3:prefix2:prefix1:0 |")]
        [InlineData(1000, "| prefix6:prefix5:prefix4:prefix3:prefix2:prefix1:1000 |")]
        public void PrependPrependPrependPrependPrependPrependValueTest(int value, string expected)
        {
            ConsoleTable.From(new[] { new PrependPrependPrependPrependPrependPrependValue { Value = value } }).Write(_writer);

            Assert.Equal(expected, ValueLine);
        }
    }
}
