using Autofac;
using WcfServiceWithAutofacAndLog4Net.Infrastructure;

namespace WcfServiceWithAutofacAndLog4Net.BusinessLogic
{
    public class AutofacRepoConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Repo>()
                   .As<IRepo>()
                   .InstancePerLifetimeScope();
        }
    }
}
