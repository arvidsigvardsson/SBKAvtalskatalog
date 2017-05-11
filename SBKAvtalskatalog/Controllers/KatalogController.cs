using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using Npgsql;

namespace SBKAvtalskatalog.Controllers
{
    [RoutePrefix("")]
    [Route("{action=index}")]
    public class KatalogController : Controller
    {
        // GET: Katalog
        [Route("")]
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

        [Route("editpage")]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult EditPage()
        {
            var model = new Models.Avtalsmodel
            {
                diarienummer = 555,
                startdate = DateTime.Now,
                enddate = DateTime.Now,
                orgnummer = "7707077777"
            };
            return View(model);
        }

        [Route("editpage")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditPage(Models.Avtalsmodel model)
        {
            System.Diagnostics.Debug.WriteLine("Diarienummer:" + model.diarienummer);
            return Redirect("/Tabell");
        }

        [Route("Tabell")]
        public ActionResult Tabell()
        {
            var cs = connstr();
            var lst = new List<SBKAvtalskatalog.Models.Avtalsmodel>();

            using (var conn = new NpgsqlConnection("Host=localhost;Username=postgres;Database=avtalskatalogSBK"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select diarienummer, startdate, enddate, orgnummer from avtal";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new Models.Avtalsmodel
                            {
                                diarienummer = reader.GetInt64(0),
                                startdate = reader.GetDateTime(1),
                                enddate = reader.GetDateTime(2),
                                orgnummer = reader.GetString(3)
                            });
                        }
                    }
                }
            }
            return View(lst);
        }

        private string connstr()
        {
            return "Host=localhost;Username=postgres;Database=mydb";
        }
    }
}