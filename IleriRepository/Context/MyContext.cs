using IleriRepository.Data;
using Microsoft.EntityFrameworkCore;

namespace IleriRepository.Context
{
    public class MyContext : DbContext
    {

        public MyContext(DbContextOptions<MyContext> db) : base(db)
        {

        }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<County> County { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Department> Department  { get; set; }



  

    }

}
