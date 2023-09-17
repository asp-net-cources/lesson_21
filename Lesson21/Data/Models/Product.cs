using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson21.Data.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string Author { get; set; } = string.Empty;
    public double Price { get; set; }
    public ProductType ProductType { get; set; }
}
