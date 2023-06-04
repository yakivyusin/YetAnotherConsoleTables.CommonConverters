namespace YetAnotherConsoleTables.CommonConverters.Tests
{
    public abstract class BaseTests
    {
        protected readonly StringWriter _writer = new();

        protected string ValueLine => _writer.ToString().Split(_writer.NewLine, StringSplitOptions.RemoveEmptyEntries)[3];
    }
}
