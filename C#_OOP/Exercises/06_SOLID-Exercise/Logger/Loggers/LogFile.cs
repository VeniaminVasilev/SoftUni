using System.Text;

namespace Logger.Loggers
{
    public class LogFile
    {
        private StringBuilder _logBuilder;
        private string _filePath;

        public int Size
        {
            get
            {
                int sizeOfText = 0;
                for (int i = 0; i < this._logBuilder.Length; i++)
                {
                    if (char.IsLetter(_logBuilder[i]))
                    {
                        sizeOfText += (int)_logBuilder[i];
                    }
                }
                return sizeOfText;
            }
        }

        public LogFile()
        {
            this._logBuilder = new StringBuilder();
            this._filePath = "../../../log.txt";
        }

        public void Write(string text)
        {
            this._logBuilder.AppendLine(text);

            File.AppendAllText(this._filePath, text + Environment.NewLine);
        }
    }
}