using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EXAMENPARCIAL_WEB.Models;

namespace EXAMENPARCIAL_WEB.Controllers
{
    public class Order_detailsController : Controller
    {
        // GET: Order_details
        public ActionResult Index()
        {
            using (var contexto = new masterEntities())
            {
                var orderDetails = contexto.Order_Details.ToList();
                return View(orderDetails);
            }
        }

        // GET: Order_details/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            using (var contexto = new masterEntities())
            {
                var orderDetail = contexto.Order_Details.FirstOrDefault(x => x.OrderID == id);
                if (orderDetail == null)
                {
                    return HttpNotFound();
                }
                return View(orderDetail);
            }
        }

        // GET: Order_details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order_details/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order_Details orderDetail)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var contexto = new masterEntities())
                    {
                        contexto.Order_Details.Add(orderDetail);
                        contexto.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error" + ex.Message);
                }
            }
            return View(orderDetail);
        }

        // GET: Order_details/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            using (var contexto = new masterEntities())
            {
                var orderDetail = contexto.Order_Details.FirstOrDefault(x => x.OrderID == id);
                if (orderDetail == null)
                {
                    return HttpNotFound();
                }
                return View(orderDetail);
            }
        }

        // POST: Order_details/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order_Details updatedOrderDetail)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var contexto = new masterEntities())
                    {
                        contexto.Entry(updatedOrderDetail).State = EntityState.Modified;
                        contexto.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al editar el detalle de la orden: " + ex.Message);
                }
            }
            return View(updatedOrderDetail);
        }

        // GET: Order_details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            using (var contexto = new masterEntities())
            {
                var orderDetail = contexto.Order_Details.FirstOrDefault(x => x.OrderID == id);
                if (orderDetail == null)
                {
                    return HttpNotFound();
                }
                return View(orderDetail);
            }
        }

        // POST: Order_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                using (var contexto = new masterEntities())
                {
                    var orderDetail = contexto.Order_Details.FirstOrDefault(x => x.OrderID == id);
                    if (orderDetail != null)
                    {
                        contexto.Order_Details.Remove(orderDetail);
                        contexto.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al eliminar el detalle de la orden: " + ex.Message);
                return View();
            }
        }
    }
}
