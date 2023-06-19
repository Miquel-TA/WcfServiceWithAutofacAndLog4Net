
using log4net;
using System;
using WcfServiceWithAutofacAndLog4Net.BusinessLogic;

namespace WcfServiceWithAutofacAndLog4Net.WCF
{
    public class Service1 : IService1
    {
        private readonly ILog log;
        private readonly IBl bl;

        public Service1(ILog log, IBl bl)
        {
            this.log = log;
            this.bl = bl;
        }
        public Service1()
        {

        }

        public string WriteData(string message)
        {
            log.Fatal("The cpu has died");
            return bl.WriteData(message);
        }
        public string ReadData()
        {
            log.Info("The cpu has revived");
            return bl.ReadData();
        }
    }
}
