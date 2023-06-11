using System;
using System.Text.RegularExpressions;

namespace YetAnotherConsoleTables.CommonConverters.StringReplace
{
    /// <summary>
    /// Converter to perform <see cref="Regex.Replace(string, string, string)"/> on an object string representation. To initialize the converter, pass two strings - pattern and replacement.
    /// </summary>
    public class RegexReplaceConverter : TableMemberConverter
    {
        private readonly string _pattern;
        private readonly string _replacement;

        /// <summary>
        /// Initializes the converter.
        /// </summary>
        public RegexReplaceConverter(string pattern, string replacement)
        {
            _pattern = pattern;
            _replacement = replacement;
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType) => true;

        /// <inheritdoc />
        public override string Convert(object value) => value == null ?
            null :
            Regex.Replace(value.ToString(), _pattern, _replacement);
    }
}
