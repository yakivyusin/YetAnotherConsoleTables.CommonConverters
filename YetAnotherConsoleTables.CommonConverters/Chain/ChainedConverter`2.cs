namespace YetAnotherConsoleTables.CommonConverters.Chain
{
    /// <summary>
    /// Chain of two converters: <typeparamref name="T2"/>(<typeparamref name="T1"/>(value)). To initialize the converter, pass two object arrays - constructor arguments for the first and second.
    /// <para><typeparamref name="T1"/> must support conversion of the target field/property type.</para>
    /// <para><typeparamref name="T2"/> must support conversion of <see cref="System.String"/>.</para>
    /// </summary>
    public class ChainedConverter<T1, T2> : BaseChainedConverter
        where T1 : TableMemberConverter
        where T2 : TableMemberConverter
    {
        /// <summary>
        /// Initializes the converter.
        /// </summary>
        public ChainedConverter(
            object[] converterArguments1,
            object[] converterArguments2) :
            base(
                new[] { typeof(T1), typeof(T2) },
                new[] { converterArguments1, converterArguments2 })
        {
        }
    }
}
