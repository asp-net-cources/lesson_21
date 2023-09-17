using Lesson21.Data.Models;

namespace Lesson21.Models;

public class BookModel : ProductModel
{
    public new ProductType ProductType { get; } = ProductType.Book;
}
