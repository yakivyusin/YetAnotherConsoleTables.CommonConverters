using System;

namespace YetAnotherConsoleTables.CommonConverters.ValueChange
{
    /// <summary>
    /// Prepends and appends the original value with string representations of the specified objects. To initialize the converter, pass two objects - prefix and suffix.
    /// <para>This converter is equivalent to <seealso cref="Chain.ChainedConverter{PrependValueConverter, T2}"/> with <seealso cref="PrependValueConverter"/> and <seealso cref="AppendValueConverter"/>.</para>
    /// </summary>
    public class WrapValueConverter : TableMemberConverter
    {
        private readonly object _prefix;
        private readonly object _suffix;

        /// <summary>
        /// Initializes the converter.
        /// </summary>
        public WrapValueConverter(object prefix, object suffix)
        {
            _prefix = prefix;
            _suffix = suffix;
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType) => true;

        /// <inheritdoc />
        public override string Convert(object value) => $"{_prefix}{value}{_suffix}";
    }
}
