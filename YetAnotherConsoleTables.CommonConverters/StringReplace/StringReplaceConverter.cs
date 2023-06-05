using System;

namespace YetAnotherConsoleTables.CommonConverters.StringReplace
{
    public class StringReplaceConverter : TableMemberConverter
    {
        private readonly string _oldValue;
        private readonly string _newValue;

        public StringReplaceConverter(string oldValue, string newValue)
        {
            _oldValue = oldValue;
            _newValue = newValue;
        }

        public override bool CanConvert(Type objectType) => true;

        public override string Convert(object value) => value?.ToString().Replace(_oldValue, _newValue);
    }
}
