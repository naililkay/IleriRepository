using IleriRepository.Context;
using IleriRepository.Core;
using IleriRepository.Data;
using IleriRepository.Repositories.Abstract;

namespace IleriRepository.Repositories.Concretes
{
    public class CityRep<T> : BaseRepository<City>, ICityRep where T : class
    {
        public CityRep(MyContext db) : base(db)
        {

        }
    }
}
