using Abp.Application.Services;

namespace WikiTutorial
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class WikiTutorialAppServiceBase : ApplicationService
    {
        protected WikiTutorialAppServiceBase()
        {
            LocalizationSourceName = WikiTutorialConsts.LocalizationSourceName;
        }
    }
}