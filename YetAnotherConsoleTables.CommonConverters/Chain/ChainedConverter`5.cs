namespace YetAnotherConsoleTables.CommonConverters.Chain
{
    /// <summary>
    /// Chain of five converters: <typeparamref name="T5"/>(<typeparamref name="T4"/>(<typeparamref name="T3"/>(<typeparamref name="T2"/>(<typeparamref name="T1"/>(value))))). To initialize the converter, pass five object arrays - constructor arguments for each converter.
    /// <para><typeparamref name="T1"/> must support conversion of the target field/property type.</para>
    /// <para><typeparamref name="T2"/>, <typeparamref name="T3"/>, <typeparamref name="T4"/> and <typeparamref name="T5"/> must support conversion of <see cref="System.String"/>.</para>
    /// </summary>
    public class ChainedConverter<T1, T2, T3, T4, T5> : BaseChainedConverter
        where T1 : TableMemberConverter
        where T2 : TableMemberConverter
        where T3 : TableMemberConverter
        where T4 : TableMemberConverter
        where T5 : TableMemberConverter
    {
        /// <summary>
        /// Initializes the converter.
        /// </summary>
        public ChainedConverter(
            object[] converterArguments1,
            object[] converterArguments2,
            object[] converterArguments3,
            object[] converterArguments4,
            object[] converterArguments5) :
            base(
                new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) },
                new[] { converterArguments1, converterArguments2, converterArguments3, converterArguments4, converterArguments5 })
        {
        }
    }
}
