namespace YetAnotherConsoleTables.CommonConverters.Chain
{
    /// <summary>
    /// Chain of three converters: <typeparamref name="T3"/>(<typeparamref name="T2"/>(<typeparamref name="T1"/>(value))). To initialize the converter, pass three object arrays - constructor arguments for each converter.
    /// <para><typeparamref name="T1"/> must support conversion of the target field/property type.</para>
    /// <para><typeparamref name="T2"/> and <typeparamref name="T3"/> must support conversion of <see cref="System.String"/>.</para>
    /// </summary>
    public class ChainedConverter<T1, T2, T3> : BaseChainedConverter
        where T1 : TableMemberConverter
        where T2 : TableMemberConverter
        where T3 : TableMemberConverter
    {
        /// <summary>
        /// Initializes the converter.
        /// </summary>
        public ChainedConverter(
            object[] converterArguments1,
            object[] converterArguments2,
            object[] converterArguments3) :
            base(
                new[] { typeof(T1), typeof(T2), typeof(T3) },
                new[] { converterArguments1, converterArguments2, converterArguments3 })
        {
        }
    }
}
