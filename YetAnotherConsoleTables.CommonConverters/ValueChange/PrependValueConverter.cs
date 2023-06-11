using System;

namespace YetAnotherConsoleTables.CommonConverters.ValueChange
{
    /// <summary>
    /// Prepends the specified object string representation to the original value. To initialize the converter, pass a single object - the prefix to prepend.
    /// </summary>
    public class PrependValueConverter : TableMemberConverter
    {
        private readonly object _prefix;

        /// <summary>
        /// Initializes the converter.
        /// </summary>
        public PrependValueConverter(object prefix) => _prefix = prefix;

        /// <inheritdoc />
        public override bool CanConvert(Type objectType) => true;

        /// <inheritdoc />
        public override string Convert(object value) => $"{_prefix}{value}";
    }
}
