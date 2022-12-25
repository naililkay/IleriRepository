using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace IleriRepository.Data
{
    public class Personel : BaseInt
    {
        public string ?Name { get; set; }
        public string ?SurName { get; set; }
        public DateTime DateofBirth { get; set; }
        public int DepartmanId { get; set; }
        public string ?GradeId { get; set; }
        public char Gender { get; set; }
        public string ?Street { get; set; }
        public string ?Avenue { get; set; }
        private string  ?Phone { get; set; }
        public int No { get; set; }
        public int CountyId { get; set; }
        public string ?ImgUrl { get; set; }

        [ForeignKey("CountyId")]
        public County County { get; set; }//her personelin bir sehir olabilir
        [ForeignKey("GradeId")]
    
        public Grade Grade { get; set; }    //her personelin bir tane grade olabilir

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; } //her personelin bir tanedepartmanı olabilir
        public int GetAge()
        {
            //05.09.1998
            DateTime today = DateTime.Now;
            // today 24.10.222
            int age = today.Year - DateofBirth.Year;
            //2022-1998=24
            DateTime Birthday = DateofBirth.AddYears(age);
       
            if (today < Birthday)///2022<1998
            {

                age--;
            }
            return age;
        }
        public string FullName()
        {

            if (Gender == 'E')
            {
                return $"Sn. Bay{Name}{SurName}";
            }
            else return $"Sn. Bayan{Name}{SurName}";




        }
        public List<string> GetAddress()
        {

          List<string> address = new List<string>();
            //address.Add(FullName());
            address.Add(Street);
            address.Add(Avenue);
            address.Add(No.ToString());
           
            //inner join
            address.Add(County.CountyName + "/" + County.City.CityName);
            return address;
        }



    }
}
