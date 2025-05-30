
using Migration_Task.Data.Enums;

namespace MigrationTask.BLL.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public ProductStatusEnum Status { get; set; } //  Active,Inactive
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

    }

}
