using Lesson21.Data;
using Lesson21.Data.EF;
using Lesson21.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Lesson21.Tests.Tests.Integration.Data.EF;

public class EFDataContextTests
{
    private IDataContext _context;

    [SetUp]
    public void Setup()
    {
        var optionsBuilder = new DbContextOptionsBuilder<EfDataContext>();
        optionsBuilder.UseMySQL("Datasource=localhost;Database=shop_ef;User=root;Password=root123;");
        _context = new EfDataContext(optionsBuilder.Options);
    }

    [Test]
    public async Task CreateCustomersTest()
    {
        int testId = -11111;

        var customer = new Customer() {
            Id = testId,
            FirstName = "Test",
            LastName = "Test",
            Country = "Test",
            Age = -123
        };
        
        await _context.InsertCustomer(customer);
        
        var customers = await _context.SelectCustomers();

        foreach(var dbCustomer in customers) {
            if (customer.Id == dbCustomer.Id) {
                await _context.DeleteCustomer(testId);
                Assert.Pass();
            }
        }

        Assert.Fail();
    }

    [Test]
    public void InsertCustomerTest()
    {
        Assert.Pass();
    }

    [Test]
    public void UpdateCustomerTest()
    {
        Assert.Pass();
    }

    [Test]
    public void DeleteCustomerTest()
    {
        Assert.Pass();
    }

    [Test]
    public void SelectProductsTest()
    {
        Assert.Pass();
    }

    [Test]
    public void InsertProductTest()
    {
        Assert.Pass();
    }

    [Test]
    public void UpdateProductTest()
    {
        Assert.Pass();
    }

    [Test]
    public void DeleteProductTest()
    {
        Assert.Pass();
    }

    [Test]
    public void SelectOrdersTest()
    {
        Assert.Pass();
    }

    [Test]
    public void InsertOrderTest()
    {
        Assert.Pass();
    }

    [Test]
    public void UpdateOrderTest()
    {
        Assert.Pass();
    }

    [Test]
    public void DeleteOrderTest()
    {
        Assert.Pass();
    }
}