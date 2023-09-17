﻿using System.Collections.Generic;
using System.Diagnostics;
using Lesson21.Data.EF;
using Lesson21.Data;
using Lesson21.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prometheus;

namespace Lesson21.Controllers;

public class HomeController : Controller
{
    public IDataContext _dataContext;


    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger, IDataContext dataContext)
    {
        _logger = logger;
        _dataContext = dataContext;
    }

    public async Task<IActionResult> Index(string param)
    {
        _logger.LogInformation("New request to Home/Index: param:{param}", param);
        var model = new IndexModel {
            Products = (await _dataContext.SelectProducts()).Where(product => product != null).ToList()
        };
        
        var counter = Metrics.CreateCounter("prometheus_home_index_get_count", "Home Index Requests Total");
        counter.Inc();
        
        return View(model);
    }

    [HttpPost("create-product")]
    public async Task<IActionResult> CreateProduct([FromForm]ProductModel newProduct)
    {
        await _dataContext.InsertProduct(new Data.Models.Product() {
            Id = newProduct.Id,
            Name = newProduct.Name,
            Description = newProduct.Description,
            Price = newProduct.Price,
            ProductType = newProduct.ProductType
        });
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}