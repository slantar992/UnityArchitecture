namespace Slantar.Architecture
{
    public interface ILogFormatter
    {
        string Format(LogLevel level, string message);
    }
}