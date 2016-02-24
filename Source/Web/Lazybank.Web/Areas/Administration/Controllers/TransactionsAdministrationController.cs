namespace Lazybank.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    public class TransactionsAdministrationController : Controller
    {
        // GET: Administration/TransactionsAdministration
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
