using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class OsobaController : Controller
    {
        // GET: Osoba
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dodaj(int age1, int age2)
        {
            int age = age1 + age2;
            ViewBag.Message = "Wiek: " + age.ToString();
            return View();
        }

        // GET: Osoba/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Osoba/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Osoba/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Osoba/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Osoba/Edit/5
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

        // GET: Osoba/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Osoba/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
