using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Overloadings.Data.InMemory;
using Overloadings.Core.Model;

namespace Overloadings.Controllers
{
    public class ProductManagerController : Controller
    {
        ProductRepository context;

        public ProductManagerController()
        {

            context = new ProductRepository();
        }
        // GET: ProductManager

        public ActionResult Index()
        {
            List<Product> lista_productos = context.Collection().ToList();


            return View(lista_productos);
            
        }

        public ActionResult Insert()
        {
            Product producto = new Product();
            return View(producto);
        }

        [HttpPost]
        public ActionResult Insert(Product producto) {

            if (!ModelState.IsValid)
            {
                return View(producto);
            }
            else
            {
                context.Insert(producto);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string id) {
            Product producto = context.Find(id);
            if (producto == null)

                return HttpNotFound();
            else {
                
                return View(producto);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product producto, string id)
        {
           Product product2edit = context.Find(id);
            if (product2edit == null)
            {
                return HttpNotFound();
            }
            else {

                if (!ModelState.IsValid) {
                    return View(producto);
                }

                product2edit.ID = producto.ID;
                product2edit.Name = producto.Name;
                product2edit.Description = producto.Description;
                product2edit.Price = producto.Price;
                product2edit.Type = producto.Type;

                    context.Commit();
                    return RedirectToAction("Index");
                
            }
        }

        public ActionResult Delete(string id) {
            Product product2delete = context.Find(id);
            if (product2delete == null)
            {
                return HttpNotFound();

            }
            else {
                
                    return View(product2delete);
                
                
            }

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {

            Product product2delete = context.Find(id);
            if (product2delete == null)
            {
                return HttpNotFound();

            }
            else
            {
                context.Delete(id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

    }
}