using Autofac;
using VuelingExam.Infrastructure;

namespace VuelingExam.BusinessLogic
{
    public class AutofacConfigRepoInclusion : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Repo>()
                   .As<IRepo>()
                   .InstancePerDependency();

            builder.RegisterType<FileWrapper>()
                   .As<IFileWrapper>()
                   .InstancePerDependency();
        }
    }
}
