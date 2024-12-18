using Logger.Appenders;
using Logger.Interfaces;

namespace Logger.Loggers
{
    public class Loggerer : ILogger
    {
        public List<Appender> Appenders { get; set; }

        public Loggerer(params Appender[] appenders)
        {
            this.Appenders = new List<Appender>(appenders);
        }

        public void Info(string dateTime, string message)
        {
            string reportLevel = "INFO";

            foreach (Appender appender in Appenders)
            {
                if (appender.ReportLevel == Logger.Appenders.ReportLevel.INFO)
                {
                    string outputMessage = appender.Layout.Format(dateTime, reportLevel, message);
                    appender.AppendMessage(outputMessage);
                }
            }
        }

        public void Warning(string dateTime, string message)
        {
            string reportLevel = "WARNING";

            foreach (Appender appender in Appenders)
            {
                if (appender.ReportLevel <= Logger.Appenders.ReportLevel.WARNING)
                {
                    string outputMessage = appender.Layout.Format(dateTime, reportLevel, message);
                    appender.AppendMessage(outputMessage);
                }
            }
        }

        public void Error(string dateTime, string message)
        {
            string reportLevel = "ERROR";

            foreach (Appender appender in Appenders)
            {
                if (appender.ReportLevel <= Logger.Appenders.ReportLevel.ERROR)
                {
                    string outputMessage = appender.Layout.Format(dateTime, reportLevel, message);
                    appender.AppendMessage(outputMessage);
                }
            }
        }

        public void Critical(string dateTime, string message)
        {
            string reportLevel = "CRITICAL";

            foreach (Appender appender in Appenders)
            {
                if (appender.ReportLevel <= Logger.Appenders.ReportLevel.CRITICAL)
                {
                    string outputMessage = appender.Layout.Format(dateTime, reportLevel, message);
                    appender.AppendMessage(outputMessage);
                }
            }
        }

        public void Fatal(string dateTime, string message)
        {
            string reportLevel = "FATAL";

            foreach (Appender appender in Appenders)
            {
                if (appender.ReportLevel <= Logger.Appenders.ReportLevel.FATAL)
                {
                    string outputMessage = appender.Layout.Format(dateTime, reportLevel, message);
                    appender.AppendMessage(outputMessage);
                }
            }
        }
    }
}