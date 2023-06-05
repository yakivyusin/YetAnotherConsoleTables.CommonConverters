using System;
using System.Globalization;

namespace YetAnotherConsoleTables.CommonConverters
{
    public class FormattableConverter : TableMemberConverter<IFormattable>
    {
        private readonly string _format;
        private readonly CultureInfo _culture;

        public FormattableConverter(string format) : this(format, null)
        {
        }

        public FormattableConverter(string format, string cultureCode)
        {
            _format = format;

            if (cultureCode != null)
            {
                _culture = CultureInfo.GetCultureInfo(cultureCode);
            }
        }

        public override string Convert(IFormattable value) => value.ToString(_format, _culture);
    }
}
