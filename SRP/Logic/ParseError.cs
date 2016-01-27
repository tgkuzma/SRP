namespace SRP.Logic
{
    public class ParseError
    {
        public string ErrorMessage { get; set; }
        public string ErroredRecord { get; set; }

        public ParseError(string errorMessageToAdd, string erroredRecordText)
        {
            ErrorMessage = errorMessageToAdd;
            ErroredRecord = erroredRecordText;
        }
    }
}