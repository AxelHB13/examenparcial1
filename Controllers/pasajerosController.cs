using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EXAMENPARCIAL_WEB.Models;

namespace EXAMENPARCIAL_WEB.Controllers
{
    public class PasajerosController : Controller
    {
        // GET: Pasajeros
        public ActionResult Index()
        {
            using (var contexto = new masterEntities())
            {
                var pasajeros = contexto.pasajeros.ToList();
                return View(pasajeros);
            }
        }

        // GET: Pasajeros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            using (var contexto = new masterEntities())
            {
                var pasajero = contexto.pasajeros.FirstOrDefault(x => x.id == id);
                if (pasajero == null)
                {
                    return HttpNotFound();
                }
                return View(pasajero);
            }
        }

        // GET: Pasajeros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pasajeros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(pasajeros pasajero)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var contexto = new masterEntities())
                    {
                        contexto.pasajeros.Add(pasajero);
                        contexto.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al crear el pasajero: " + ex.Message);
                }
            }
            return View(pasajero);
        }

        // GET: Pasajeros/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            using (var contexto = new masterEntities())
            {
                var pasajero = contexto.pasajeros.FirstOrDefault(x => x.id == id);
                if (pasajero == null)
                {
                    return HttpNotFound();
                }
                return View(pasajero);
            }
        }

        // POST: Pasajeros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(pasajeros updatedPasajero)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var contexto = new masterEntities())
                    {
                        contexto.Entry(updatedPasajero).State = System.Data.Entity.EntityState.Modified;
                        contexto.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al editar el pasajero: " + ex.Message);
                }
            }
            return View(updatedPasajero);
        }

        // GET: Pasajeros/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            using (var contexto = new masterEntities())
            {
                var pasajero = contexto.pasajeros.FirstOrDefault(x => x.id == id);
                if (pasajero == null)
                {
                    return HttpNotFound();
                }
                return View(pasajero);
            }
        }

        // POST: Pasajeros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                using (var contexto = new masterEntities())
                {
                    var pasajero = contexto.pasajeros.FirstOrDefault(x => x.id == id);
                    if (pasajero != null)
                    {
                        contexto.pasajeros.Remove(pasajero);
                        contexto.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al eliminar el pasajero: " + ex.Message);
                return RedirectToAction("Index");
            }
        }
    }
}