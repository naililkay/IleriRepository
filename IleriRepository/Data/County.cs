using System.ComponentModel.DataAnnotations.Schema;

namespace IleriRepository.Data
{
    public class County:BaseInt
    {

        public string CountyName { get; set; }
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        //tek olduğu için
        public City City { get; set; }
        //birden fazla personel olabilir
        public ICollection <Personel> ?Personels { get; set; }
    }
}
