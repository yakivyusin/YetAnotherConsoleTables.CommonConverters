using System.Collections.Generic;
using System.Linq;

namespace YetAnotherConsoleTables.CommonConverters.Enumerable
{
    /// <summary>
    /// Uses the first member of the original IEnumerable&lt;<typeparamref name="T"/>&gt;. 
    /// <para>You can initialize the converter with the boolean value - use FirstOrDefault (default value w/o parameter) or First.</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EnumerableFirstConverter<T> : TableMemberConverter<IEnumerable<T>>
    {
        private readonly bool _orDefault = true;

        /// <summary>
        /// Initializes the converter.
        /// </summary>
        public EnumerableFirstConverter() { }

        /// <summary>
        /// Initializes the converter.
        /// </summary>
        public EnumerableFirstConverter(bool orDefault) => _orDefault = orDefault;

        /// <inheritdoc />
        public override string Convert(IEnumerable<T> value) => (_orDefault ? value.FirstOrDefault() : value.First())?.ToString();
    }
}
