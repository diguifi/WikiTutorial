using Abp.Web.Mvc.Views;

namespace WikiTutorial.Web.Views
{
    public abstract class WikiTutorialWebViewPageBase : WikiTutorialWebViewPageBase<dynamic>
    {

    }

    public abstract class WikiTutorialWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected WikiTutorialWebViewPageBase()
        {
            LocalizationSourceName = WikiTutorialConsts.LocalizationSourceName;
        }
    }
}