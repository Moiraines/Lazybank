namespace Lazybank.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    public class CustomersAdministrationController : Controller
    {
        // GET: Administration/CustomersAdministration
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
