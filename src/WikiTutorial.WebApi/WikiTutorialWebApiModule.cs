using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;

namespace WikiTutorial
{
    [DependsOn(typeof(AbpWebApiModule), typeof(WikiTutorialApplicationModule))]
    public class WikiTutorialWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(WikiTutorialApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
