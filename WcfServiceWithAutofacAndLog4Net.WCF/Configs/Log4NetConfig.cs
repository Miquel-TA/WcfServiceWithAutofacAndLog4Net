using Autofac;
using log4net;
using log4net.Appender;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System.Reflection;

namespace WcfServiceWithAutofacAndLog4Net.WCF.Configs
{
    public class Log4NetModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType))
                .As<ILog>()
                .SingleInstance();

            Setup();
        }

        public static void Setup()
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

            PatternLayout patternLayout = new PatternLayout();
            // The location (%l) is pretty expensive at the cost of indicating the method, line and more.
            patternLayout.ConversionPattern = "Date: %date Severity: %-5level Thread: %thread\n > User: %u %w\n > Location: %l\n > Message: %message%newline\n\n";
            patternLayout.ActivateOptions();


            RollingFileAppender roller = new RollingFileAppender();
            roller.AppendToFile = true;
            roller.File = @"logs\\log_";
            roller.Layout = patternLayout;
            roller.MaxSizeRollBackups = 30;  // keep logs for the last 30 days
            roller.StaticLogFileName = false;  // dynamic Logger file based on date
            roller.DatePattern = "yyyy-MM-dd'.txt'";  // each day has its own Logger file
            roller.RollingStyle = RollingFileAppender.RollingMode.Date;  // roll by date
            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);

            ConsoleAppender consoleAppender = new ConsoleAppender();
            consoleAppender.Layout = patternLayout;
            consoleAppender.ActivateOptions();
            hierarchy.Root.AddAppender(consoleAppender);

            # if DEBUG
                hierarchy.Root.Level = log4net.Core.Level.All;
            # else
                hierarchy.Root.Level = log4net.Core.Level.Warn;
            # endif

            hierarchy.Configured = true;
        }
    }
}