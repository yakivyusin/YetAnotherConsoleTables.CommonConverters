using System.Collections.Generic;
using System.Linq;

namespace YetAnotherConsoleTables.CommonConverters.Enumerable
{
    /// <summary>
    /// Uses the last member of the original IEnumerable&lt;<typeparamref name="T"/>&gt;. 
    /// <para>You can initialize the converter with the boolean value - use LastOrDefault (<see langword="true" />; default value w/o parameter) or Last (<see langword="false"/>).</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EnumerableLastConverter<T> : TableMemberConverter<IEnumerable<T>>
    {
        private readonly bool _orDefault = true;

        /// <summary>
        /// Initializes the converter.
        /// </summary>
        public EnumerableLastConverter() { }

        /// <summary>
        /// Initializes the converter.
        /// </summary>
        public EnumerableLastConverter(bool orDefault) => _orDefault = orDefault;

        /// <inheritdoc />
        public override string Convert(IEnumerable<T> value) => (_orDefault ? value.LastOrDefault() : value.Last())?.ToString();
    }
}
