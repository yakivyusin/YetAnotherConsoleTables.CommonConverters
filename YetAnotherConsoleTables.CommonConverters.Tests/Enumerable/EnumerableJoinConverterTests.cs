using YetAnotherConsoleTables.CommonConverters.Enumerable;

namespace YetAnotherConsoleTables.CommonConverters.Tests.Enumerable
{
    public class EnumerableJoinConverterTests : BaseTests
    {
        private class EnumerableJoin
        {
            [TableMemberConverter<EnumerableJoinConverter<int>>(ConstructorArgs = new object[] { ", " })]
            public int[] Value { get; set; }
        }

        [Theory]
        [InlineData(new[] { 1, 2 }, "| 1, 2  |")]
        [InlineData(new[] { 1, 2, 3 }, "| 1, 2, 3 |")]
        [InlineData(new int[0], "|       |")]
        public void EnumerableJoinTest(int[] value, string expected)
        {
            ConsoleTable.From(new[] { new EnumerableJoin { Value = value } }).Write(_writer);

            Assert.Equal(expected, ValueLine);
        }
    }
}
