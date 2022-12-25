using IleriRepository.Context;
using IleriRepository.Core;
using IleriRepository.Data;
using IleriRepository.Repositories.Abstract;

namespace IleriRepository.Repositories.Concretes
{
    public class CountyRep <T> : BaseRepository<County>, ICountyRep where T : class
    {

        public CountyRep(MyContext db) : base(db)
        {

        }
    }
}
