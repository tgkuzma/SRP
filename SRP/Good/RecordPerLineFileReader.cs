using System;
using System.IO;

namespace SRP.Good
{
    public class RecordPerLineFileReader
    {
        private StreamReader _openFile;

        public void OpenFile(string filePathToOpen)
        {
            _openFile = File.OpenText(filePathToOpen);
        }

        public void CloseFile()
        {
            if (_openFile == null)
            {
                throw new ApplicationException("No file exists to close");
            }

            _openFile.Close();
            _openFile = null;
        }

        public string ReadRecord()
        {
            if (_openFile == null)
            {
                throw new ApplicationException("No file exists to read from");
            }

            return _openFile.ReadLine();
        }
    }
}