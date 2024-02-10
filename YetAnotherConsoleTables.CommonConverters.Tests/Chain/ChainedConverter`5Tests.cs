using YetAnotherConsoleTables.CommonConverters.Chain;
using YetAnotherConsoleTables.CommonConverters.ValueChange;

namespace YetAnotherConsoleTables.CommonConverters.Tests.Chain;

public class ChainedConverter_5Tests : BaseTests
{
    private class PrependAppendPrependAppendPrependValue
    {
        [TableMemberConverter<ChainedConverter<
            PrependValueConverter,
            AppendValueConverter,
            PrependValueConverter,
            AppendValueConverter,
            PrependValueConverter>>(ConstructorArgs = new object[]
        {
            new object[] { "prefix1:" },
            new object[] { ":suffix1" },
            new object[] { "prefix2:" },
            new object[] { ":suffix2" },
            new object[] { "prefix3:" }
        })]
        public int Value { get; set; }
    }

    private class PrependPrependPrependPrependPrependValue
    {
        [TableMemberConverter<ChainedConverter<
            PrependValueConverter,
            PrependValueConverter,
            PrependValueConverter,
            PrependValueConverter,
            PrependValueConverter>>(ConstructorArgs = new object[]
        {
            new object[] { "prefix1:" },
            new object[] { "prefix2:" },
            new object[] { "prefix3:" },
            new object[] { "prefix4:" },
            new object[] { "prefix5:" }
        })]
        public int Value { get; set; }
    }

    [Theory]
    [InlineData(0, "| prefix3:prefix2:prefix1:0:suffix1:suffix2 |")]
    [InlineData(1000, "| prefix3:prefix2:prefix1:1000:suffix1:suffix2 |")]
    public void PrependAppendPrependAppendPrependValueTest(int value, string expected)
    {
        ConsoleTable.From(new[] { new PrependAppendPrependAppendPrependValue { Value = value } }).Write(_writer);

        Assert.Equal(expected, ValueLine);
    }

    [Theory]
    [InlineData(0, "| prefix5:prefix4:prefix3:prefix2:prefix1:0 |")]
    [InlineData(1000, "| prefix5:prefix4:prefix3:prefix2:prefix1:1000 |")]
    public void PrependPrependPrependPrependPrependValueTest(int value, string expected)
    {
        ConsoleTable.From(new[] { new PrependPrependPrependPrependPrependValue { Value = value } }).Write(_writer);

        Assert.Equal(expected, ValueLine);
    }
}
