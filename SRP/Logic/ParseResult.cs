using System.Collections.Generic;
using System.Linq;

namespace SRP.Logic
{
    public class ParseResult <T> where T: class
    {
        private readonly List<T> _parsedRecords = new List<T>();
        private readonly List<ParseError> _parsedErrors = new List<ParseError>();

        public IEnumerable<T> ParsedRecords { get { return _parsedRecords.AsEnumerable(); } }
        public IEnumerable<ParseError> ParsedErrors { get { return _parsedErrors.AsEnumerable(); } }

        public void AddParsedRecordToCollection(T parsedRecordToAdd)
        {
            _parsedRecords.Add(parsedRecordToAdd);
        }

        public void AddParsedErrorToCollection(string errorMessageToAdd, string erroredRecordText)
        {
            _parsedErrors.Add(new ParseError(errorMessageToAdd, erroredRecordText));
        }
    }
}