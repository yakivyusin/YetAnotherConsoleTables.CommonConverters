using YetAnotherConsoleTables.CommonConverters.Enumerable;

namespace YetAnotherConsoleTables.CommonConverters.Tests.Enumerable;

public class EnumerableLastConverterTests : BaseTests
{
    private class StructEnumerable
    {
        [TableMemberConverter<EnumerableLastConverter<int>>(ConstructorArgs = new object[] { false })]
        public int[] Value { get; set; }
    }

    private class StructEnumerableOrDefault
    {
        [TableMemberConverter<EnumerableLastConverter<int>>]
        public int[] Value { get; set; }
    }

    private class ObjectEnumerable
    {
        [TableMemberConverter<EnumerableLastConverter<string>>(ConstructorArgs = new object[] { false })]
        public string[] Value { get; set; }
    }

    private class ObjectEnumerableOrDefault
    {
        [TableMemberConverter<EnumerableLastConverter<string>>]
        public string[] Value { get; set; }
    }

    [Theory]
    [InlineData(new int[] { 1, 2 }, "| 2     |")]
    public void StructEnumerableTest(int[] value, string expected)
    {
        ConsoleTable.From(new[] { new StructEnumerable { Value = value } }).Write(_writer);

        Assert.Equal(expected, ValueLine);
    }

    [Theory]
    [InlineData(new int[] { 1, 2 }, "| 2     |")]
    [InlineData(new int[0], "| 0     |")]
    public void StructEnumerableOrDefaultTest(int[] value, string expected)
    {
        ConsoleTable.From(new[] { new StructEnumerableOrDefault { Value = value } }).Write(_writer);

        Assert.Equal(expected, ValueLine);
    }

    [Theory]
    [InlineData(new string[] { "a", "b" }, "| b     |")]
    public void ObjectEnumerableTest(string[] value, string expected)
    {
        ConsoleTable.From(new[] { new ObjectEnumerable { Value = value } }).Write(_writer);

        Assert.Equal(expected, ValueLine);
    }

    [Theory]
    [InlineData(new string[] { "a", "b" }, "| b     |")]
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
