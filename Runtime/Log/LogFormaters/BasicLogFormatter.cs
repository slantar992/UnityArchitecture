namespace Slantar.Architecture
{
    public class BasicLogFormatter : ILogFormatter
    {
        public string Format(LogLevel level, string message) 
            => $"{level.ToString().ToUpper()}: {message}";
    }
}