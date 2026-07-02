using PhantasmalARTdemo.Models.DTO;

namespace PhantasmalARTdemo.Models.Containers
{
    public class Page<T>
    {
        public List<T>? Items { get; set; } = new List<T>();
        public int CurPage { get; set; } = 0;
        public int MaxPage { get; set; } = 0;
        public int ItemsPerPage { get; set; } = 15;
    }
}
