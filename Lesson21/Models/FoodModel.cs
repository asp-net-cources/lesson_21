using Lesson21.Data.Models;

namespace Lesson21.Models;

public class FoodModel : ProductModel
{
    public new ProductType ProductType { get; } = ProductType.Food;
}
