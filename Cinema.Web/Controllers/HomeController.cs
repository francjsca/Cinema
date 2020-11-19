using Cinema.Providers;
using Cinema.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Web.Controllers {
    public class HomeController : Controller {
        private readonly SpettatoreSqlProvider _spettatoreSqlProvider;
        private readonly BigliettoSqlProvider _bigliettoSqlProvider;
        private readonly GenereSqlProvider _genereSqlProvider;
        private readonly SalaSqlProvider _salaSqlProvider;
        private readonly FilmSqlProvider _filmSqlProvider;
        private readonly ProiezioneSqlProvider _proiezioneSqlProvider;

        public HomeController()
        {
            _spettatoreSqlProvider = new SpettatoreSqlProvider(ConfigurationManager.ConnectionStrings["connectionCinema"].ConnectionString);
            _bigliettoSqlProvider = new BigliettoSqlProvider(ConfigurationManager.ConnectionStrings["connectionCinema"].ConnectionString);
            _genereSqlProvider = new GenereSqlProvider(ConfigurationManager.ConnectionStrings["connectionCinema"].ConnectionString);
            _salaSqlProvider = new SalaSqlProvider(ConfigurationManager.ConnectionStrings["connectionCinema"].ConnectionString);
            _filmSqlProvider = new FilmSqlProvider(ConfigurationManager.ConnectionStrings["connectionCinema"].ConnectionString);
            _proiezioneSqlProvider = new ProiezioneSqlProvider(ConfigurationManager.ConnectionStrings["connectionCinema"].ConnectionString);
        }
        public ActionResult Index()
        {
            var filmOggi = _proiezioneSqlProvider.FilmOggi().Select(m => new ProiezioneView(m)).ToList();
            var film = _filmSqlProvider.GetAll().Select(m => new FilmView(m)).ToList();
            return View(new DashboardView(filmOggi,film));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}