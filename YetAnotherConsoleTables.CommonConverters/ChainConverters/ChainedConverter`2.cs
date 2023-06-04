namespace YetAnotherConsoleTables.CommonConverters.ChainConverters
{
    public class ChainedConverter<T1, T2> : BaseChainedConverter
        where T1 : TableMemberConverter
        where T2 : TableMemberConverter
    {
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
