using System;

namespace YetAnotherConsoleTables.CommonConverters.ValueChange
{
    public class WrapValueConverter : TableMemberConverter
    {
        private readonly object _prefix;
        private readonly object _suffix;

        public WrapValueConverter(object prefix, object suffix)
        {
            _prefix = prefix;
            _suffix = suffix;
        }

        public override bool CanConvert(Type objectType) => true;

        public override string Convert(object value) => $"{_prefix}{value}{_suffix}";
    }
}
