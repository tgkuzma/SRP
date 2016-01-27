using System;
using System.IO;
using System.Text.RegularExpressions;
using SRP.Domain;
using SRP.Logic;

namespace SRP.Bad
{
    public class AllInOneFileParser
    {
        public ParseResult<Person> ParseFile(string filePath, char delimiter)
        {
            //Opens the file
            var parseResult = new ParseResult<Person>();
            var reader = File.OpenText(filePath);

            var line = "";

            //Reads each line
            while ((line = reader.ReadLine()) != null)
            {
                //Creates an array based on our delimiter
                var fieldArray = line.Split(delimiter);

                //Maps the array to a concrete object
                var personFromFile = new Person
                {
                    LastName = fieldArray[0],
                    FirstName = fieldArray[1],
                    Birthday = DateTime.Parse(fieldArray[2])
                };

                //Perform some validation (method below)
                var validationResult = ValidatePerson(personFromFile, line);

                AddValidObjectOrParseErrorToResults(validationResult, parseResult, personFromFile, line);
            }

            return parseResult;
        }

        //The validation logic from above
        private static ValidationResult ValidatePerson(Person personFromFile, string line)
        {
            var validationResult = new ValidationResult();
            if (!Regex.IsMatch(personFromFile.FirstName, @"^[a-zA-z]+$"))
            {
                validationResult.AddParseError(new ParseError("FirstName can only contain alpha characters", line));
            }
            if (!Regex.IsMatch(personFromFile.LastName, @"^[a-zA-z]+$"))
            {
                validationResult.AddParseError(new ParseError("LastName can only contain alpha characters", line));
            }

            return validationResult;
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