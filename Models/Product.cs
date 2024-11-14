
using System.ComponentModel.DataAnnotations.Schema;

[Table("products")]
public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int StockQuantity { get; set; }
}