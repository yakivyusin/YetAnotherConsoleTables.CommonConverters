using System;
using System.Text.RegularExpressions;

namespace YetAnotherConsoleTables.CommonConverters.StringReplace
{
    public class RegexReplaceConverter : TableMemberConverter
    {
        private readonly string _pattern;
        private readonly string _replacement;

        public RegexReplaceConverter(string pattern, string replacement)
        {
            _pattern = pattern;
            _replacement = replacement;
        }

        public override bool CanConvert(Type objectType) => true;

        public override string Convert(object value) => value == null ?
            null :
            Regex.Replace(value.ToString(), _pattern, _replacement);
    }
}
