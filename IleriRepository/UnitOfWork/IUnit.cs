using IleriRepository.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;

namespace IleriRepository.UnitOfWork
{
    public interface IUnit
    {
       //Iunit interface kullanmak için
       //Bütün interface ve repository toplandığı yer
       //bütün methodalrı tek bir yerde 
       IPersonelRep _personelRep { get; }
        IGradeRep _gradeRep { get; }
        IDepartmentRep _departmanRep { get; }
        ICityRep _cityRep { get; }
        ICountyRep _countyRep { get; }

        void SaveChanges();

    }
}
