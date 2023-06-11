using System;

namespace YetAnotherConsoleTables.CommonConverters.StringReplace
{
    /// <summary>
    /// Converter to perform <see cref="string.Replace(string, string)"/> on an object string representation. To initialize the converter, pass two strings - oldValue and newValue.
    /// </summary>
    public class StringReplaceConverter : TableMemberConverter
    {
        private readonly string _oldValue;
        private readonly string _newValue;

        /// <summary>
        /// Initializes the converter.
        /// </summary>
        public StringReplaceConverter(string oldValue, string newValue)
        {
            _oldValue = oldValue;
            _newValue = newValue;
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType) => true;

        /// <inheritdoc />
        public override string Convert(object value) => value?.ToString().Replace(_oldValue, _newValue);
    }
}
