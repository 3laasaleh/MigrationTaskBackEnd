using System.ComponentModel.DataAnnotations;

namespace Migration_Task.Data.Entities
{
    public class Category
    {
        [Key]
            public int CategoryId { get; set; }
            public string? CategoryName { get; set; }
            public string? Description { get; set; }
            public ICollection<Product>? Products { get; set; } 
    }
}
