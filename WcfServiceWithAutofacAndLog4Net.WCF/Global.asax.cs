using Autofac.Integration.Wcf;

using log4net.Config;
using System;
using WcfServiceWithAutofacAndLog4Net.WCF.Configs;

namespace WcfServiceWithAutofacAndLog4Net.WCF
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var container = AutofacConfig.Config();
            AutofacHostFactory.Container = container;
        }
    }
}