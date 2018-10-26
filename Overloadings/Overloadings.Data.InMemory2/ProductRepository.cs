using System;
using System.Collections.Generic;
using System.Text;
using Overloadings.Core.Model;
using System.Runtime.Caching;
using System.Linq;



namespace Overloadings.Data.InMemory
{
   public class ProductRepository
    {
         ObjectCache cache = MemoryCache.Default;
        List<Product> lista_productos;

        
        public ProductRepository()
        {
            lista_productos = cache["lista_productos"] as List<Product>;
            if (lista_productos == null) {
                lista_productos = new List<Product>();
            }
        }

        public void Commit() {
            cache["lista_productos"] = lista_productos;
        }

        //INICIO DE MÉTODOS CRUD PARA PRODUCTOS

        public void Insert(Product p) {
            lista_productos.Add(p);
            //Commit();
        }

        
        public void Update(Product p) {

            Product product2update = lista_productos.Find(LP=>LP.ID==p.ID);
            if (product2update != null)
            {

                
                product2update = p;
            }
            else {

                throw new Exception("Not found");

            }
        }

        public void Delete(string id) {
            Product product2find = lista_productos.Find(LP=> LP.ID==id);

            if (product2find != null) {
                lista_productos.Remove(product2find);

            }
            else
            {
                throw new Exception("Not Found");
            }
        }
       
        public Product Find(string id) {

            Product product2find = lista_productos.Find(LP => LP.ID == id);
            if (product2find != null)
            {
                return product2find;
            }
            else {
                throw new Exception("Not Products Found");
            }
        }

        public IQueryable<Product> Collection()
        {
            return lista_productos.AsQueryable();
        }


    }
}
