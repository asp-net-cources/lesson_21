using Lesson21.Data.Models;

namespace Lesson21.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public ProductType ProductType { get; set; }
}