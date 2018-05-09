using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using WikiTutorial.Entities.ProductEntity;
using WikiTutorial.ProductServices.Dtos;

namespace WikiTutorial
{
    [DependsOn(typeof(WikiTutorialCoreModule), typeof(AbpAutoMapperModule))]
    public class WikiTutorialApplicationModule : AbpModule
    {
        //public override void PreInitialize()
        //{
        //    Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
        //    {
        //        config.CreateMap<CreateProductInput, Product>()
        //        .ConstructUsing(x => new Product(x.Name, x.Description, x.Value));
        //    });
        //}

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
