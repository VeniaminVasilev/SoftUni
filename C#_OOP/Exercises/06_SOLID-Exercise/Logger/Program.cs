using Logger.Appenders;
using Logger.Interfaces;
using Logger.Layouts;
using Logger.Loggers;

namespace Logger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Appender[] appenders = new Appender[n];

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string appenderType = data[0];
                string layoutType = data[1];

                ILayout layout = null;
                Appender appender = null;
                LogFile file = null;

                if (layoutType == "SimpleLayout")
                {
                    layout = new SimpleLayout();
                }
                else if (layoutType == "XmlLayout")
                {
                    layout = new XmlLayout();
                }

                if (appenderType == "ConsoleAppender")
                {
                    appender = new ConsoleAppender(layout);
                }
                else if (appenderType == "FileAppender")
                {
                    file = new LogFile();
                    appender = new FileAppender(layout, file);
                }

                if (data.Length > 2)
                {
                    string level = data[2];

                    if (level == "INFO")
                    {
                        appender.ReportLevel = ReportLevel.INFO;
                    }
                    else if (level == "WARNING")
                    {
                        appender.ReportLevel = ReportLevel.WARNING;
                    }
                    else if (level == "ERROR")
                    {
                        appender.ReportLevel = ReportLevel.ERROR;
                    }
                    else if (level == "CRITICAL")
                    {
                        appender.ReportLevel = ReportLevel.CRITICAL;
                    }
                    else if (level == "FATAL")
                    {
                        appender.ReportLevel = ReportLevel.FATAL;
                    }
                }

                appenders[i] = appender;
            }

            ILogger logger = new Loggerer(appenders);

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END") { break; }

                string[] data = command.Split("|");
                string reportLevel = data[0];
                string time = data[1];
                string message = data[2];

                if (reportLevel == "INFO")
                {
                    logger.Info(time, message);
                }
                else if (reportLevel == "WARNING")
                {
                    logger.Warning(time, message);
                }
                else if (reportLevel == "ERROR")
                {
                    logger.Error(time, message);
                }
                else if (reportLevel == "CRITICAL")
                {
                    logger.Critical(time, message);
                }
                else if (reportLevel == "FATAL")
                {
                    logger.Fatal(time, message);
                }
            }

            Console.WriteLine("Logger info");
            foreach (var appender in appenders)
            {
                if (appender.GetType().Name == "ConsoleAppender")
                {
                    Console.WriteLine($"Appender type: {appender.GetType().Name}, Layout type: {appender.Layout.GetType().Name}, " +
                        $"Report Level: {appender.ReportLevel}, Messages appended: {appender.LoggedMessages}");
                }
                else if (appender.GetType().Name == "FileAppender")
                {
                    FileAppender fileAppender = (FileAppender)appender;

                    Console.WriteLine($"Appender type: {appender.GetType().Name}, Layout type: {appender.Layout.GetType().Name}, " +
                        $"Report Level: {appender.ReportLevel}, Messages appended: {appender.LoggedMessages}, File size {fileAppender.LogFile.Size}");
                }
            }
        }
    }
}