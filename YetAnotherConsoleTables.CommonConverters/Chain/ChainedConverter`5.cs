namespace YetAnotherConsoleTables.CommonConverters.Chain
{
    public class ChainedConverter<T1, T2, T3, T4, T5> : BaseChainedConverter
        where T1 : TableMemberConverter
        where T2 : TableMemberConverter
        where T3 : TableMemberConverter
        where T4 : TableMemberConverter
        where T5 : TableMemberConverter
    {
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
