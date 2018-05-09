using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using WikiTutorial.EntityFramework;

namespace WikiTutorial
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(WikiTutorialCoreModule))]
    public class WikiTutorialDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<WikiTutorialDbContext>(null);
        }
    }
}
