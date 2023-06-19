using Autofac;
using System;
using WcfServiceWithAutofacAndLog4Net.BusinessLogic;

namespace WcfServiceWithAutofacAndLog4Net.WCF.Configs
{
    public static class AutofacConfig
    {
        public static IContainer Config()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new Log4NetModule());
            builder.RegisterType<Service1>().As<IService1>().InstancePerDependency();
            builder.RegisterType<Bl>().As<IBl>().InstancePerDependency();
            builder.RegisterModule(new AutofacRepoConfig());

            return builder.Build();
        }
    }
}