using IleriRepository.Context;
using Microsoft.EntityFrameworkCore;

namespace IleriRepository.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        MyContext _db;

        public BaseRepository(MyContext db)
        {
            _db = db;
        }
        public bool Add(T entity)
        {

            try
            {
                Set().Add(entity);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                Set().Remove(entity);
                return true;
            }
            catch {
                
                return false; }

        }

        public T Find(int Id)
        {
            return Set().Find(Id);
        }
        public T Find(string Id)
        {
            return Set().Find(Id);
        }

        public List<T> List()
        {
            // _db.Set<T>().ToList(); bunu yazmamak için set dedik
            return Set().ToList();
        }

        public DbSet<T> Set()
        {
            return _db.Set<T>();
        }
       

        public bool Update(T entity)
        {
            try
            {
                Set().Update(entity);
                return true;
            }
            catch
            {
                return false;
            }

        }

    }
}
