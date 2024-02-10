using YetAnotherConsoleTables.CommonConverters.Chain;
using YetAnotherConsoleTables.CommonConverters.ValueChange;

namespace YetAnotherConsoleTables.CommonConverters.Tests.Chain;

public class ChainedConverter_2Tests : BaseTests
{
    private class PrependAppendValue
    {
        [TableMemberConverter<ChainedConverter<PrependValueConverter, AppendValueConverter>>(ConstructorArgs = new object[]
        {
            new object[] { "prefix:" },
            new object[] { ":suffix" }
        })]
        public int Value { get; set; }
    }

    private class PrependPrependValue
    {
        [TableMemberConverter<ChainedConverter<PrependValueConverter, PrependValueConverter>>(ConstructorArgs = new object[]
        {
            new object[] { "prefix1:" },
            new object[] { "prefix2:" }
        })]
        public int Value { get; set; }
    }

    [Theory]
    [InlineData(0, "| prefix:0:suffix |")]
    [InlineData(1000, "| prefix:1000:suffix |")]
    public void PrependAppendValueTest(int value, string expected)
    {
        ConsoleTable.From(new[] { new PrependAppendValue { Value = value } }).Write(_writer);

        Assert.Equal(expected, ValueLine);
    }

    [Theory]
    [InlineData(0, "| prefix2:prefix1:0 |")]
    [InlineData(1000, "| prefix2:prefix1:1000 |")]
    public void PrependPrependValueTest(int value, string expected)
    {
        ConsoleTable.From(new[] { new PrependPrependValue { Value = value } }).Write(_writer);

        Assert.Equal(expected, ValueLine);
    }
}
