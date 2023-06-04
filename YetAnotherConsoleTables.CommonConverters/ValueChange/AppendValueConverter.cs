using System;

namespace YetAnotherConsoleTables.CommonConverters.ValueChange
{
    public class AppendValueConverter : TableMemberConverter
    {
        private readonly object _suffix;

        public AppendValueConverter(object suffix) => _suffix = suffix;

        public override bool CanConvert(Type objectType) => true;

        public override string Convert(object value) => $"{value}{_suffix}";
    }
}
