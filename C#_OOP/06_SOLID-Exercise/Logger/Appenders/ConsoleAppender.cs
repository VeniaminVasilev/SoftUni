using Logger.Interfaces;

namespace Logger.Appenders
{
    public class ConsoleAppender : Appender, IAppender
    {
        public ConsoleAppender(ILayout layout) : base(layout) { }

        public override void AppendMessage(string output)
        {
            Console.WriteLine(output);
            this.LoggedMessages++;
        }
    }
}