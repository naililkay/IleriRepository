using IleriRepository.Context;
using IleriRepository.Repositories.Abstract;

namespace IleriRepository.UnitOfWork
{
    public class Unit : IUnit
    {
        MyContext _db;
        //newlememekiçin
        public Unit(MyContext db, IPersonelRep personelRep, IGradeRep gradeRep, IDepartmentRep departmanRep, ICityRep cityRep, ICountyRep countyRep)
        {
            _db = db;
            //PersonelRep personelRep=new PersonelRep();
            _personelRep = personelRep;
            _gradeRep = gradeRep;
            _departmanRep = departmanRep;
            _cityRep = cityRep;
            _countyRep = countyRep;
        }


        //interface ve class aynı olmak zorunda
        //set veri atmıcaz
        public IPersonelRep _personelRep { get; }
        
        public IGradeRep _gradeRep { get; }

        public IDepartmentRep _departmanRep { get; }

        public ICityRep _cityRep { get; }

        public ICountyRep _countyRep { get; }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
