namespace YetAnotherConsoleTables.CommonConverters.ChainConverters
{
    public class ChainedConverter<T1, T2, T3> : BaseChainedConverter
        where T1 : TableMemberConverter
        where T2 : TableMemberConverter
        where T3 : TableMemberConverter
    {
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
