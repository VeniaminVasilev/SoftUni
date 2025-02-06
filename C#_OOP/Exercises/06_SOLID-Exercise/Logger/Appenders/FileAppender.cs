using Logger.Interfaces;
using Logger.Loggers;

namespace Logger.Appenders
{
    public class FileAppender : Appender, IAppender
    {
        public LogFile LogFile { get; set; }

        public FileAppender(ILayout layout, LogFile logfile) : base(layout)
        {
            this.LogFile = logfile;
        }

        public override void AppendMessage(string output)
        {
            this.LogFile.Write(output);
            LoggedMessages++;
        }
    }
}