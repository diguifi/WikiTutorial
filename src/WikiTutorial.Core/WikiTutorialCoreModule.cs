using System.Reflection;
using Abp.Modules;

namespace WikiTutorial
{
    public class WikiTutorialCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
