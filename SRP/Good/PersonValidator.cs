using System.Text.RegularExpressions;
using SRP.Domain;
using SRP.Logic;

namespace SRP.Good
{
    public class PersonValidator
    {
        public ValidationResult Validate(Person personToValidate, string line)
        {
            var validationResult = new ValidationResult();
            if (!Regex.IsMatch(personToValidate.FirstName, @"^[a-zA-z]+$"))
            {
                validationResult.AddParseError(new ParseError("FirstName can only contain alpha characters", line));
            }
            if (!Regex.IsMatch(personToValidate.LastName, @"^[a-zA-z]+$"))
            {
                validationResult.AddParseError(new ParseError("LastName can only contain alpha characters", line));
            }

            return validationResult;
        }
    }
}