using IleriRepository.Context;
using IleriRepository.Core;
using IleriRepository.Data;
using IleriRepository.DTO;
using IleriRepository.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace IleriRepository.Repositories.Concretes
{
    public class PersonelRep <T>: BaseRepository<Personel>,IPersonelRep where T : class
    {
    
        public PersonelRep(MyContext db) : base(db)
        {
           
        }

        public Personel FindDetail(int Id)
        {
            return Set().Include(x=>x.County).ThenInclude(x=>x.City).Include(x=>x.Department).FirstOrDefault(x => x.Id == Id);
        }

        public string Fullname(Personel p)
        {
            return p.FullName();
        }

        public List<string> GetAddress(Personel p)
        {
            return p.GetAddress();
        }

        public int GetAge(Personel p)
        {
            return p.GetAge();
        }

        public List<PersonelDepList> ListbyDepatment()
            //inner join yapıyoruz
        {
            //set personeldeki kolonları okumaya yarıyor.
            return Set().Select(x => new PersonelDepList 
            
            { 
                Id = x.Id,
                //Personel.Department.Departman.DepartmanName
                Deparment=x.Department.DepartmentName,
                Fullname=x.Name+" "+x.SurName,
                ImgUrl=x.ImgUrl,

            }).OrderBy(x =>x.Deparment).ToList();
           // return ls;
   
        }

        public List<PersonelGradeList> ListbyGrade()
        {
            //set personeldeki kolonları okumaya yarıyor.
            return Set().Select(x => new PersonelGradeList

            {
               
                Id = x.Id,
               //Personeltablosu ile PersonelGrade tablosunu birlerştirdik
                //Personel.Grade.Grade.Gradeneme
                Grade = x.Grade.GradeName,
                GradeId = x.GradeId,
                Fullname = x.Name + " " + x.SurName,
                ImgUrl = x.ImgUrl,

            }).OrderBy(x=>x.GradeId).ToList();
        }
    }
}
