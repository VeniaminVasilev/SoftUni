using Logger.Appenders;

namespace Logger.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        int LoggedMessages { get; }

        void AppendMessage(string output);
    }
}