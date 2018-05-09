using System.Web.Mvc;

namespace WikiTutorial.Web.Controllers
{
    public class HomeController : WikiTutorialControllerBase
    {
        public ActionResult Index()
        { 
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}