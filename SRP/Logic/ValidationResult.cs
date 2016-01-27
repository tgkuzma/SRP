using System.Collections.Generic;
using System.Linq;

namespace SRP.Logic
{
    public class ValidationResult
    {
        private readonly List<ParseError> _parsedErrors = new List<ParseError>();

        public bool IsValid { get { return _parsedErrors.Count == 0; } }

        public void AddParseError(ParseError parsedError)
        {
            _parsedErrors.Add(parsedError);
        }

        public List<string> GetErrorMessages()
        {
            return _parsedErrors.Select(parsedError => parsedError.ErrorMessage).ToList();
        }
    }
}