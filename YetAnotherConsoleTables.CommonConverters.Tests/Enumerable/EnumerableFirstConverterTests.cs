using YetAnotherConsoleTables.CommonConverters.Enumerable;

namespace YetAnotherConsoleTables.CommonConverters.Tests.Enumerable
{
    public class EnumerableFirstConverterTests : BaseTests
    {
        private class StructEnumerable
        {
            [TableMemberConverter<EnumerableFirstConverter<int>>(ConstructorArgs = new object[] { false })]
            public int[] Value { get; set; }
        }

        private class StructEnumerableOrDefault
        {
            [TableMemberConverter<EnumerableFirstConverter<int>>]
            public int[] Value { get; set; }
        }

        private class ObjectEnumerable
        {
            [TableMemberConverter<EnumerableFirstConverter<string>>(ConstructorArgs = new object[] { false })]
            public string[] Value { get; set; }
        }

        private class ObjectEnumerableOrDefault
        {
            [TableMemberConverter<EnumerableFirstConverter<string>>]
            public string[] Value { get; set; }
        }

        [Theory]
        [InlineData(new int[] { 1, 2 }, "| 1     |")]
        public void StructEnumerableTest(int[] value, string expected)
        {
            ConsoleTable.From(new[] { new StructEnumerable { Value = value } }).Write(_writer);

            Assert.Equal(expected, ValueLine);
        }

        [Theory]
        [InlineData(new int[] { 1, 2 }, "| 1     |")]
        [InlineData(new int[0], "| 0     |")]
        public void StructEnumerableOrDefaultTest(int[] value, string expected)
        {
            ConsoleTable.From(new[] { new StructEnumerableOrDefault { Value = value } }).Write(_writer);

            Assert.Equal(expected, ValueLine);
        }

        [Theory]
        [InlineData(new string[] { "a", "b" }, "| a     |")]
        public void ObjectEnumerableTest(string[] value, string expected)
        {
            ConsoleTable.From(new[] { new ObjectEnumerable { Value = value } }).Write(_writer);

            Assert.Equal(expected, ValueLine);
        }

        [Theory]
        [InlineData(new string[] { "a", "b" }, "| a     |")]
        [InlineData(new string[0], "|       |")]
        public void ObjectEnumerableOrDefaultTest(string[] value, string expected)
        {
            ConsoleTable.From(new[] { new ObjectEnumerableOrDefault { Value = value } }).Write(_writer);

            Assert.Equal(expected, ValueLine);
        }

        [Fact]
        public void ThrowWithoutOrDefault()
        {
            Assert.Throws<InvalidOperationException>(() => ConsoleTable.From(new[] { new StructEnumerable
            {
                Value = new int[0]
            }}).Write(_writer));

            Assert.Throws<InvalidOperationException>(() => ConsoleTable.From(new[] { new ObjectEnumerable
            {
                Value = new string[0]
            }}).Write(_writer));
        }
    }
}
