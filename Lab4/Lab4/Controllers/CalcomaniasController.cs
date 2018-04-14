using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab4.Models;
using Lab4.Clases;
using System.Diagnostics;

namespace Lab4.Controllers
{
    public class CalcomaniasController : Controller
    {
        // GET: Calcomanias
        public ActionResult Index()
        {
            ViewData["keys"] = Data.Instance.coleccion.Select(x => x.Key).ToList();
            return View(Data.Instance.coleccion.Select(x => x.Value).ToList());
        }

        // GET: Calcomanias/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Calcomanias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Calcomanias/Create
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

        // GET: Calcomanias/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Calcomanias/Edit/5
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

        // GET: Calcomanias/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Calcomanias/Delete/5
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

        public ActionResult UploadColeccion()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadColeccion(HttpPostedFileBase file)
        {
            try
            {
                Dictionary<string, Calcomanias> temp = new Dictionary<string, Calcomanias>();
                int cont = 0;
                if (!file.FileName.EndsWith(".json"))
                    return View();
                if (file.ContentLength > 0)
                {
                    var json = new JsonConverter<string, Calcomanias>();
                    List<Dictionary<string, Calcomanias>> dic = json.datosJson(file.InputStream);
                    temp = dic.ElementAt(cont);
                    foreach (KeyValuePair<string, Calcomanias> p in temp)
                    {
                        Data.Instance.coleccion.Add(p.Key, p.Value);
                        cont = cont + 1;
                        temp = dic.ElementAt(cont);
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }

    }
}