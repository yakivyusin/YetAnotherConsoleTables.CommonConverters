using System;
using System.Collections.Generic;
using System.Linq;

namespace YetAnotherConsoleTables.CommonConverters.Chain
{
    public abstract class BaseChainedConverter : TableMemberConverter
    {
        private readonly List<TableMemberConverter> _converters = new List<TableMemberConverter>();

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

        public override bool CanConvert(Type objectType) =>
            _converters[0].CanConvert(objectType) &&
            _converters.Skip(1).All(c => c.CanConvert(typeof(string)));

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
