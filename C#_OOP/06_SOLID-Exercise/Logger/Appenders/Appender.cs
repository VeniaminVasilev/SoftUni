using Logger.Interfaces;

namespace Logger.Appenders
{
    public abstract class Appender
    {
        public ILayout Layout { get; set; }

        public ReportLevel ReportLevel { get; set; }

        public int LoggedMessages { get; set; }

        public Appender(ILayout layout)
        {
            this.Layout = layout;
            this.ReportLevel = ReportLevel.INFO;
        }

        public virtual void AppendMessage(string output)
        {
        }
    }
}