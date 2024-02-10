using System.Collections.Generic;

namespace YetAnotherConsoleTables.CommonConverters.Enumerable
{
    /// <summary>
    /// Joins the original IEnumerable&lt;<typeparamref name="T"/>&gt; using the passed <see langword="string"/> separator.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EnumerableJoinConverter<T> : TableMemberConverter<IEnumerable<T>>
    {
        private readonly string _separator;

        /// <summary>
        /// Initializes the converter.
        /// </summary>
        public EnumerableJoinConverter(string separator) => _separator = separator;

        /// <inheritdoc />
        public override string Convert(IEnumerable<T> value) => string.Join(_separator, value);
    }
}
