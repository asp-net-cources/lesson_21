using Lesson21.Data.Models;

namespace Lesson21.Models;

public class AccessoriesModel : ProductModel
{
    public new ProductType ProductType { get; } = ProductType.Accessories;
}
