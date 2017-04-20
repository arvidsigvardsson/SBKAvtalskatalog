using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBKAvtalskatalog.Controllers
{
    [RoutePrefix("Arvid")]
    [Route("{action=index}")]
    public class KatalogController : Controller
    {
        // GET: Katalog
        public ActionResult Index()
        {
            return View();
        }

        [Route("Start")]
        public ActionResult Start()
        {
            return View();
        }

        public ActionResult TestPage()
        {
            return View();
        }
    }
}