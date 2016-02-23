using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lazybank.Web.Controllers
{
    public class ErrorController : BaseController
    {
        // GET: Error
        public ActionResult NotFound()
        {
            return this.View();
        }

        public ActionResult InternalServer()
        {
            return this.View();
        }
    }
}