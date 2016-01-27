using SRP.Domain;
using SRP.Logic;

namespace SRP.Good
{
    public class FileParser
    {
        private readonly RecordPerLineFileReader _fileReader;
        private readonly DelimitedLineParser _lineParser;
        private readonly PersonMapper _objectMapper;
        private readonly PersonValidator _validator;

        public FileParser(RecordPerLineFileReader fileReader, 
                          DelimitedLineParser lineParser, 
                          PersonMapper objectMapper, 
                          PersonValidator validator)
        {
            _fileReader = fileReader;
            _lineParser = lineParser;
            _objectMapper = objectMapper;
            _validator = validator;
        }

        public ParseResult<Person> Parse(string filePathToParse)
        {
            var parseResult = new ParseResult<Person>();

            _fileReader.OpenFile(filePathToParse);
            var line = "";

            while ((line = _fileReader.ReadRecord()) != null)
            {
                var fieldArray = _lineParser.Parse(line);
                var personFromFile = _objectMapper.Map(fieldArray);

                var validationResult = _validator.Validate(personFromFile, line);

                AddValidObjectOrParseErrorToResults(validationResult, parseResult, personFromFile, line);
            }

            return parseResult;
        }

        private static void AddValidObjectOrParseErrorToResults(ValidationResult validationResult, ParseResult<Person> parseResult,
            Person personToAdd, string line)
        {
            if (validationResult.IsValid)
            {
                parseResult.AddParsedRecordToCollection(personToAdd);
            }
            else
            {
                foreach (var errorMessage in validationResult.GetErrorMessages())
                {
                    parseResult.AddParsedErrorToCollection(errorMessage, line);
                }
            }
        }
    }
}