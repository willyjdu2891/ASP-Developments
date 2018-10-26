using System.Linq;
using MyShop.Core.Models;

namespace MyShop.DataAccess.inMemory
{
    public interface IRepository<T> where T : Base
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string id);
        T Find(string id);
        void Insert(T t);
        void Update(T t);
    }
}