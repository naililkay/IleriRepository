namespace IleriRepository.Data
{
    public class Department:BaseInt
    {
        public string  DepartmentName{ get; set; }
        //bir departmanda birden fazla personel olabilir
        public ICollection<Personel>? Personels { get; set; }
    }
}
