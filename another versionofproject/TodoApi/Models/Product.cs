using System.ComponentModel.DataAnnotations; //for validation
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
   public class Product
   {
    //[Required]
    public long ProductId { get; set; }
    public string? ProductName { get; set; }
    public bool IsComplete { get; set; }
    public string ProductCategories { get; set; }
    //public List<Categories> Categories { get; } = new List<Categories>();
        //[ForeignKey("BrandId")]
        //public virtual Categories Brand { get; set; }
        //[ForeignKey("TypeId")]
        //public virtual Categories Type { get; set; }

    }
}
