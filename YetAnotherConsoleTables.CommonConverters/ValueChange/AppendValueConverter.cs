using System;

namespace YetAnotherConsoleTables.CommonConverters.ValueChange
{
    /// <summary>
    /// Appends the specified object string representation to the original value. To initialize the converter, pass a single object - the suffix to append.
    /// </summary>
    public class AppendValueConverter : TableMemberConverter
    {
        private readonly object _suffix;

        /// <summary>
        /// Initializes the converter.
        /// </summary>
        public AppendValueConverter(object suffix) => _suffix = suffix;

        /// <inheritdoc />
        public override bool CanConvert(Type objectType) => true;

        /// <inheritdoc />
        public override string Convert(object value) => $"{value}{_suffix}";
    }
}
