namespace IleriRepository.Data
{
    public class City:BaseInt
    {

        public string CityName { get; set; }
        //bir cityde birden fazla  ilçe olabilir
        public ICollection<County> ?Counties{ get; set; }
    }
}
