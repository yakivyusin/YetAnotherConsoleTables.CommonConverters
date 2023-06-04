using System;

namespace YetAnotherConsoleTables.CommonConverters.ValueChange
{
    public class PrependValueConverter : TableMemberConverter
    {
        private readonly object _prefix;

        public PrependValueConverter(object prefix) => _prefix = prefix;

        public override bool CanConvert(Type objectType) => true;

        public override string Convert(object value) => $"{_prefix}{value}";
    }
}
