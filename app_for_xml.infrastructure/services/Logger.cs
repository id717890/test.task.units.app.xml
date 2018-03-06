namespace app_for_xml.infrastructure.services
{
    using System;
    using log4net;
    using log4net.Config;

    public class Logger:ILogger
    {
        private static ILog log = LogManager.GetLogger("LOGGER");

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }

        public void Info(string message)
        {
            log.Info(message);
        }

        public void Error(string message, Exception e)
        {
            throw new NotImplementedException();
        }

        public void Error(string message)
        {
            log.Error(message);
        }

        public void Error(Exception e)
        {
            throw new NotImplementedException();
        }

        public void Fatal(string message, Exception e)
        {
            log.Fatal(message);
        }

        public void Fatal(string message)
        {
            throw new NotImplementedException();
        }

        public void Debug(string message)
        {
            throw new NotImplementedException();
        }

        public void Warn(string message)
        {
            throw new NotImplementedException();
        }
    }
}
