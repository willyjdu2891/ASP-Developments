﻿using MyShop.Core.Contracts;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.inMemory
{
   public class InMemoryRepository<T> : IRepository<T> where T:Base
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        string className;

        public InMemoryRepository() {
            className = typeof(T).Name;
            items = cache[className] as List<T>;
            if (items == null) {
                items = new List<T>();
            }

        }

       
        public void Commit()
        {
            cache[className] = items;
        }

        public void Insert(T t) {
            items.Add(t);
        }

        public void Update(T t)
        {
            T tToUpdate = items.Find(i => i.ID == t.ID);
            if (tToUpdate != null)
            {
                tToUpdate = t;
            }
            else
            {
                throw new Exception(className + "Not Found");
            }
        }

            public T Find(string id) {
                T t = items.Find(i => i.ID == id);
                if (t != null) {
                    return t;
                }
                 else{
                throw new Exception(className + "Not found");
                }
            }

        public IQueryable<T> Collection() {
            return items.AsQueryable();
        }

        public void Delete(string id) {
            T tToDelete = items.Find(i => i.ID == id);
            if (tToDelete != null) {
                items.Remove(tToDelete);
            }
            else
            {
                throw new Exception(className + "Not found");
            }
        }
        }
}
