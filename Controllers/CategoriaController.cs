using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EXAMENPARCIAL_WEB.Models;

namespace EXAMENPARCIAL_WEB.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            using (var contexto = new masterEntities())
            {
                var categorias = contexto.Categories.ToList();
                return View(categorias);
            }
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            using (var contexto = new masterEntities())
            {
                var categoria = contexto.Categories.FirstOrDefault(x => x.CategoryID == id);
                if (categoria == null)
                {
                    return HttpNotFound();
                }
                return View(categoria);
            }
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categories categoria)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var contexto = new masterEntities())
                    {
                        contexto.Categories.Add(categoria);
                        contexto.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al crear la categoría: " + ex.Message);
                }
            }
            return View(categoria);
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            using (var contexto = new masterEntities())
            {
                var categoria = contexto.Categories.FirstOrDefault(x => x.CategoryID == id);
                if (categoria == null)
                {
                    return HttpNotFound();
                }
                return View(categoria);
            }
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categories updatedCategoria)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var contexto = new masterEntities())
                    {
                        contexto.Entry(updatedCategoria).State = System.Data.Entity.EntityState.Modified;
                        contexto.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al editar la categoría: " + ex.Message);
                }
            }
            return View(updatedCategoria);
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            using (var contexto = new masterEntities())
            {
                var categoria = contexto.Categories.FirstOrDefault(x => x.CategoryID == id);
                if (categoria == null)
                {
                    return HttpNotFound();
                }
                return View(categoria);
            }
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                using (var contexto = new masterEntities())
                {
                    var categoria = contexto.Categories.FirstOrDefault(x => x.CategoryID == id);
                    if (categoria != null)
                    {
                        contexto.Categories.Remove(categoria);
                        contexto.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al eliminar la categoría: " + ex.Message);
                return RedirectToAction("Index");
            }
        }

        // DELETE: All Categories
        public ActionResult DeleteAll()
        {
            try
            {
                using (var contexto = new masterEntities())
                {
                    var categorias = contexto.Categories.ToList(); // Obtiene todas las categorías.
                    foreach (var categoria in categorias)
                    {
                        contexto.Categories.Remove(categoria); // Elimina cada categoría individualmente.
                    }
                    contexto.SaveChanges(); // Guarda los cambios en la base de datos.
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al eliminar todas las categorías: " + ex.Message);
                return RedirectToAction("Index");
            }
        }
    }
}

