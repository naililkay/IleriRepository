using IleriRepository.Core;
using IleriRepository.Data;
using IleriRepository.DTO;

namespace IleriRepository.Repositories.Abstract
{
    public interface IPersonelRep: IBaseRepository<Personel>
    {
        //5 tane ek method core haricindeki
        //ek methodlar yazıcaz.
        public int GetAge(Personel p);
        public string Fullname(Personel p);
        List<string> GetAddress(Personel p);
        Personel FindDetail(int Id); 
        List<PersonelGradeList> ListbyGrade();//grade göre liste
        List<PersonelDepList> ListbyDepatment();//departmana göre liste

    }
}
