using Autofac;
using System;
using VuelingExam.BusinessLogic;

namespace VuelingExam.WCF.Configs
{
    public static class AutofacConfig
    {
        public static IContainer Config()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new Log4NetModule());
            builder.RegisterType<VuelingWcfService>().As<IVuelingWcfService>().InstancePerDependency();
            builder.RegisterType<Bl>().As<IBl>().InstancePerDependency();
            builder.RegisterModule(new AutofacConfigRepoInclusion());

            return builder.Build();
        }
    }
}