using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class Categories
    {
        public int CategoriesId { get; set; } //primary key

        public string ProductCategories { get; set; }

        //public string Brand { get; set; }
        //public string Type { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
