namespace SRP.Good
{
    public class DelimitedLineParser
    {
        private readonly char[] _delimiter;

        public DelimitedLineParser(char delimiter)
        {
            _delimiter = new[] {delimiter};
        }

        public string[] Parse(string line)
        {
            return line.Split(_delimiter);
        }
    }
}