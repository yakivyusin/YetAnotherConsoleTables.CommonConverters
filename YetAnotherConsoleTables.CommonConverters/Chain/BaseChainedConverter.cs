using System;
using System.Collections.Generic;
using System.Linq;

namespace YetAnotherConsoleTables.CommonConverters.Chain
{
    /// <summary>
    /// Base abstract class for chain converters.
    /// </summary>
    public abstract class BaseChainedConverter : TableMemberConverter
    {
        private readonly List<TableMemberConverter> _converters = new List<TableMemberConverter>();

        /// <summary>
        /// Constructor to be called from derived types.
        /// </summary>
        /// <param name="converterTypes">Converter types to chain.</param>
        /// <param name="converterArguments">Array of arrays with arguments to converters constructors.</param>
        /// <exception cref="ArgumentException">
        ///     <para>If <paramref name="converterTypes"/> is null or its length &lt; 2.</para>
        ///     <para>If <paramref name="converterArguments"/> is null or its length != <paramref name="converterTypes"/> length.</para>
        /// </exception>
        public BaseChainedConverter(Type[] converterTypes, object[][] converterArguments)
        {
            if (converterTypes?.Length < 2 || converterArguments?.Length != converterTypes.Length)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < converterTypes.Length; i++)
            {
                var ctor = converterTypes[i].GetConstructor(converterArguments[i].Select(x => x.GetType()).ToArray());

                _converters.Add((TableMemberConverter)ctor.Invoke(converterArguments[i]));
            }
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType) =>
            _converters[0].CanConvert(objectType) &&
            _converters.Skip(1).All(c => c.CanConvert(typeof(string)));

        /// <inheritdoc />
        public override string Convert(object value)
        {
            var result = _converters[0].Convert(value);

            foreach (var converter in _converters.Skip(1))
            {
                result = converter.Convert(result);
            }

            return result;
        }
    }
}
