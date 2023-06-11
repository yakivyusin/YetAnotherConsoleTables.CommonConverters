using System;
using System.Globalization;

namespace YetAnotherConsoleTables.CommonConverters
{
    /// <summary>
    /// Converter to call <see cref="IFormattable.ToString(string, IFormatProvider)"/> with the format specified OR the format and the specific culture. To initialize the converter, pass a single string (the format) or two strings (the format and the culture code).
    /// </summary>
    public class FormattableConverter : TableMemberConverter<IFormattable>
    {
        private readonly string _format;
        private readonly CultureInfo _culture;

        /// <summary>
        /// Initializes the converter with the format only.
        /// </summary>
        public FormattableConverter(string format) : this(format, null)
        {
        }

        /// <summary>
        /// Initializes the converter with the format and the culture code.
        /// </summary>
        public FormattableConverter(string format, string cultureCode)
        {
            _format = format;

            if (cultureCode != null)
            {
                _culture = CultureInfo.GetCultureInfo(cultureCode);
            }
        }

        /// <inheritdoc />
        public override string Convert(IFormattable value) => value.ToString(_format, _culture);
    }
}
