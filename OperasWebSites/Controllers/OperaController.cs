﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using OperasWebSites.Models;

namespace OperasWebSites.Controllers
{
    public class OperaController : Controller
    {
        private OperasDB contextDB = new OperasDB();

        //
        // GET: /Opera/

        public ActionResult Index()
        {
            return View("Index", contextDB.Operas.ToList());
        }

        public ActionResult Details(int id)
        {
            Opera opera = contextDB.Operas.Find(id);
            if (opera != null)
            {
                return View("Details", opera);
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult Create()
        {
            Opera newOpera = new Opera();
            ViewBag.Title = "Add an Opera";
            return View("Create", newOpera);
        }

        [HttpPost]
        public ActionResult Create(Opera newOpera)
        {
            if (ModelState.IsValid)
            {
                contextDB.Operas.Add(newOpera);
                contextDB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Title = "Try again";

                return View("Create", newOpera);
            }
        }
    }
}
