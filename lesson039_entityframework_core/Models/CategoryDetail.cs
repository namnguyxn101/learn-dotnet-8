using System.ComponentModel.DataAnnotations;

namespace ef
{
    public class CategoryDetail
    {
        public int CategoryDetailID { get; set; }

        public int UserID { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modifed { get; set; }

        public int CountProduct { get; set; }

        public Category? Category { get; set; }
    }
}