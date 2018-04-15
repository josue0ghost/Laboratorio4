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
            return View(Data.Instance.coleccion.Select(x => x.Value).ToList());
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult IndexVal()
        {
            return View(Data.Instance.ValoresColeccion.Select(x => x.Value).ToList());
        }

        // GET: Calcomanias/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Calcomanias/Create1
        public ActionResult Create1()
        {
            return View();
        }

        // POST: Calcomanias/Create1
        [HttpPost]
        public ActionResult Create1(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                string cal = collection["SFaltantes"];
                string name = collection["name"];
                if (Data.Instance.coleccion.Keys.ToList().Contains(name))
                {
                    if (Data.Instance.coleccion[name].SColeccionadas.Split(',').Contains(cal))
                    {
                        Data.Instance.coleccion[name].Cambios.Add(Convert.ToInt32(cal));
                        Data.Instance.coleccion[name].SCambios = null;
                        foreach (var item in Data.Instance.coleccion[name].Cambios)
                        {
                            Data.Instance.coleccion[name].SCambios = Data.Instance.coleccion[name].SCambios + item + ",";
                        }
                        return View("Index", Data.Instance.coleccion.Select(x => x.Value).ToList());
                    }
                    if (Data.Instance.coleccion[name].SFaltantes.Split(',').Contains(cal))
                    {
                        Data.Instance.coleccion[name].Faltantes.Remove(Convert.ToInt32(cal));
                        Data.Instance.coleccion[name].Coleccionadas.Add(Convert.ToInt32(cal));
                        Data.Instance.coleccion[name].SFaltantes = null;
                        Data.Instance.coleccion[name].SColeccionadas = null;
                        foreach (var item in Data.Instance.coleccion[name].Faltantes)
                        {
                            Data.Instance.coleccion[name].SFaltantes = Data.Instance.coleccion[name].SFaltantes + item + ",";
                        }
                        foreach (var item in Data.Instance.coleccion[name].Coleccionadas)
                        {
                            Data.Instance.coleccion[name].SColeccionadas = Data.Instance.coleccion[name].SColeccionadas + item + ",";
                        }
                        return View("Index", Data.Instance.coleccion.Select(x => x.Value).ToList());
                    }
                    if (Data.Instance.coleccion[name].SCambios.Split(',').Contains(cal))
                    {
                        ViewBag.Message = string.Format("Usted ya tiene esta Calcomania Repetida");
                        return View("Index", Data.Instance.coleccion.Select(x => x.Value).ToList());
                    }
                }
                else
                {
                    Calcomanias calc = new Calcomanias();
                    calc.Coleccionadas.Add(Convert.ToInt32(cal));
                    Data.Instance.coleccion.Add(name, calc);
                    foreach (var item in Data.Instance.coleccion[name].Coleccionadas)
                    {
                        Data.Instance.coleccion[name].SColeccionadas = Data.Instance.coleccion[name].SColeccionadas + item + ",";
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Calcomanias/Create2
        public ActionResult Create2()
        {
            return View();
        }

        // POST: Calcomanias/Create2
        [HttpPost]
        public ActionResult Create2(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("IndexVal");
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
                int cont = 0;
                if (!file.FileName.EndsWith(".json"))
                    return View();
                if (file.ContentLength > 0)
                {
                    var json = new JsonConverter<string, Calcomanias>();
                    Dictionary<string, Calcomanias> dic = json.datosJson(file.InputStream);
                    foreach (KeyValuePair<string, Calcomanias> p in dic)
                    {
                        p.Value.name = p.Key;
                        p.Value.id = cont++;
                        foreach (var item in p.Value.Faltantes)
                        {
                            p.Value.SFaltantes = p.Value.SFaltantes + item + ",";
                        }
                        foreach (var item in p.Value.Coleccionadas)
                        {
                            p.Value.SColeccionadas = p.Value.SColeccionadas + item + ",";
                        }
                        foreach (var item in p.Value.Cambios)
                        {
                            p.Value.SCambios = p.Value.SCambios + item + ",";
                        }
                        Data.Instance.coleccion.Add(p.Key, p.Value);
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

        public ActionResult UploadColeccionVal()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadColeccionVal(HttpPostedFileBase file)
        {
            try
            {
                int cont = 0;
                if (!file.FileName.EndsWith(".json"))
                    return View();
                if (file.ContentLength > 0)
                {
                    var json = new JsonConverter<string, bool>();
                    var dic = json.datosJson(file.InputStream);
                    foreach (var p in dic)
                    {
                        ValCalcomanias cal = new ValCalcomanias();
                        cal.id = cont++;
                        cal.name = p.Key;
                        cal.valor = p.Value;
                        cal.SValor = p.Value.ToString();
                        Data.Instance.ValoresColeccion.Add(p.Key, cal);
                    }
                    return RedirectToAction("IndexVal");
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