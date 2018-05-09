using Abp.Web.Mvc.Controllers;

namespace WikiTutorial.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class WikiTutorialControllerBase : AbpController
    {
        protected WikiTutorialControllerBase()
        {
            LocalizationSourceName = WikiTutorialConsts.LocalizationSourceName;
        }
    }
}