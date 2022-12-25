using IleriRepository.Data;

namespace IleriRepository.Models
{
    public class CountyModel
    {

        public County County { get; set; }
        public string Head { get; set; }
        public string Text { get; set; }
        public string Cls { get; set; }
        public List<City> City {get;set;}    //?
    }
}
