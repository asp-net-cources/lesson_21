using Lesson21.Data.EF;
using Lesson21.Data;
using Lesson21.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson21.Controllers;

[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IDataContext _context;

    public ProductController(IDataContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ProductModel?> GetProduct([FromRoute]int id)
    {
        try {
            var all = await _context.SelectProducts();
            var dbProduct =  all.FirstOrDefault(product => product.Id == id);

            ProductModel product = dbProduct.ProductType switch {
                Data.Models.ProductType.Accessories => new AccessoriesModel(),
                Data.Models.ProductType.Book => new BookModel(),
                Data.Models.ProductType.Food => new FoodModel()
            };

            product.Id = dbProduct.Id;
            product.Name = dbProduct.Name;
            product.Description = dbProduct.Description;
            product.Price = dbProduct.Price;

            return product;
        }
        catch(Exception ex) {
            return null;
        }
    }
    
    [HttpPost("{id}")]
    public async Task<ProductModel?> UpdateProduct([FromRoute]int id, [FromBody] ProductModel updatedProduct)
    {
        updatedProduct.Id = id;
        await _context.UpdateProduct(new Data.Models.Product() {
            Id = updatedProduct.Id,
            Name = updatedProduct.Name,
            Description = updatedProduct.Description,
            Price = updatedProduct.Price,
            ProductType = updatedProduct.ProductType
        });
        return updatedProduct;
    }

    [HttpPost("create-product")]
    public async Task<ProductModel?> CreateProduct([FromBody] ProductModel createdProduct) {
        var product = await _context.InsertProduct(new Data.Models.Product() {
            Id = createdProduct.Id,
            Name = createdProduct.Name,
            Description = createdProduct.Description,
            Price = createdProduct.Price,
            ProductType = createdProduct.ProductType
        });

        return new ProductModel() {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ProductType = product.ProductType
        };
    }
}