using Cinema.Providers;
using Cinema.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Web.Controllers
{
    public class BigliettoController : Controller
    {

        private readonly BigliettoSqlProvider _bigliettoSqlProvider;

        public BigliettoController()
        {
            _bigliettoSqlProvider = new BigliettoSqlProvider(ConfigurationManager.ConnectionStrings["connectionCinema"].ConnectionString);
        }
        // GET: Biglietto
        public ActionResult Index()
        {

            return View();
        }

        // GET: Biglietto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

      
        public ActionResult Compra()
        {
            return View();
        }

    
        [HttpPost]
        public ActionResult Compra(BigliettoView biglietto)
        {
            try {
                _bigliettoSqlProvider.Insert(biglietto.ToBiglietto());

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: Biglietto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Biglietto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

           }
}
