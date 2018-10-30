using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.DataAccess.inMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {

        IRepository<ProductCategory>  context;

        public ProductCategoryManagerController(IRepository<ProductCategory> context)
        {
            this.context =context;
        }
        // GET: ProductManager
        public ActionResult Index()
        {

            List<ProductCategory> products = context.Collection().ToList();


            return View(products);
        }

        public ActionResult Create()
        {
            ProductCategory product = new ProductCategory();
            return View(product);
        }

        [HttpPost]
        public ActionResult Create(ProductCategory product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);
                context.Commit();
                return RedirectToAction("Index");
            }
        }


        public ActionResult Edit(string id)
        {
            ProductCategory product = context.Find(id);
            if (product == null)
            {
                return HttpNotFound();

            }
            else
            {
                return View(product);
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory product, string id)
        {
            ProductCategory productToEdit = context.Find(id);
            if (productToEdit == null)
            {
                return HttpNotFound();

            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);

                }
                productToEdit.Categoria = product.Categoria;
                

                context.Commit();
                return RedirectToAction("Index");
            }

        }

        public ActionResult Delete(string id)
        {
            ProductCategory productToDelete = context.Find(id);
            if (productToDelete == null)
            {
                return HttpNotFound();

            }
            else
            {
                return View(productToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {

            ProductCategory productToDelete = context.Find(id);

            if (productToDelete == null)
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